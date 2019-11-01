using GsmSmsSender.Client.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GsmSmsSender.Configuration.Infrastructure;
using GsmSmsSender.Configuration.Events;
using GsmSmsSender.Client.Events;
using GsmComm.GsmCommunication;
using GsmComm.PduConverter;

namespace GsmSmsSender.Client.Repository
{
    public class SmsClient : ISmsRepository<ISmsDetails>
    {
        
        public event EventHandler<MessageSentEventArgs> OnMessageSent;
        public event EventHandler<MessagesSentEventArgs> OnMessagesSent;
        public event EventHandler<SmsServerConnected> OnServerConnected;
        public event EventHandler<ServerConnectErrorEventArgs> OnServerConnectionFail;
        public event EventHandler<MessageSendingFailedEventArgs> OnMessageSendingFailed;

        private GsmCommMain _server { get; set; }
        public bool Islive { get; set; }

        public async void RegisterConfiguration(ISmsConfiguration Config)
        {
            _server = new GsmCommMain(Config.Port, Config.BaudRate, 5000);
            do
            {
                await Task.Delay(100);
                if (_server.IsOpen())
                {
                    // connect event
                    OnServerConnected.CrossInvoke(this, new SmsServerConnected()
                    {
                        TimeConnected = DateTime.Now
                    });
                    break;
                }
                else
                {
                    try
                    {
                        _server.Open();
                    }
                    catch(Exception ex)
                    {
                        OnServerConnectionFail.CrossInvoke(this, new ServerConnectErrorEventArgs()
                        {
                            DatePosted = DateTime.Now,
                            guid = Guid.NewGuid(),
                            Message = ex.InnerException.Message ?? ex.Message
                        });
                    }
                }
            }
            while (true);
        }

        public void SendMessage(ISmsDetails Item)
        {
            try
            {
                SmsSubmitPdu sender = new SmsSubmitPdu(Item.Message, Item.Recipient);
                _server.SendMessage(sender);

                OnMessageSent.CrossInvoke(this, new MessageSentEventArgs()
                {
                    guid = Guid.NewGuid(),
                    MessageDetail = Item,
                    SentDate = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                OnMessageSendingFailed.CrossInvoke(this, new MessageSendingFailedEventArgs()
                {
                    DateSent = DateTime.Now,
                    ErrorCode = Guid.NewGuid().ToString(),
                    ErrorNumber = ex.HResult,
                    Message = ex.InnerException.Message ?? ex.Message
                });
            }

        }

        public void SendMessages(IEnumerable<ISmsDetails> Items)
        {
            try
            {
                Items.ToList().ForEach(Item =>
                {
                    SmsSubmitPdu sender = new SmsSubmitPdu(Item.Message, Item.Recipient);
                    _server.SendMessage(sender);
                });
                OnMessagesSent.CrossInvoke(this, new MessagesSentEventArgs()
                {
                    guid = Guid.NewGuid(),
                    Message = Items,
                    SentDate = DateTime.Now
                });
            }
            catch { }
           
        }
    }
}