using Messages.Core;
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
            _twilioOptions = twilioOptions;
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

            MessageResource message = MessageResource.Create(messageOptions);
        }
    }
}