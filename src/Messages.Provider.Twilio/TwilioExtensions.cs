using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Messages.Core;

namespace Messages.Provider.Twilio
{
    /// <summary>
    /// Contains extension methods to configure Twilio related services in the service collection.
    /// </summary>
    public static class TwilioExtensions
    {
        /// <summary>
        /// Adds Twilio related services to the specified <paramref name="services"/> collection using the provided Twilio configuration.
        /// </summary>
        /// <param name="services">The service collection to which Twilio services will be added.</param>
        /// <param name="twilioConfigurationSection">The configuration section containing Twilio-related settings.</param>
        public static void AddTwilioMessageService(this IServiceCollection services, IConfiguration twilioConfigurationSection)
        {
            // Adds messaging-related services using the base extension method.
            services.AddMessageServices();

            // Adds a transient instance of IMessageProcessorProvider using TwilioProcessorProvider implementation.
            services.AddTransient<IMessageProcessorProvider, TwilioProcessorProvider>();

            // Configures TwilioOptions using the provided configuration section.
            services.Configure<TwilioOptions>(twilioConfigurationSection.GetSection("TwilioOptions"));

            // Adds a singleton instance of TwilioOptions using the value resolved from IOptions<TwilioOptions>.
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<TwilioOptions>>().Value);

            // Adds a transient instance of TwilioProcessor.
            services.AddTransient<TwilioProcessor>();
        }
    }
}
