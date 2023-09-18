namespace Messages.Core
{
    /// <summary>
    /// Represents a factory for creating instances of message processors.
    /// </summary>
    public interface IMessageProcessorFactory
    {
        /// <summary>
        /// Creates an instance of a message processor based on the message processing provider.
        /// </summary>
        /// <param name="messageProcessingProvider">The message processing provider to use for creating the message processor.</param>
        /// <returns>An instance of <see cref="IMessageProcessor"/> representing the created message processor.</returns>
        public IMessageProcessor Create(MessageProcessingProvider messageProcessingProvider);
    }
}