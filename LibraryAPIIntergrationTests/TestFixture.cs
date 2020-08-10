using LibraryApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAPIIntergrationTests
{
    public class WebTestFixture : WebApplicationFactory<Startup>
    {        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");
        }

    }
}
