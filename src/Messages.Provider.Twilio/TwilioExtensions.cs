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
        /// <param name="configuration">The configuration section containing Twilio-related settings.</param>
        public static void AddTwilioMessageService(this IServiceCollection services, IConfiguration configuration)
        {
            // Adds messaging-related services using the base extension method.
            services.AddMessageServices();

            // Adds a transient instance of IMessageProcessorProvider using TwilioProcessorProvider implementation.
            services.AddTransient<IMessageProcessorProvider, TwilioProcessorProvider>();

            //Add twilio configuration
            services.AddTwilioConfiguration(configuration);

            // Adds a transient instance of TwilioProcessor.
            services.AddTransient<TwilioProcessor>();

            // Adds a transient instance of MessageResourceFactory.
            services.AddTransient<MessageResourceFactory>();
        }

        private static void AddTwilioConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Configures TwilioOptions using the provided configuration section.
            // Check if the configuration section for TwilioOptions exists.
            IConfigurationSection twilioOptionsSection = configuration.GetSection(nameof(TwilioOptions));
            if (twilioOptionsSection == null)
            {
                throw new InvalidOperationException($"Configuration section '{nameof(TwilioOptions)}' is missing.");
            }

            services.Configure<TwilioOptions>(twilioOptionsSection);

            // Adds a singleton instance of TwilioOptions using the value resolved from IOptions<TwilioOptions>.
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<TwilioOptions>>().Value);
        }
    }
}
