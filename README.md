# GsmTool

Works with GSM Usb Stick Modem


```C#
	SmsClient client = new SmsClient(); // client
        GsmConfiguration settings = new GsmConfiguration(); // configuration, (forms and properties)
	
 	// connect to gsm port 
        client.RegisterConfiguration(new SmsConfiguration { BaudRate = 9600, Port = "Serial port here ex: (COM5,COM6)" }); 
	
	// single message
         client.SendMessage(new SmsDetails() { Message = "Gsm tester", Recipient = "Number" });
	 
	// multiple message
        List<SmsDetails> detailList = new List<SmsDetails>();
        detailList.AddRange(new SmsDetails[]
                {
                    new SmsDetails() { Message = "Hello World", Recipient = "Number" },
                    new SmsDetails() { Message = "Hello World", Recipient = "Number" },
                    new SmsDetails() { Message ="Hello World", Recipient = "Number" },
                    new SmsDetails() { Message = "Hello World", Recipient = "Number" },
                    new SmsDetails() { Message ="Hello World", Recipient = "Number" },
                });
        client.SendMessages(detailList);

        // raise events 
         client.OnServerConnected += Client_OnServerConnected;
         client.OnMessageSent += Client_OnMessageSent;
         client.OnMessageSendingFailed += Client_OnMessageSendingFailed;
         client.OnServerConnectionFail += Client_OnServerConnectionFail;
         client.OnMessagesSent += Client_OnMessagesSent;
       
	//EVENTS 
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
        }
```
