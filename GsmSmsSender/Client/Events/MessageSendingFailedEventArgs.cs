using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmSmsSender.Client.Events
{
    public class MessageSendingFailedEventArgs : EventArgs
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public int ErrorNumber { get; set; }
        public DateTime DateSent { get; set; }
    }
}
