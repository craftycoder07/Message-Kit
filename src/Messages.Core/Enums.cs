namespace Messages.Core
{
    /// <summary>
    /// Supported message processing providers.
    /// </summary>
    public enum MessageProcessingProvider : byte
    {
        /// <summary>
        /// Represents the Stripe message processing provider.
        /// </summary>
        Twilio = 1
    }
}