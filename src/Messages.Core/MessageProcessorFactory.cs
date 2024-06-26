using Messages.Core.Model;

namespace Messages.Core
{
    /// <summary>
    /// Represents a factory for creating message processors based on different message processor providers.
    /// </summary>
    public sealed class MessageProcessorFactory
    {
        private readonly IEnumerable<IMessageProcessorProvider> _messageProcessorProviders;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageProcessorFactory"/> class.
        /// </summary>
        /// <param name="messageProcessorProviders">A collection of message processor providers.</param>
        public MessageProcessorFactory(IEnumerable<IMessageProcessorProvider> messageProcessorProviders)
        {
            _messageProcessorProviders = messageProcessorProviders ?? throw new ArgumentNullException(nameof(messageProcessorProviders), $"Please register at least one IMessageProcessorProvider.");
        }

        /// <summary>
        /// Creates an instance of a message processor based on the specified message processing provider.
        /// </summary>
        /// <param name="messageProcessor">The message processing provider that determines the type of message processor to create.</param>
        /// <returns>An instance of <see cref="IMessageProcessor"/> representing the created message processor.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when no suitable IMessageProcessorProvider is found for the provided MessageProcessor.
        /// </exception>
        public IMessageProcessor? Create(MessageProcessor messageProcessor)
        {
            IMessageProcessorProvider? provider = _messageProcessorProviders.FirstOrDefault(x => x.MessageProcessor == messageProcessor);

            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider), $"No MessageProcessorProvider found for {messageProcessor}.");
            }

            return provider.CreateMessageProcessor();
        }
    }
}