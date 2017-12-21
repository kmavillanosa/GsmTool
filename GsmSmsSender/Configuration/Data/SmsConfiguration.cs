using GsmSmsSender.Configuration.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmSmsSender.Configuration.Data
{
    [Serializable]
    public class SmsConfiguration : ISmsConfiguration
    {
        [Category("Configuration"),Description("Baud Rate")]
        public int BaudRate
        {
            get;
            set;
        }
        [Category("Configuration"), Description("Gsm port")]
        public string Port
        {
            get;
            set;
        }
    }
}
