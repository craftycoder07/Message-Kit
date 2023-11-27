using Twilio.Rest.Api.V2010.Account;

namespace Messages.Provider.Twilio
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageResourceFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public MessageResource Create(CreateMessageOptions options)
        {
            // Use Twilio API or a mock to create a MessageResource
            return MessageResource.Create(options);
        }
    }
}
