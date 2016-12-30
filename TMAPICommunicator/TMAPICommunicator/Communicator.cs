using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using NetCheatX.Core;
using NetCheatX.Core.Interfaces;
using NetCheatX.Core.Bitlogic;

namespace TMAPICommunicator
{
    public class Communicator : ICommunicator
    {
        private IPluginHost _host = null;
        //private Timer _timer = null;
        private Thread _getStatusThread = null;
        private Label _label = null;
        private static TMAPI _manager = null;
        private bool _ready = false;
        private ObjectVersion _version = new ObjectVersion(420, 1, 14, 7);

        // unique id of the Init form (used when NetCheat X is loading last saved UI layout)
        private string form_init_id = "CONNECT";


        public string Author { get; } = "Daniel Gerendasy";

        public string Description { get; } = "TMAPI Communicator plugin for NetCheat X. Let's you scan any debugged game on your PS3 through the Target Manager API with NetCheat X.";

        public string Name { get; } = "TMAPI Communicator";

        public string Platform { get; } = "PS3";

        public Types.Endian PlatformEndianess { get; } = Types.Endian.BigEndian;

        public Types.BitArchitecture PlatformBitArchitecture { get; } = Types.BitArchitecture.bit32;

        public EndianBitConverter PlatformBitConverter { get; } = EndianBitConverter.BigEndianBitConverter;

        public ObjectVersion Version { get { return _version; } }

        public bool Ready
        {
            get { return _ready; }
            set
            {
                if (value != _ready)
                {
                    _ready = value;

                    _label.Invoke((MethodInvoker)delegate
                    {
                        if (ReadyChanged != null)
                            ReadyChanged.Invoke(this, Ready ? "Attached" : "Not Attached");
                    });
                }
            }
        }

        public event EventHandler<string> ReadyChanged;

        public bool GetBytes(ulong address, ref byte[] bytes)
        {
            if (!Ready || _manager == null)
                return false;

            return _manager.GetMemory((uint)address, ref bytes) == PS3TMAPI.SNRESULT.SN_S_OK;
        }

        public bool SetBytes(ulong address, byte[] bytes)
        {
            if (!Ready || _manager == null)
                return false;

            return _manager.SetMemory((uint)address, bytes) == PS3TMAPI.SNRESULT.SN_S_OK;
        }

        public Types.ProcessState GetProcessState()
        {
            byte[] elfmagic = new byte[4];
            if ( _manager == null || _manager.GetMemory(0x10000, ref elfmagic) != PS3TMAPI.SNRESULT.SN_S_OK)
                return Types.ProcessState.Killed;

            if (!_manager.IsGameRunning())
                return Types.ProcessState.Paused;

            return Types.ProcessState.Running;
        }

        public bool SetProcessState(Types.ProcessState state)
        {
            if (!Ready || _manager == null)
                return false;

            switch (state)
            {
                case Types.ProcessState.Running:
                    _manager.ContinueProcess();
                    break;
                case Types.ProcessState.Paused:
                    _manager.StopProcess();
                    break;
                case Types.ProcessState.Killed:
                    // We can't exit a game p[ocess without throwing an exception so we can just reset to XMB
                    _manager.ResetToXMB(TMAPI.ResetTarget.Quick);
                    break;
            }

            return true;
        }

        public bool InitializeXForm(out NetCheatX.Core.UI.XForm xForm, string uniqueName)
        {
            // Go through each form ID and set xForm to initialized form
            // Return null if invalid uniqueName
            if (uniqueName == form_init_id)
            {
                return AddInitForm(out xForm, _host);
            }


            xForm = null;
            return false;
        }

        public bool Reconnect()
        {
            // Make sure our reconnect variables are valid
            if (_manager == null)
                return false;

            _manager.InitComms();
            if (_manager.GetConnectedTarget() < 0)
                return false;

            // Get current process state
            Types.ProcessState state = GetProcessState();

            // If it's already running or paused then we are already attached
            if (state != Types.ProcessState.Killed)
                return true;

            // Otherwise, try attaching
            return _manager.AttachProcess();
        }

        public void Initialize(IPluginHost host)
        {
            _host = host;

            // Setup unique names for each form
            form_init_id = Name + " " + Version + " " + form_init_id;

            // Create MemMan instance
            _manager = new TMAPI();

            // Create label for invoking in main thread
            _label = new Label();
            _label.CreateControl();
            _label.Visible = false;

            _getStatusThread = new Thread(new ParameterizedThreadStart(CheckStatus));
            _getStatusThread.Start(this);


            // Register forms with UI
            host.RegisterWindow(this, "Connect to PS3", form_init_id, "Displays options to connect and attach to the PS3.", AddInitForm);
        }

        public void Dispose(IPluginHost host)
        {
            form_init_id = null;
            _manager = null;
            _version = null;

            if (_getStatusThread != null)
            {
                _getStatusThread.Abort();
                _getStatusThread = null;
            }
        }


        private bool AddInitForm(out NetCheatX.Core.UI.XForm form, IPluginHost host)
        {
            // Initialize our Target Manager Init form into form
            form = new UI.Init(this, _manager, host);
            return true;
        }

        // Check status of connection every second
        private static void CheckStatus(object data)
        {
            int target;
            Communicator com;

            if (data == null)
                return;

            com = (Communicator)data;
            if (_manager == null)
                return;

            _manager.InitComms();
            while (true)
            {
                Thread.Sleep(10000);

                try
                {
                    target = _manager.GetConnectedTarget();
                    if (target > -1)
                    {
                        if (com.GetProcessState() == Types.ProcessState.Killed)
                        {
                            com.Ready = false;
                            continue;
                        }

                        com.Ready = true;
                        continue;
                    }

                    if (target == -1 && com.Ready)
                    {
                        com.Ready = false;
                        continue;
                    }
                } catch { }
            }
        }
    }
}