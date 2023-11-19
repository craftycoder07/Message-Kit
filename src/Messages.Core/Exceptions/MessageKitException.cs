using Messages.Core.Model;

namespace Messages.Core.Exceptions
{
    /// <summary>
    /// Represents a general exception specific to the Message Kit library.
    /// </summary>
    public class MessageKitException : Exception
    {
        /// <summary>
        /// Gets the associated Message Processor that is set when the exception was thrown.
        /// </summary>
        public MessageProcessor MessageProcessor { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageKitException"/> class with the specified Message Processor.
        /// </summary>
        /// <param name="messageProcessor">The associated Message Processor.</param>
        public MessageKitException(MessageProcessor messageProcessor)
        {
            MessageProcessor = messageProcessor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageKitException"/> class with a specified error message and Message Processor.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="messageProcessor">The associated Message Processor.</param>
        public MessageKitException(string message, MessageProcessor messageProcessor) : base(message)
        {
            MessageProcessor = messageProcessor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageKitException"/> class with a specified error message, Message Processor, and inner exception.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="messageProcessor">The associated Message Processor.</param>
        /// <param name="ex">The inner exception that caused this exception.</param>
        public MessageKitException(string message, MessageProcessor messageProcessor, Exception ex) : base(message, ex)
        {
            MessageProcessor = messageProcessor;
        }
    }
}
