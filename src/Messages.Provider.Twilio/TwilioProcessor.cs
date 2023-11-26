using Messages.Core;
using Messages.Core.Exceptions;
using Messages.Core.Model;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<TwilioProcessor> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TwilioProcessor"/> class with the specified Twilio options.
        /// </summary>
        /// <param name="twilioOptions">The Twilio options used for configuration.</param>
        /// <param name="logger">The logger.</param>
        public TwilioProcessor(TwilioOptions twilioOptions, ILogger<TwilioProcessor> logger)
        {
            _twilioOptions = twilioOptions;
            _logger = logger;

            TwilioClient.Init(_twilioOptions.AccountSid, _twilioOptions.AuthToken);
        }

        /// <summary>                 
        /// Sends SMS using the configured Twilio options.
        /// </summary>
        public void SendSMS(string toPhoneNumber, string messageBody)
        {
            PhoneNumber fromPhoneNumber = new PhoneNumber(_twilioOptions.PhoneNumber);
            CreateMessageOptions messageOptions = new CreateMessageOptions(new PhoneNumber(toPhoneNumber))
            {
                From = fromPhoneNumber,
                Body = messageBody
            };

            MessageResource? message = null;

            message = MessageResource.Create(messageOptions);

            if (message?.Status == MessageResource.StatusEnum.Failed || message?.Status == MessageResource.StatusEnum.Canceled)
            {
                throw new MessageSendException($"Error Status -> {message.Status}, Error Message -> {message.ErrorMessage}", MessageProcessor.Twilio);
            }
        }
    }
}