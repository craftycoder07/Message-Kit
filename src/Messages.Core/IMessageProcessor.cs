namespace Messages.Core
{
    /// <summary>
    /// Represents a type used message transation
    /// </summary>
    public interface IMessageProcessor
    {
        /// <summary>
        /// Sends SMS.
        /// </summary>
        /// <param name="toPhoneNumber">The destination phone number.</param>
        /// <param name="messageBody">The body of the SMS.</param>
        public void SendSMS(string toPhoneNumber, string messageBody);
    }
}