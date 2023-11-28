namespace Messages.Core.Model
{
    /// <summary>
    /// Represents the result of a message sending operation.
    /// </summary>
    public class SendMessageResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether the message sending operation was successful.
        /// </summary>
        public bool IsSuccessful { get; set; } = false;

        /// <summary>
        /// Gets or sets the error message if the message sending operation failed.
        /// </summary>
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
