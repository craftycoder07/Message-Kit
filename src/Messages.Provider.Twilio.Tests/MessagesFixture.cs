using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;
using Messages.Provider.Twilio;

namespace Messages.Tests
{
    /// <summary>
    /// 
    /// </summary>
    public class MessagesFixture : TestBedFixture
    {
        /// <summary>
        /// asda
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
        {
            if (configuration != null)
            {
                services.AddTwilioMessageService(configuration);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected override ValueTask DisposeAsyncCore()
        {
            return new();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected override IEnumerable<TestAppSettings> GetTestAppSettings()
        {
            yield return new() { Filename = "appsettings.json", IsOptional = true };
        }
    }
}

