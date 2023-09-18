namespace Messages.Core
{
    /// <summary>
    /// Represents a provider for creating instances of message processors.
    /// </summary>
    public interface IMessageProcessorProvider
    {
        /// <summary>
        /// Gets or sets the message processing provider associated with this processor provider.
        /// </summary>
        MessageProcessingProvider MessageProcessingProvider { get; set; }

        /// <summary>
        /// Creates an instance of a message processor using the provided service provider.
        /// </summary>
        /// <returns>An instance of <see cref="IMessageProcessor"/> representing the created message processor.</returns>
        IMessageProcessor CreateMessageProcessor();
    }
}