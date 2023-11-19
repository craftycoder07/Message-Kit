using Messages.Core.Model;

namespace Messages.Core.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageSendException : MessageKitException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageProcessor"></param>
        public MessageSendException(MessageProcessor messageProcessor) : base(messageProcessor) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageProcessor"></param>
        public MessageSendException(string message, MessageProcessor messageProcessor) : base(message, messageProcessor) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageProcessor"></param>
        /// <param name="ex"></param>
        public MessageSendException(string message, MessageProcessor messageProcessor, Exception ex) : base(message, messageProcessor) { }
    }
}
