using Microsoft.Extensions.DependencyInjection;
using Messages.Core;

namespace Messages.Provider.Twilio
{
    /// <summary>
    /// Represents a provider for creating Twilio message sending processors.
    /// </summary>
    public class TwilioProcessorProvider : IMessageProcessorProvider
    {
        /// <summary>
        /// Gets or sets the message processor as Twilio.
        /// </summary>
        public MessageProcessor MessageProcessor { get; set; } = MessageProcessor.Twilio;

        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="TwilioProcessorProvider"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider used for dependency injection.</param>
        public TwilioProcessorProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Creates an instance of a Twilio message sending processor using the provided service provider.
        /// </summary>
        /// <returns>An instance of <see cref="IMessageProcessor"/> representing the created Twilio message sending processor.</returns>
        public IMessageProcessor CreateMessageProcessor()
        {
            // Retrieves the required TwilioProcessor instance from the service provider.
            return _serviceProvider.GetRequiredService<TwilioProcessor>();
        }
    }

}