# Message-Kit

1) Add Environment Variables starting with 'Twilio_'.
2) Configure your app to fetch environment variables using AddEnvironmentVariables(prefix: "Twilio_")
3) Call extension method AddTwilioMessageService() to configure twilio services.
4) Inject 'IMessageProcessorFactory' wherever you want to use twilio service.
5) Create 'IMessageProcessor' from 'IMessageProcessorFactory'. Then use 'IMessageProcessor' to send message.
    IMessageProcessor? messageProcessor = _factory.Create(MessageProcessingProvider.Twilio);
    messageProcessor?.SendSMS();