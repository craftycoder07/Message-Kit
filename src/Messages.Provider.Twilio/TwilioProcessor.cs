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
        }

        /// <summary>
        /// Sends SMS using the configured Twilio options.
        /// </summary>
        public void SendSMS()
        {
            TwilioClient.Init(_twilioOptions.AccountSid, _twilioOptions.AuthToken);

            CreateMessageOptions messageOptions = new CreateMessageOptions(
              new PhoneNumber("+15519984026"));
            messageOptions.From = new PhoneNumber(_twilioOptions.PhoneNumber);
            messageOptions.Body = "Hi";

            MessageResource message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);
        }
    }
}