using Messages.Core;
using Messages.Core.Exceptions;
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
        /// <param name="fromPhoneNumber">The phone number from which SMS is to be sent.</param>
        /// <param name="toPhoneNumber">The destination phone number.</param>
        /// <param name="messageBody">The body of the SMS message.</param>
        /// <returns>A result indicating the success or failure of the SMS sending operation.</returns>
        /// <exception cref="MessageSendException">Thrown when Message Processor API request is successful but error occurred during the sending of the SMS.</exception>
        /// <exception cref="MessageProcessorApiException">Thrown when Message Processor API request is NOT successfult during the sending of the SMS.</exception>
        public SendMessageResult SendSMS(string fromPhoneNumber, string toPhoneNumber, string messageBody)
        {
            ValidateInputParametersForSendingSMS(toPhoneNumber, fromPhoneNumber, messageBody);

            PhoneNumber twilioFromPhoneNumber = new PhoneNumber(fromPhoneNumber);
            CreateMessageOptions messageOptions = new CreateMessageOptions(new PhoneNumber(toPhoneNumber))
            {
                From = twilioFromPhoneNumber,
                Body = messageBody
            };

            MessageResource message;
            try
            {
                message = MessageResource.Create(messageOptions);
            }
            catch (Exception ex)
            {
                throw new MessageProcessorApiException($"Error in sending twilio message", MessageProcessor.Twilio, ex);
            }

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

        private void ValidateInputParametersForSendingSMS(string toPhoneNumber, string fromPhoneNumber, string messageBody)
        {
            if (string.IsNullOrWhiteSpace(toPhoneNumber))
            {
                throw new ArgumentNullException(nameof(toPhoneNumber), $"To phone number is null or empty.");
            }

            if (string.IsNullOrWhiteSpace(fromPhoneNumber))
            {
                throw new ArgumentNullException(nameof(toPhoneNumber), $"From phone number is not configured.");
            }

            if (string.IsNullOrWhiteSpace(messageBody))
            {
                throw new ArgumentNullException(nameof(messageBody), $"Message body is null or empty.");
            }
        }
    }
}