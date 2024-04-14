using Messages.Core.Exceptions;
using Messages.Core.Model;

namespace Messages.Core
{
    /// <summary>
    /// Represents a type used to send a message.
    /// </summary>
    public interface IMessageProcessor
    {
        /// <summary>
        /// Sends SMS.
        /// </summary>
        /// <param name="toPhoneNumber">The destination phone number.</param>
        /// <param name="messageBody">The body of the SMS.</param>
        /// <returns>A result indicating the success or failure of the SMS sending operation.</returns>
        /// <exception cref="MessageSendException">Thrown when Message Processor API request is successful but error occurred during the sending of the SMS.</exception>
        /// <exception cref="MessageProcessorApiException">Thrown when Message Processor API request is NOT successfult during the sending of the SMS.</exception>
        public SendMessageResult SendSMS(string toPhoneNumber, string messageBody);
    }
}