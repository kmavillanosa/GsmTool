using GsmSmsSender.Client.Events;
using GsmSmsSender.Configuration.Events;
using GsmSmsSender.Configuration.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmSmsSender.Client.Infrastructure
{
    public interface ISmsRepository<A> : ISmsBaseRepository<ISmsConfiguration>
        where A: ISmsDetails 
    {
        void SendMessage(A Item);
        void SendMessages(IEnumerable<A> Items);

        event EventHandler<SmsServerConnected> OnServerConnected;
        event EventHandler<MessageSentEventArgs> OnMessageSent;
        event EventHandler<MessagesSentEventArgs> OnMessagesSent;
        event EventHandler<MessageSendingFailedEventArgs> OnMessageSendingFailed;
        event EventHandler<ServerConnectErrorEventArgs> OnServerConnectionFail;
    }
}
