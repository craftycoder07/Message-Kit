using Messages.Core.Model;

namespace Messages.Core.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageKitException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public MessageProcessor MessageProcessor { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageProcessor"></param>
        public MessageKitException(MessageProcessor messageProcessor)
        {
            MessageProcessor = messageProcessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageProcessor"></param>
        public MessageKitException(string message, MessageProcessor messageProcessor) : base(message)
        {
            MessageProcessor = messageProcessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageProcessor"></param>
        /// <param name="ex"></param>
        public MessageKitException(string message, MessageProcessor messageProcessor, Exception ex) : base(message, ex)
        {
            MessageProcessor = messageProcessor;
        }
    }
}
