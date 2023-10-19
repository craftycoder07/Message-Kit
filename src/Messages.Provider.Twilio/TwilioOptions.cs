namespace Messages.Provider.Twilio
{
    /// <summary>
    /// Represents options related to Twilio configuration.
    /// </summary>
    internal class TwilioOptions
    {
        /// <summary>
        /// Gets or sets the AccountSID for Twilio configuration.
        /// </summary>
        public required string AccountSid { get; set; }

        /// <summary>
        /// Gets or sets the authentication token for Twilio configuration.
        /// </summary>
        public required string AuthToken { get; set; }

        /// <summary>
        /// Gets or sets twilio phone number.
        /// </summary>
        public required string PhoneNumber { get; set; }
    }
}