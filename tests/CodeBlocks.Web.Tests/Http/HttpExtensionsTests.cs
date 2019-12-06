using CodeBlocks.Web.Http.Extensions;
using System.Net.Http;
using Xunit;

namespace CodeBlocks.Web.Tests.Http
{
    public class HttpExtensionsTests
    {
        private readonly HttpClient _httpClient;

        public HttpExtensionsTests()
        {
            _httpClient = new HttpClient();
        }


        [Theory]
        [InlineData("https://reqres.in/api/users/2")]
        public async void GetJsonAsync(string url)
        {
            var result = await _httpClient.GetJsonAsync<object>(url, true);

        }
    }
}
