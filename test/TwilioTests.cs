using Messages.Core;
using Messages.Core.Model;

namespace Messages.Tests.Twilio;

/// <summary>
/// This class tests message func using twilio
/// </summary>
public class TwilioTests
{
    private readonly MessageProcessorFactory _factory;
    private readonly MessageProcessor _messageProcessor = MessageProcessor.Twilio;

    /// <summary>
    /// Constructor that takes ImessageProcessorFactory
    /// </summary>
    /// <param name="factory"></param>
    public TwilioTests(MessageProcessorFactory factory)
    {
        _factory = factory;
    }

    /// <summary>
    /// Test successful sms sending.
    /// </summary>
    [Theory]
    [InlineData("+15519984026", "Hello World")]
    public void SendSMS_Successful(string toNumber, string messageBody)
    {
        //Arrange
        IMessageProcessor? messageProcessor = _factory.Create(_messageProcessor);

        //Act
        SendMessageResult? sendMessageResult = messageProcessor?.SendSMS(toNumber, messageBody);

        //Assert
        Assert.True(sendMessageResult != null && sendMessageResult.IsSuccessful == true);
    }

    /// <summary>
    /// Test parameter validation.
    /// </summary>
    [Theory]
    [InlineData("", "Hello World")]
    [InlineData(null, "Hello World")]
    [InlineData("+15519984026", "")]
    [InlineData("+15519984026", null)]
    public void SendSMS_UnSuccessful_Incorrect_Parameters(string toNumber, string messageBody)
    {
        //Arrange
        IMessageProcessor? messageProcessor = _factory.Create(_messageProcessor);

        //Act & Assert
        Assert.Throws<ArgumentNullException>(() => messageProcessor?.SendSMS(toNumber, messageBody));
    }
}