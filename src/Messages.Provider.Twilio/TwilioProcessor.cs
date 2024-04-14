using Messages.Core;
using Messages.Core.Model;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Messages.Provider.Twilio
{
    /// <summary>
    /// Represents a message processor for sending messages using twilio.
    /// </summary>
    internal class TwilioProcessor : IMessageProcessor
    {
        private readonly TwilioOptions _twilioOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="TwilioProcessor"/> class with the specified Twilio options.
        /// </summary>
        /// <param name="twilioOptions">The Twilio options used for configuration.</param>
        public TwilioProcessor(TwilioOptions twilioOptions)
        {
            _twilioOptions = twilioOptions ?? throw new ArgumentNullException(nameof(twilioOptions), $"Twilio is no configured.");
            TwilioClient.Init(_twilioOptions.AccountSid, _twilioOptions.AuthToken);
        }

        /// <summary>
        /// Sends an SMS message using the configured Twilio options.
        /// </summary>
        /// <param name="toPhoneNumber">The destination phone number.</param>
        /// <param name="messageBody">The body of the SMS message.</param>
        /// <returns>A result indicating the success or failure of the SMS sending operation.</returns>
        public SendMessageResult SendSMS(string toPhoneNumber, string messageBody)
        {
            PhoneNumber fromPhoneNumber = new PhoneNumber(_twilioOptions.PhoneNumber);
            CreateMessageOptions messageOptions = new CreateMessageOptions(new PhoneNumber(toPhoneNumber))
            {
                From = fromPhoneNumber,
                Body = messageBody
            };

            MessageResource message = MessageResource.Create(messageOptions);

            SendMessageResult sendMessageResult = new SendMessageResult();

            if (message.Status == MessageResource.StatusEnum.Failed ||
                message.Status == MessageResource.StatusEnum.Canceled)
            {
                sendMessageResult.IsSuccessful = false;
                sendMessageResult.ErrorMessage = message.ErrorMessage;
            }
            else
            {
                sendMessageResult.IsSuccessful = true;
            }

            return sendMessageResult;
        }
    }
}