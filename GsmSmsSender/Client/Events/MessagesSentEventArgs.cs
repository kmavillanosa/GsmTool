using GsmSmsSender.Client.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmSmsSender.Client.Events
{
    public class MessagesSentEventArgs : EventArgs
    {
        public IEnumerable<ISmsDetails> Message { get; set; }
        public DateTime SentDate { get; set; }
        public Guid guid { get; set; }
    }
}
