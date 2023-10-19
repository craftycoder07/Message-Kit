using Messages.Core;
using Messages.Tests;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace Messages.Provider.Twilio.Tests;

/// <summary>
/// This class tests message func using twilio
/// </summary>
public class TwilioTests : TestBed<MessagesFixture>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="testOutputHelper"></param>
    /// <param name="fixture"></param>
    public TwilioTests(ITestOutputHelper testOutputHelper, MessagesFixture fixture) : base(testOutputHelper, fixture)
    {
    }

    /// <summary>
    /// Test sms sending.
    /// </summary>
    [Fact]
    public void SendSMS_Test()
    {
        IMessageProcessorFactory? factory = _fixture.GetService<IMessageProcessorFactory>(_testOutputHelper);
        IMessageProcessor? messageProcessor = factory?.Create(MessageProcessingProvider.Twilio);
        messageProcessor?.SendSMS();
    }
}