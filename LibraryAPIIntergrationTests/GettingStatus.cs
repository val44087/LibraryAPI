using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryAPIIntergrationTests
{
    public class GettingStatus : IClassFixture<WebTestFixture>

    {
        private HttpClient Client;

        public GettingStatus(WebTestFixture factory)
        {
            this.Client = factory.CreateClient();
        }
        [Fact]
        public async Task CanGetTheStatus()
        {
            var response = await Client.GetAsync("/status");
            Assert.True(response.IsSuccessStatusCode);

            var mediaType = response.Content.Headers.ContentType.MediaType;
            Assert.Equal("application/json", mediaType);

            var content = await response.Content.ReadAsAsync<StatusResponse>();

            Assert.Equal("Everything is golden!", content.message);
            Assert.Equal("Joe Schmidtly", content.checkedBy);
        }
    }

    /* {
  "message": "Everything is golden!",
  "checkedBy": "Joe Schmidtly",
  "whenLastChecked": "2020-08-10T18:57:54.1500742+00:00"
}
    */

    public class StatusResponse
    {
        public string message { get; set; }
        public string checkedBy { get; set; }
        public DateTime whenLastChecked { get; set; }
    }
}
