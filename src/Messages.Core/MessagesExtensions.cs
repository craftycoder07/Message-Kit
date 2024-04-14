using Microsoft.Extensions.DependencyInjection;

namespace Messages.Core
{
    /// <summary>
    /// Contains extension methods to configure payment-related services in the service collection.
    /// </summary>
    public static class MessagesExtensions
    {
        /// <summary>
        /// Adds message-related services to the specified <paramref name="services"/> collection.
        /// </summary>
        /// <param name="services">The service collection to which message services will be added.</param>
        public static void AddMessageServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services), $"No container found for registering and resolving services.");
            }

            // Adds a singleton instance of MessageProcessorFactory.
            services.AddSingleton<MessageProcessorFactory>();
        }
    }
}