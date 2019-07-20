using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CapsuleDotNet.Common;
using CapsuleDotNet.Models;
using Newtonsoft.Json;

namespace CapsuleDotNet
{
    public static class CapsuleClient
    {
        private static HttpClient _httpClient;
        private static bool _isInit;

        public static bool Init(string apiKey)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.capsulecrm.com/api/v2/");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var response = _httpClient.GetAsync("countries").Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new ArgumentException("Invalid API Key");
            }
            else
            {
                _isInit = true;

                var responseContent = response.Content.ReadAsStringAsync().Result;

                Countries.CountryList = JsonConvert.DeserializeObject<CountryWrapper>(responseContent).Countries.Select(p => p.Name).AsQueryable();
            }

            return true;
        }

        internal async static Task<T> baseGetRequest<T>(string endpoint, DateTime? since, int page, int perPage, EmbedEnum[] embed) where T : DefaultObjectWrapper {
            var requestString = new StringBuilder($"{endpoint}?");

            if (page < 1) {
                page = 1;
            }

            requestString.Append($"page={page}&");

            if (perPage > 100){
                perPage = 100;
            }

            requestString.Append($"perPage={perPage}&");

            if (since != null && since.HasValue){
                requestString.Append($"since={since.Value.ToString("yyyy-MM-dd")}");
            }

            if (embed != null && embed.Length > 0){
                requestString.Append($"embed={string.Join(",", embed)}");
            }

            return await CapsuleClient.makeRequest<T>(requestString.ToString(), "GET");
        }

        internal async static Task<T> makeRequest<T>(string endpoint, string method, object body = null) where T : DefaultObjectWrapper
        {
            HttpResponseMessage responseMessage = null;
            HttpContent content = null;
            T responseObject = null;

            if (body != null)
            {
                content = new StringContent(JsonConvert.SerializeObject(body));
            }

            switch (method.ToLower())
            {
                case "get":
                    responseMessage = await _httpClient.GetAsync(endpoint.ToLower());
                    break;
                case "put":
                    responseMessage = await _httpClient.PutAsync(endpoint.ToLower(), content);
                    break;
                case "post":
                    responseMessage = await _httpClient.PostAsync(endpoint.ToLower(), content);
                    break;
                case "delete":
                    responseMessage = await _httpClient.DeleteAsync(endpoint.ToLower());
                    break;
            }

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                responseObject = JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync());

                if (responseMessage.Headers.Any(p => p.Key == "Link")){
                    responseObject.Pagination.Parse(responseMessage.Headers.FirstOrDefault(p => p.Key == "Link").Value);
                }
            };

            return responseObject;
        }
    }
}
