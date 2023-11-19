using Messages.Core.Model;

namespace Messages.Core.Exceptions
{
    /// <summary>
    /// Represents an exception specific to errors that is thrown when calling respective Message Processor API.
    /// </summary>
    public class MessageProcessorApiException : MessageKitException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageProcessorApiException"/> class with the specified Message Processor.
        /// </summary>
        /// <param name="messageProcessor">The associated Message Processor causing the exception.</param>
        public MessageProcessorApiException(MessageProcessor messageProcessor) : base(messageProcessor) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageProcessorApiException"/> class with a specified error message and Message Processor.
        /// </summary>
        /// <param name="message">The error message describing the API exception.</param>
        /// <param name="messageProcessor">The associated Message Processor causing the exception.</param>
        public MessageProcessorApiException(string message, MessageProcessor messageProcessor) : base(message, messageProcessor) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageProcessorApiException"/> class with a specified error message, Message Processor, and inner exception.
        /// </summary>
        /// <param name="message">The error message describing the API exception.</param>
        /// <param name="messageProcessor">The associated Message Processor causing the exception.</param>
        /// <param name="ex">The inner exception that caused this API exception.</param>
        public MessageProcessorApiException(string message, MessageProcessor messageProcessor, Exception ex) : base(message, messageProcessor) { }
    }
}
