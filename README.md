# GsmTool

Works with GSM Usb Stick Modem

# Usage:
```C#
	SmsClient client = new SmsClient(); // client
        GsmConfiguration settings = new GsmConfiguration(); // configuration, (forms and properties)
```
## Raise events

```C#
         client.OnServerConnected += Client_OnServerConnected;
         client.OnMessageSent += Client_OnMessageSent;
         client.OnMessageSendingFailed += Client_OnMessageSendingFailed;
         client.OnServerConnectionFail += Client_OnServerConnectionFail;
         client.OnMessagesSent += Client_OnMessagesSent;

```

## Connect to gsm port 

```C#
        client.RegisterConfiguration(new SmsConfiguration { BaudRate = 9600, Port = "Serial port here ex: (COM5,COM6)" }); 
```

## Message sending 

```C#
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
	 
```




  ## Events
  
  ```C#
  	private static void Client_OnMessagesSent(object sender, MessagesSentEventArgs e)
        {
            // receives multiple messages
        }

        private static void Client_OnServerConnectionFail(object sender, ServerConnectErrorEventArgs e)
        {
           // gsm port connection failed
        }

        private static void Client_OnMessageSendingFailed(object sender, MessageSendingFailedEventArgs e)
        {
            // failed messages
        }

        private static void Client_OnMessageSent(object sender, MessageSentEventArgs e)
        {
            // received single message
        }
        private static void Client_OnServerConnected(object sender, SmsServerConnected e)
        {
            // gsm connection established
        }


  ```
        
