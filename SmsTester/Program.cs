using GsmSmsSender.Client.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GsmSmsSender.Configuration.Infrastructure;
using GsmSmsSender.Configuration.Data;
using GsmSmsSender.Client.Data;
using GsmSmsSender.Configuration.Repository;
using GsmSmsSender.Client.Events;
using GsmSmsSender.Configuration.Events;

namespace SmsTester
{
    class Program
    {
        static SmsClient client = new SmsClient();
        static GsmConfiguration settings = new GsmConfiguration();
        static void Main(string[] args)
        {
            settings.LoadForm();
            client.OnServerConnected += Client_OnServerConnected;
            client.OnMessageSent += Client_OnMessageSent;
            client.OnMessageSendingFailed += Client_OnMessageSendingFailed;
            client.OnServerConnectionFail += Client_OnServerConnectionFail;
            client.OnMessagesSent += Client_OnMessagesSent;
            client.RegisterConfiguration(settings.config);
            Console.ReadLine();
        }

        private static void Client_OnMessagesSent(object sender, MessagesSentEventArgs e)
        {
            Console.WriteLine(e.Message.ToList());
        }

        private static void Client_OnServerConnectionFail(object sender, ServerConnectErrorEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void Client_OnMessageSendingFailed(object sender, MessageSendingFailedEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void Client_OnMessageSent(object sender, MessageSentEventArgs e)
        {
            Console.WriteLine(string.Format("Message sent to {0} , Message: {1}", e.MessageDetail.Recipient, e.MessageDetail.Message));
        }
        private static void Client_OnServerConnected(object sender, SmsServerConnected e)
        {
            Console.WriteLine("Server Connected");


            //   client.SendMessage(new SmsDetails() { Message = "Gsm tester", Recipient = "09106010641" });



            // multiple
            //List<SmsDetails> detailList = new List<SmsDetails>();
            //detailList.AddRange(new SmsDetails[]
            //        {
            //            new SmsDetails() { Message = "Hello World", Recipient = "Number" },
            //            new SmsDetails() { Message = "Hello World", Recipient = "Number" },
            //            new SmsDetails() { Message ="Hello World", Recipient = "Number" },
            //            new SmsDetails() { Message = "Hello World", Recipient = "Number" },
            //            new SmsDetails() { Message ="Hello World", Recipient = "Number" },
            //        });
            //client.SendMessages(detailList);
        }
    }
}
