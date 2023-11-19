using Messages.Core.Model;

namespace Messages.Core.Exceptions
{
    /// <summary>
    /// Represents an exception specific to errors that occur during the sending of a message.
    /// </summary>
    public class MessageSendException : MessageKitException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageSendException"/> class with the specified Message Processor.
        /// </summary>
        /// <param name="messageProcessor">The associated Message Processor involved in the message sending.</param>
        public MessageSendException(MessageProcessor messageProcessor) : base(messageProcessor) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageSendException"/> class with a specified error message and Message Processor.
        /// </summary>
        /// <param name="message">The error message describing the message sending exception.</param>
        /// <param name="messageProcessor">The associated Message Processor involved in the message sending.</param>
        public MessageSendException(string message, MessageProcessor messageProcessor) : base(message, messageProcessor) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageSendException"/> class with a specified error message, Message Processor, and inner exception.
        /// </summary>
        /// <param name="message">The error message describing the message sending exception.</param>
        /// <param name="messageProcessor">The associated Message Processor involved in the message sending.</param>
        /// <param name="ex">The inner exception that caused this message sending exception.</param>
        public MessageSendException(string message, MessageProcessor messageProcessor, Exception ex) : base(message, messageProcessor) { }
    }
}
