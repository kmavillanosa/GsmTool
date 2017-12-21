using GsmSmsSender.Client.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmSmsSender.Client.Data
{
    public class SmsDetails : ISmsDetails
    {
        public string Message
        {
            get;
            set;
        }

        public string Recipient
        {
            get;
            set;
        }
    }
}
