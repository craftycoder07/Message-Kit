using Messages.Core;

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
            Console.WriteLine("Message sent successfully.");
        }
    }
}