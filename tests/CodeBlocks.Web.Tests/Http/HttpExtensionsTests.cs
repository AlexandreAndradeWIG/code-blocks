using CodeBlocks.Web.Http.Extensions;
using System;
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
        [InlineData("https://_unexistent_/api/users/2")]
        public async void GetJsonAsync_Request_Error(string url)
        {
            await Assert.ThrowsAsync<HttpRequestException>(async () => await _httpClient.GetJsonAsync<object>(url, true));
        }

        [Theory]
        [InlineData("https://reqres.in/api/users/2")]
        public async void GetJsonAsync_Response_Successfull(string url)
        {
            var result = await _httpClient.GetJsonAsync<object>(url, true);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("https://httpstat.us/400")]
        [InlineData("https://httpstat.us/404")]
        public async void GetJsonAsync_Response_Not_Successfull_NotThrow(string url)
        {
            var result = await _httpClient.GetJsonAsync<object>(url);
            Assert.Null(result);
        }

        [Theory]
        [InlineData("https://httpstat.us/400")]
        [InlineData("https://httpstat.us/404")]
        public async void GetJsonAsync_Response_Not_Successfull_Throw(string url)
        {
            await Assert.ThrowsAsync<Exception>(async () => await _httpClient.GetJsonAsync<object>(url, true));
        }

        [Theory]
        [InlineData("https://httpstat.us/401")]
        public async void GetJsonAsync_Response_Not_Successfull_Throw_Unauthorized(string url)
        {
            await Assert.ThrowsAsync<UnauthorizedAccessException>(async () => await _httpClient.GetJsonAsync<object>(url, true));
        }






        [Theory]
        [InlineData("https://_unexistent_/api/users/2")]
        public async void PostJsonAsync_Request_Error(string url)
        {
            await Assert.ThrowsAsync<HttpRequestException>(async () => await _httpClient.PostJsonAsync<object>(url, true));
        }

        [Theory]
        [InlineData("https://reqres.in/api/users/2")]
        public async void PostJsonAsync_Response_Successfull(string url)
        {
            var result = await _httpClient.PostJsonAsync<object>(url, null);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("https://reqres.in/api/users/2")]
        public async void PostJsonAsync_Response_Successfull_With_Data(string url)
        {
            var request = new
            {
                Foo = "bar"
            };
            var result = await _httpClient.PostJsonAsync<object>(url, request);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("https://httpstat.us/400")]
        [InlineData("https://httpstat.us/404")]
        public async void PostJsonAsync_Response_Not_Successfull_NotThrow(string url)
        {
            var result = await _httpClient.PostJsonAsync<object>(url);
            Assert.Null(result);
        }

        [Theory]
        [InlineData("https://httpstat.us/400")]
        [InlineData("https://httpstat.us/404")]
        public async void PostJsonAsync_Response_Not_Successfull_Throw(string url)
        {
            await Assert.ThrowsAsync<Exception>(async () => await _httpClient.PostJsonAsync<object>(url, null, true));
        }

        [Theory]
        [InlineData("https://httpstat.us/401")]
        public async void PostJsonAsync_Response_Not_Successfull_Throw_Unauthorized(string url)
        {
            await Assert.ThrowsAsync<UnauthorizedAccessException>(async () => await _httpClient.PostJsonAsync<object>(url, null, true));
        }
    }
}
