namespace Messages.Core
{
    /// <summary>
    /// Represents a factory for creating instances of message processors.
    /// </summary>
    public interface IMessageProcessorFactory
    {
        /// <summary>
        /// Creates an instance of a message processor based on the specified message processing provider.
        /// </summary>
        /// <param name="messageProcessor">The message processor that determines the type of message processor to create.</param>
        /// <returns>An instance of <see cref="IMessageProcessor"/> representing the created message processor. Returns null if no matching provider is found.</returns>
        public IMessageProcessor? Create(MessageProcessor messageProcessor);
    }
}