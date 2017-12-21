using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmSmsSender.Configuration.Events
{
    public class SmsServerConnected : EventArgs
    {
        public DateTime TimeConnected { get; set; }
    }
}
