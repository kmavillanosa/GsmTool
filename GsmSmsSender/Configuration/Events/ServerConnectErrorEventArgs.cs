using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmSmsSender.Configuration.Events
{
    public class ServerConnectErrorEventArgs : EventArgs
    {
        public string Message { get; set; }
        public DateTime DatePosted { get; set; }
        public Guid guid { get; set; }
    }
}
