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
        public void SendSMS(string toPhoneNumber, string messageBody);
    }
}