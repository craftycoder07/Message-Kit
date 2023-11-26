using Messages.Core;
using Messages.Core.Model;
using Twilio.Exceptions;

namespace Messages.Tests.Twilio;

/// <summary>
/// This class tests message func using twilio
/// </summary>
public class TwilioTests
{
    private readonly IMessageProcessorFactory _factory;
    private readonly MessageProcessor _messageProcessor = MessageProcessor.Twilio;

    /// <summary>
    /// Constructor that takes ImessageProcessorFactory
    /// </summary>
    /// <param name="factory"></param>
    public TwilioTests(IMessageProcessorFactory factory)
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
        messageProcessor?.SendSMS(toNumber, messageBody);

        //Assert
        // If no error, then automatically successful.
    }

    /// <summary>
    /// Test unsuccessful sms sending.
    /// </summary>
    [Theory]
    [InlineData("", "Hello World")]
    [InlineData("+12345678912", "Hello World")]
    [InlineData("+15519984026", "")]
    [InlineData("+15519984026", null)]
    public void SendSMS_UnSuccessful(string toNumber, string messageBody)
    {
        //Arrange
        IMessageProcessor? messageProcessor = _factory.Create(_messageProcessor);

        //Act & Assert
        Assert.Throws<ApiException>(() => messageProcessor?.SendSMS(toNumber, messageBody));
    }
}