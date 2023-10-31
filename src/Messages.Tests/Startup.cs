using Messages.Provider.Twilio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Messages.Tests
{
    /// <summary>
    /// Startup class for test library
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configure host for test library
        /// </summary>
        /// <param name="hostBuilder"></param>
        public void ConfigureHost(IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureAppConfiguration(configBuilder => configBuilder.SetBasePath(Directory.GetCurrentDirectory())
                                                                                .AddJsonFile("appsettings.json", false)
                                                                                .AddEnvironmentVariables(prefix: "Twilio_"));
        }

        /// <summary>
        /// Configure services for test library
        /// </summary>
        /// <param name="services"></param>
        /// <param name="context"></param>
        public void ConfigureServices(IServiceCollection services, HostBuilderContext context)
        {
            services.AddTwilioMessageService(context.Configuration);
        }
    }
}

