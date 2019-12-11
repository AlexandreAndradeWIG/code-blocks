using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CodeBlocks.Web.Http.Extensions
{
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Makes a GET request and deserializes a Json response to a object of type <typeparamref name="TResponse"/>.
        /// </summary>
        /// <typeparam name="TResponse">Type of the response.</typeparam>
        /// <param name="httpClient">HttpClient</param>
        /// <param name="url">Url for the request.</param>
        /// <param name="throwOnError">If true, the method will throw an Exception when the StatusCode of the response wasn't in 200-299 range.</param>
        /// <returns></returns>
        public static async Task<TResponse> GetJsonAsync<TResponse>(this HttpClient httpClient, string url, bool throwOnError = false)
        {
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                if (throwOnError)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        throw new UnauthorizedAccessException(response.ReasonPhrase);
                    }
                    throw new Exception(response.ReasonPhrase);
                }
                else
                {
                    return default;
                }
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var returnObj = JsonConvert.DeserializeObject<TResponse>(responseContent);

            return returnObj;
        }

        /// <summary>
        /// Makes a GET request and deserializes a Xml response to a object of type <typeparamref name="TResponse"/>.
        /// </summary>
        /// <typeparam name="TResponse">Type of the response.</typeparam>
        /// <param name="httpClient">HttpClient</param>
        /// <param name="url">Url for the request.</param>
        /// <param name="throwOnError">If true, the method will throw an Exception when the StatusCode of the response wasn't in 200-299 range.</param>
        /// <returns></returns>
        public static async Task<TResponse> GetXmlAsync<TResponse>(this HttpClient httpClient, string url, bool throwOnError = false)
        {
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                if (throwOnError)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        throw new UnauthorizedAccessException(response.ReasonPhrase);
                    }
                    throw new Exception(response.ReasonPhrase);
                }
                else
                {
                    return default;
                }
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            XmlSerializer serializer = new XmlSerializer(typeof(TResponse));
            StringReader stringReader = new StringReader(responseContent);
            var returnObj = (TResponse)serializer.Deserialize(stringReader);

            return returnObj;
        }

        /// <summary>
        /// Makes a POST request, optionally passing a Json content, and deserializes a Json response to a object of type <typeparamref name="TResponse"/>.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpClient">HttpClient</param>
        /// <param name="url">Url for the request.</param>
        /// <param name="throwOnError">If true, the method will throw an Exception when the StatusCode of the response wasn't in 200-299 range.</param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<TResponse> PostJsonAsync<TResponse>(this HttpClient httpClient, string url, object request = null, bool throwOnError = false)
        {
            HttpResponseMessage response;
            if (request == null)
            {
                response = await httpClient.PostAsync(url, null);
            }
            else
            {
                var jsonContent = JsonConvert.SerializeObject(request);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                response = await httpClient.PostAsync(url, httpContent);
            }

            if (throwOnError)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException(response.ReasonPhrase);
                }
                throw new Exception(response.ReasonPhrase);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var returnObj = JsonConvert.DeserializeObject<TResponse>(responseContent);

            return returnObj;
        }

        /// <summary>
        /// Makes a PUT request, optionally passing a Json content, and deserializes a Json response to a object of type <typeparamref name="TResponse"/>.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpClient">HttpClient</param>
        /// <param name="url">Url for the request.</param>
        /// <param name="throwOnError">If true, the method will throw an Exception when the StatusCode of the response wasn't in 200-299 range.</param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<TResult> PutJsonAsync<TResult>(this HttpClient httpClient, string url, object request, bool throwOnError = false)
        {
            var jsonContent = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(url, httpContent);

            if (throwOnError)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException(response.ReasonPhrase);
                }
                throw new Exception(response.ReasonPhrase);
            }


            var responseContent = await response.Content.ReadAsStringAsync();
            var returnObj = JsonConvert.DeserializeObject<TResult>(responseContent);

            return returnObj;
        }

        /// <summary>
        /// Makes a DELETE request, optionally passing a Json content, and deserializes a Json response to a object of type <typeparamref name="TResponse"/>.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpClient">HttpClient</param>
        /// <param name="url">Url for the request.</param>
        /// <param name="throwOnError">If true, the method will throw an Exception when the StatusCode of the response wasn't in 200-299 range.</param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<TResult> DeleteJsonAsync<TResult>(this HttpClient httpClient, string url, object request = null, bool throwOnError = false)
        {
            HttpResponseMessage response;
            if (request == null)
            {
                response = await httpClient.DeleteAsync(url);
            }
            else
            {
                var jsonRequest = new HttpRequestMessage(HttpMethod.Delete, url);
                jsonRequest.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                response = await httpClient.SendAsync(jsonRequest);
            }

            if (throwOnError)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException(response.ReasonPhrase);
                }
                throw new Exception(response.ReasonPhrase);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var returnObj = JsonConvert.DeserializeObject<TResult>(responseContent);

            return returnObj;
        }
    }
}
