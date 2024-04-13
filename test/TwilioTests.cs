using Messages.Core;
using Messages.Core.Model;
using Twilio.Exceptions;

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

    ///// <summary>
    ///// 
    ///// </summary>
    //[Fact]
    //public void SendSMS_Unsuccessful()
    //{
    //    IMessageProcessor? messageProcessor = _factory.Create(_messageProcessor);

    //    Mock<MessageResource> messageResourceMock = new Mock<MessageResource>();
    //    //messageResourceMock.Setup(x => x.Status).Returns(MessageResource.StatusEnum.Failed);
    //    //messageResourceMock.Setup(x => x.ErrorMessage).Returns("Failed to send message");
    //    messageResourceMock.Setup(x => MessageResource.Create(() => ))

    //    Mock<MessageResourceWrapper> messageResourceWrapper = new Mock<MessageResourceWrapper>();
    //    messageResourceWrapper.Setup(x => x.CreateMethod(It.IsAny<CreateMessageOptions>())).Returns(10);

    //    // Arrange
    //    Mock<TwilioOptions> twilioOptionsMock = new Mock<TwilioOptions>();
    //    twilioOptionsMock.SetupGet(x => x.AccountSid).Returns("your_account_sid");
    //    twilioOptionsMock.SetupGet(x => x.AuthToken).Returns("your_auth_token");
    //    twilioOptionsMock.SetupGet(x => x.PhoneNumber).Returns("your_phone_number");

    //    Mock<MessageResource> messageResourceMock = new Mock<MessageResource>();
    //    messageResourceMock.SetupGet(x => x.Status).Returns(MessageResource.StatusEnum.Failed);
    //    messageResourceMock.SetupGet(x => x.ErrorMessage).Returns("Failed to send message");

    //    Mock<ITwilioRestClient> twilioClientMock = new Mock<ITwilioRestClient>();
    //    twilioClientMock.SetupGet(x => x.AccountSid).Returns("your_account_sid");

    //    var twilioRestClientFactoryMock = new Mock<ITwilioRestClientFactory>();
    //    twilioRestClientFactoryMock.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>())).Returns(twilioClientMock.Object);

    //    var twilioRestClientProviderMock = new Mock<ITwilioRestClientProvider>();
    //    twilioRestClientProviderMock.Setup(x => x.GetRestClient()).Returns(twilioClientMock.Object);

    //    var twilioProcessor = new TwilioProcessor(
    //        twilioOptionsMock.Object,
    //        messageResourceFactoryMock.Object,
    //        twilioRestClientFactoryMock.Object,
    //        twilioRestClientProviderMock.Object
    //    );

    //    // Act
    //    var result = twilioProcessor.SendSMS("+15519984026", "Hello World");

    //    // Assert
    //    Assert.False(result.IsSuccessful);
    //    Assert.Equal("Failed to send message", result.ErrorMessage);
    //}

    ///// <summary>
    ///// 
    ///// </summary>
    //public class MessageResourceWrapper
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <returns></returns>
    //    public virtual MessageResource CreateMethod(CreateMessageOptions messageOptions)
    //    {
    //        return MessageResource.Create(messageOptions);
    //    }
    //}
}