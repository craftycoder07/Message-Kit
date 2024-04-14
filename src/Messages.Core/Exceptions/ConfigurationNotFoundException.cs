using Messages.Core.Model;

namespace Messages.Core
{
    /// <summary>
    /// Represents an exception that is thrown when configuration is not found in appsettings.json.
    /// </summary>
    public class ConfigurationNotFoundException : Exception
    {
        /// <summary>
        /// Gets the associated Message Processor that is set when the exception was thrown.
        /// </summary>
        public MessageProcessor MessageProcessor { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationNotFoundException"/> class with the specified Message Processor.
        /// </summary>
        /// <param name="messageProcessor">The associated Message Processor.</param>
        public ConfigurationNotFoundException(MessageProcessor messageProcessor)
        {
            MessageProcessor = messageProcessor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationNotFoundException"/> class with a specified error message and Message Processor.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="messageProcessor">The associated Message Processor.</param>
        public ConfigurationNotFoundException(string message, MessageProcessor messageProcessor) : base(message)
        {
            MessageProcessor = messageProcessor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationNotFoundException"/> class with a specified error message, Message Processor, and inner exception.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="messageProcessor">The associated Message Processor.</param>
        /// <param name="ex">The inner exception that caused this exception.</param>
        public ConfigurationNotFoundException(string message, MessageProcessor messageProcessor, Exception ex) : base(message, ex)
        {
            MessageProcessor = messageProcessor;
        }
    }
}