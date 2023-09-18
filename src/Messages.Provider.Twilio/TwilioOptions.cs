namespace Messages.Provider.Twilio
{
    /// <summary>
    /// Represents options related to Twilio configuration.
    /// </summary>
    internal class TwilioOptions
    {
        /// <summary>
        /// Gets or sets the base URL for Twilio configuration.
        /// </summary>
        public required string BaseURL { get; set; }
    }

}