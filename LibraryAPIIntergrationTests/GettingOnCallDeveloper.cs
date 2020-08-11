using LibraryApiIntegrationTests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryAPIIntergrationTests
{
    public class GettingOnCallDeveloper : IClassFixture<WebTestFixture>
    {
        private HttpClient Client;

        public GettingOnCallDeveloper(WebTestFixture  fixture)
        {
            Client = fixture.CreateClient();
        }
        [Fact]
        public  async Task CanGetTheOnCallDeveloper()
        {
            var response = await Client.GetAsync("/oncall");
            var content = await response.Content.ReadAsAsync<OnCallDeveloperResponse>();

            Assert.Equal("Shelly Johnson", content.developer);


        }
        public class OnCallDeveloperResponse
        {
            public string developer { get; set; }
        }

    }
}
