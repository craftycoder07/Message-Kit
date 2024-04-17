using Messages.Core;
using Messages.Core.Model;
using Messages.Provider.Twilio;

namespace Messages.Tests.Twilio;

/// <summary>
/// This class tests message func using twilio
/// </summary>
public class TwilioTests
{
    private readonly MessageProcessorFactory _factory;
    private readonly TwilioOptions _twilioOptions;
    private readonly MessageProcessor _messageProcessor = MessageProcessor.Twilio;

    /// <summary>
    /// Constructor that takes ImessageProcessorFactory
    /// </summary>
    /// <param name="factory"></param>
    /// <param name="twilioOptions"></param>
    public TwilioTests(MessageProcessorFactory factory, TwilioOptions twilioOptions)
    {
        _factory = factory;
        _twilioOptions = twilioOptions;
    }

    /// <summary>
    /// Test successful sms sending.
    /// </summary>
    [Theory]
    [InlineData("+15519984026", "Hello World")]
    public void SendSMS_Successful(string toNumber, string messageBody)
    {
        //Arrange
        string fromNumber = _twilioOptions.PhoneNumber;
        IMessageProcessor? messageProcessor = _factory.Create(_messageProcessor);

        //Act
        SendMessageResult? sendMessageResult = messageProcessor?.SendSMS(fromNumber, toNumber, messageBody);

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
        string fromNumber = _twilioOptions.PhoneNumber;
        IMessageProcessor? messageProcessor = _factory.Create(_messageProcessor);

        //Act & Assert
        Assert.Throws<ArgumentNullException>(() => messageProcessor?.SendSMS(fromNumber, toNumber, messageBody));
    }
}