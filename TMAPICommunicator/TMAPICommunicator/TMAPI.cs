// ************************************************* //
//    --- Copyright (c) 2014 iMCS Productions ---    //
// ************************************************* //
//              PS3Lib v4 By FM|T iMCSx              //
//                                                   //
// Features v4.4 :                                   //
// - Support CCAPI v2.6 C# by iMCSx                  //
// - Set Boot Console ID                             //
// - Popup better form with icon                     //
// - CCAPI Consoles List Popup French/English        //
// - CCAPI Get Console Info                          //
// - CCAPI Get Console List                          //
// - CCAPI Get Number Of Consoles                    //
// - Get Console Name TMAPI/CCAPI                    //
//                                                   //
// Credits : FM|T Enstone , Buc-ShoTz                //
//                                                   //
// Follow me :                                       //
//                                                   //
// FrenchModdingTeam.com                             //
// Youtube.com/iMCSx                                 //
// Twitter.com/iMCSx                                 //
// Facebook.com/iMCSx                                //
//                                                   //
// ************************************************* //

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace TMAPICommunicator
{
    public class TMAPI
    {
        public static int Target = 0xFF;
        public static bool AssemblyLoaded = true;
        public static PS3TMAPI.ResetParameter resetParameter;

        public TMAPI()
        {
            PS3TMAPI_NET();
        }

        public class SCECMD
        {
            /// <summary>Get the target status and return the string value.</summary>
            public string SNRESULT()
            {
                return Parameters.snresult;
            }

            /// <summary>Get the target name.</summary>
            public string GetTargetName()
            {
                return GetTargetName(Target);
            }

            /// <summary>Get the given target name.</summary>
            public string GetTargetName(int target)
            {
                PS3TMAPI.InitTargetComms();
                PS3TMAPI.TargetInfo TargetInfo = new PS3TMAPI.TargetInfo()
                {
                    Flags = PS3TMAPI.TargetInfoFlag.TargetID,
                    Target = target
                };
                PS3TMAPI.GetTargetInfo(ref TargetInfo);
                Parameters.ConsoleName = TargetInfo.Name;

                return Parameters.ConsoleName;
            }

            /// <summary>Get the target's IP:Port.</summary>
            public string GetTargetIPPort()
            {
                return GetTargetIPPort(Target);
            }

            /// <summary>Get the given target's IP:Port.</summary>
            public string GetTargetIPPort(int target)
            {
                PS3TMAPI.InitTargetComms();
                PS3TMAPI.TargetInfo TargetInfo = new PS3TMAPI.TargetInfo()
                {
                    Flags = PS3TMAPI.TargetInfoFlag.TargetID,
                    Target = target
                };
                PS3TMAPI.GetTargetInfo(ref TargetInfo);
                Parameters.IPPort = TargetInfo.Info.Split(' ').Last();

                return Parameters.IPPort;
            }

            /// <summary>Get the target status and return the string value.</summary>
            public string GetStatus()
            {
                return GetStatus(Target);
            }

            /// <summary>Get the given target status and return the string value.</summary>
            public string GetStatus(int target)
            {
                if (TMAPI.AssemblyLoaded)
                    return "NotConnected";
                Parameters.connectStatus = new PS3TMAPI.ConnectStatus();
                PS3TMAPI.GetConnectStatus(target, out Parameters.connectStatus, out Parameters.usage);
                Parameters.Status = Parameters.connectStatus.ToString();
                return Parameters.Status;
            }

            /// <summary>Get the ProcessID by the current process.</summary>
            public uint ProcessID()
            {
                return Parameters.ProcessID;
            }

            /// <summary>Get an array of processID's.</summary>
            public uint[] ProcessIDs()
            {
                return Parameters.processIDs;
            }

            /// <summary>Get some details from your target.</summary>
            public PS3TMAPI.ConnectStatus DetailStatus()
            {
                return Parameters.connectStatus;
            }
        }

        public SCECMD SCE
        {
            get { return new SCECMD(); }
        }

        public class Parameters
        {
            public static string
                usage,
                info,
                snresult,
                Status,
                MemStatus,
                ConsoleName,
                IPPort;
            public static uint
                ProcessID;
            public static uint[]
                processIDs;
            public static byte[]
                Retour;
            public static PS3TMAPI.ConnectStatus
                connectStatus;
        }

        /// <summary>Enum of flag reset.</summary>
        public enum ResetTarget
        {
            Hard,
            Quick,
            ResetEx,
            Soft
        }

        public bool InitComms()
        {
            return PS3TMAPI.InitTargetComms() == PS3TMAPI.SNRESULT.SN_S_OK;
        }

        /// <summary>
        /// Find the target the Target Manager is currently connected to.
        /// </summary>
        public int GetConnectedTarget()
        {
            if (PS3TMAPI.GetNumTargets(out uint targets) != PS3TMAPI.SNRESULT.SN_S_OK)
                return -1;

            for (uint x = 0; x < targets; x++)
            {
                if (SCE.GetStatus((int)x) == PS3TMAPI.ConnectStatus.Connected.ToString())
                {
                    Target = (int)x;
                    return (int)x;
                }
            }

            return -1;
        }

        /// <summary>Connect the default target and initialize the dll. Possible to put an int as arugment for determine which target to connect.</summary>
        public bool ConnectTarget(int TargetIndex = 0)
        {
            bool result = false;
            if (AssemblyLoaded)
                PS3TMAPI_NET();
            Target = TargetIndex;
            result = PS3TMAPI.SUCCEEDED(PS3TMAPI.InitTargetComms());
            result = PS3TMAPI.SUCCEEDED(PS3TMAPI.Connect(TargetIndex, null));
            return result;
        }

        /// <summary>Connect the target by is name.</summary>
        public bool ConnectTarget(string TargetName)
        {
            bool result = false;
            if (AssemblyLoaded)
                PS3TMAPI_NET();
            AssemblyLoaded = false;
            result = PS3TMAPI.SUCCEEDED(PS3TMAPI.InitTargetComms());
            if (result)
            {
                result = PS3TMAPI.SUCCEEDED(PS3TMAPI.GetTargetFromName(TargetName, out Target));
                result = PS3TMAPI.SUCCEEDED(PS3TMAPI.Connect(Target, null));
            }
            return result;
        }

        /// <summary>Disconnect the target.</summary>
        public void DisconnectTarget()
        {
            PS3TMAPI.Disconnect(Target);
        }

        /// <summary>Get thread list.</summary>
        public PS3TMAPI.SNRESULT GetThreadList(int target, uint processID, out ulong[] ppuThreadIDs, out ulong[] spuThreadIDs)
        {
            return PS3TMAPI.GetThreadList(target, processID, out ppuThreadIDs, out spuThreadIDs);
        }

        /// <summary>Get thread list.</summary>
        public PS3TMAPI.SNRESULT GetPPUThreadInfo(int target, uint processID, ulong threadID, out PS3TMAPI.PPUThreadInfo threadInfo)
        {
            return PS3TMAPI.GetPPUThreadInfo(target, processID, threadID, out threadInfo);
        }

        /// <summary>Power on selected target.</summary>
        public void PowerOn(int numTarget = 0)
        {
            if (Target != 0xFF)
                numTarget = Target;
            PS3TMAPI.PowerOn(numTarget);
        }

        /// <summary>Power off selected target.</summary>
        public void PowerOff(bool Force)
        {
            PS3TMAPI.PowerOff(Target, Force);
        }

        /// <summary>Attach and continue the current process from the target.</summary>
        public bool AttachProcess(bool continueProcess = true)
        {
            byte[] buffer = new byte[4];
            if (PS3TMAPI.GetProcessList(Target, out Parameters.processIDs) != PS3TMAPI.SNRESULT.SN_S_OK)
                return false;
            if (Parameters.processIDs.Length <= 0)
                return false;

            ulong uProcess = Parameters.processIDs[0];
            Parameters.ProcessID = Convert.ToUInt32(uProcess);

            // Check if already attached
            if (this.GetMemory(0x10000, ref buffer) == PS3TMAPI.SNRESULT.SN_S_OK)
                return true;

            if (PS3TMAPI.ProcessAttach(Target, PS3TMAPI.UnitType.PPU, Parameters.ProcessID) != PS3TMAPI.SNRESULT.SN_S_OK)
                return false;

            if (continueProcess)
                PS3TMAPI.ProcessContinue(Target, Parameters.ProcessID);
            Parameters.info = "The Process 0x" + Parameters.ProcessID.ToString("X8") + " Has Been Attached !";

            return true;
        }

        /// <summary>Attach the current process from the target.</summary>
        public bool AttachProcOnly()
        {
            bool isOK = false;
            PS3TMAPI.GetProcessList(Target, out Parameters.processIDs);
            if (Parameters.processIDs.Length > 0)
                isOK = true;
            else isOK = false;
            if (isOK)
            {
                ulong uProcess = Parameters.processIDs[0];
                Parameters.ProcessID = Convert.ToUInt32(uProcess);
                PS3TMAPI.ProcessAttach(Target, PS3TMAPI.UnitType.PPU, Parameters.ProcessID);
                Parameters.info = "The Process 0x" + Parameters.ProcessID.ToString("X8") + " Has Been Attached !";
            }
            return isOK;
        }

        public void ContinueProcess()
        {
            PS3TMAPI.ProcessContinue(Target, Parameters.ProcessID);
        }

        public void StopProcess()
        {
            PS3TMAPI.ProcessStop(Target, Parameters.ProcessID);
        }

        /// <summary>Set memory to the target (byte[]).</summary>
        public PS3TMAPI.SNRESULT SetMemory(uint Address, byte[] Bytes)
        {
            return PS3TMAPI.ProcessSetMemory(Target, PS3TMAPI.UnitType.PPU, Parameters.ProcessID, 0, Address, Bytes);
        }

        /// <summary>Get memory from the address.</summary>
        public PS3TMAPI.SNRESULT GetMemory(uint Address, ref byte[] Bytes)
        {
            return PS3TMAPI.ProcessGetMemory(Target, PS3TMAPI.UnitType.PPU, Parameters.ProcessID, 0, Address, ref Bytes);
        }

        internal static string ByteArrayToString(byte[] buffer, int startIndex, int maxLength = 0)
        {
            int max = startIndex + maxLength;
            if (max == startIndex)
                max = buffer.Length;
            string ret = "";

            for (int x = startIndex; x < max; x++)
            {
                if (buffer[x] == 0)
                    break;
                ret += ((char)buffer[x]).ToString();
            }
            return ret;
        }

        /// <summary>Reset target to XMB , Sometimes the target restart quickly.</summary>
        public void ResetToXMB(ResetTarget flag)
        {
            if (flag == ResetTarget.Hard)
                resetParameter = PS3TMAPI.ResetParameter.Hard;
            else if (flag == ResetTarget.Quick)
                resetParameter = PS3TMAPI.ResetParameter.Quick;
            else if (flag == ResetTarget.ResetEx)
                resetParameter = PS3TMAPI.ResetParameter.ResetEx;
            else if (flag == ResetTarget.Soft)
                resetParameter = PS3TMAPI.ResetParameter.Soft;
            PS3TMAPI.Reset(Target, resetParameter);
        }

        public bool IsGameRunning()
        {
            PS3TMAPI.GetThreadList(0, Parameters.ProcessID, out var ppu, out var spu);

            foreach (ulong tID in ppu)
            {
                PS3TMAPI.GetPPUThreadInfo(0, Parameters.ProcessID, tID, out var ppuTI);
                if (ppuTI.State != PS3TMAPI.PPUThreadState.OnProc && ppuTI.State != PS3TMAPI.PPUThreadState.Sleep)
                    return false;
            }

            return true;
        }

        public List<string> GetAllTargets()
        {
            List<string> result = new List<string>();

            if (PS3TMAPI.GetNumTargets(out uint count) != PS3TMAPI.SNRESULT.SN_S_OK)
                return null;

            for (int target = 0; target < count; target++)
                result.Add(SCE.GetTargetName(target));

            return result;
        }

        internal static Assembly LoadApi;
        ///<summary>Load the PS3 API for use with your Application .NET.</summary>
        public Assembly PS3TMAPI_NET()
        {
            //AppDomain.CurrentDomain.AssemblyResolve += (s, e) =>
            {
                //var filename = new AssemblyName(e.Name).Name;
                var filename = Assembly.GetExecutingAssembly().GetName().Name;
                var x = string.Format(@"C:\Program Files\SN Systems\PS3\bin\ps3tmapi_net.dll", filename);
                var x64 = string.Format(@"C:\Program Files (x64)\SN Systems\PS3\bin\ps3tmapi_net.dll", filename);
                var x86 = string.Format(@"C:\Program Files (x86)\SN Systems\PS3\bin\ps3tmapi_net.dll", filename);
                if (System.IO.File.Exists(x))
                {
                    LoadApi = Assembly.LoadFile(x);
                }
                else
                {
                    if (System.IO.File.Exists(x64) && IntPtr.Size == 8)
                    {
                        LoadApi = Assembly.LoadFile(x64);
                    }
                    else
                    {
                        if (System.IO.File.Exists(x86))
                            LoadApi = Assembly.LoadFile(x86);
                        else
                            MessageBox.Show("Target Manager API cannot be founded to:\r\n\r\n" + x86, "Error with PS3 API!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                AssemblyLoaded = LoadApi == null;
                return LoadApi;
            };
            //return LoadApi;
        }
    }
}