using Messages.Core;

namespace Messages.Tests.Twilio;

/// <summary>
/// This class tests message func using twilio
/// </summary>
public class TwilioTests
{
    private readonly IMessageProcessorFactory _factory;

    /// <summary>
    /// Constructor that takes ImessageProcessorFactory
    /// </summary>
    /// <param name="factory"></param>
    public TwilioTests(IMessageProcessorFactory factory)
    {
        _factory = factory;
    }

    /// <summary>
    /// Test sms sending.
    /// </summary>
    [Fact]
    public void SendSMS_Test()
    {
        IMessageProcessor? messageProcessor = _factory.Create(MessageProcessingProvider.Twilio);
        messageProcessor?.SendSMS();
    }
}