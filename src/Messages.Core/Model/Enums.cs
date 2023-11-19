namespace Messages.Core.Model
{
    /// <summary>
    /// Supported message processing providers.
    /// </summary>
    public enum MessageProcessor : byte
    {
        /// <summary>
        /// Represents the Twilio message processing provider.
        /// </summary>
        Twilio = 1
    }

    /// <summary>                                       
    /// Enum representing the result of a message processing operation.
    /// </summary>
    public enum SendMessageStatus : byte
    {
        /// <summary>
        /// Indicates that the message processing was successful.
        /// </summary>
        Successful = 1,

        /// <summary>
        /// Indicates that the message processing failed.
        /// </summary>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
        Failed = 2
    }
}
