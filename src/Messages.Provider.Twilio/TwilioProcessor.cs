using Messages.Core;
using Microsoft.Extensions.Logging;
using Twilio;
using Twilio.Exceptions;
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

            try
            {
                TwilioClient.Init(_twilioOptions.AccountSid, _twilioOptions.AuthToken);
                _logger.LogInformation("Twilio client initialized successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to initialize Twilio client.");
                throw;
            }
        }

        /// <summary>
        /// Sends SMS using the configured Twilio options.
        /// </summary>
        public void SendSMS(string toPhoneNumber, string messageBody)
        {
            try
            {
                PhoneNumber fromPhoneNumber = new PhoneNumber(_twilioOptions.PhoneNumber);
                CreateMessageOptions messageOptions = new CreateMessageOptions(new PhoneNumber(toPhoneNumber))
                {
                    From = fromPhoneNumber,
                    Body = messageBody
                };

                MessageResource message = MessageResource.Create(messageOptions);
                _logger.LogInformation("SMS sent successfully.");
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "Twilio API Exception while sending SMS.");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while sending SMS.");
                throw;
            }
        }
    }
}