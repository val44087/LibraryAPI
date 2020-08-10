using LibraryApi;
using LibraryApi.Services;
using LibraryApiIntegrationTests.Fakes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApiIntegrationTests
{
    public class WebTestFixture : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {
                // reach into the configured services and find the one for ISystemTime
                var systemTimeDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(ISystemTime));

                if (systemTimeDescriptor != null)
                {
                    services.Remove(systemTimeDescriptor);
                    services.AddTransient<ISystemTime, TestingSystemTime>();
                }

            });
        }
    }
}