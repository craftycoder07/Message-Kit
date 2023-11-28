using Twilio.Rest.Api.V2010.Account;

namespace Messages.Provider.Twilio
{
    /// <summary>
    /// Factory class responsible for creating instances of Twilio MessageResource.
    /// </summary>
    public class MessageResourceFactory
    {
        /// <summary>
        /// Creates a new instance of Twilio MessageResource based on the provided options.
        /// </summary>
        /// <param name="options">The options used to configure the creation of the MessageResource.</param>
        /// <returns>An instance of Twilio MessageResource created with the provided options.</returns>
        public MessageResource Create(CreateMessageOptions options)
        {
            // Use Twilio API or a mock to create a MessageResource
            return MessageResource.Create(options);
        }
    }
}
