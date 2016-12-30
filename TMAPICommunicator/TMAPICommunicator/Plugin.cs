using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCheatX.Core;
using NetCheatX.Core.Interfaces;

namespace TMAPICommunicator
{
    public class Plugin : IPluginMain
    {
        private Communicator _communicator;
        private ObjectVersion _version = new ObjectVersion(1, 0);


        public string Author { get; } = "Daniel Gerendasy";
        public string Description { get; } = "TMAPI Communicator plugin for NetCheat X.";
        public string Name { get; } = "TMAPI Communicator";
        public ObjectVersion Version { get { return _version; } }
        public string[] SupportedPlatforms { get; } = null;

        // Register our PC Communicator
        public void Initialize(IPluginHost host)
        {
            host.Communicators.Add(this, _communicator = new Communicator());
        }

        // Clean up
        public void Dispose(IPluginHost host)
        {
            _communicator = null;
            _version = null;
        }
    }
}