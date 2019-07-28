using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CapsuleDotNet.Common;
using CapsuleDotNet.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CapsuleDotNet
{
    public static class CapsuleClient
    {
        private static HttpClient _httpClient;
        private static bool _isInit;

        internal static void IsInit(){
            if (CapsuleClient._isInit == false)
            {
                throw new Exception("Capsule client must first be initialised with a valid API key");
            }
        }

        public static bool Init(string apiKey)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.capsulecrm.com/api/v2/");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

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

        internal async static Task<T> baseGetRequest<T>(string endpoint, DateTime? since, int page, int perPage, Embed[] embed) where T : DefaultObjectWrapper
        {
            var requestString = new StringBuilder($"{endpoint}?");

            if (page < 1)
            {
                page = 1;
            }

            requestString.Append($"page={page}&");

            if (perPage > 100)
            {
                perPage = 100;
            }

            requestString.Append($"perPage={perPage}&");

            if (since != null && since.HasValue)
            {
                requestString.Append($"since={since.Value.ToString("yyyy-MM-dd")}");
            }

            if (embed != null && embed.Length > 0)
            {
                requestString.Append($"embed={string.Join(",", embed)}");
            }

            return await CapsuleClient.makeRequest<T>(requestString.ToString(), "GET");
        }

        internal async static Task<bool> makeRequest(string endpoint, string method, object body = null){
            var responseMessage = await CapsuleClient.makeApiCall(endpoint: endpoint, method: method, body: body);

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK 
                || responseMessage.StatusCode == System.Net.HttpStatusCode.Created
                || responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            else{
                return false;
            }
        }

        internal async static Task<T> makeRequest<T>(string endpoint, string method, object body = null) where T : DefaultObjectWrapper
        {
            var responseMessage = await CapsuleClient.makeApiCall(endpoint, body, method);
            T responseObject;

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK 
                || responseMessage.StatusCode == System.Net.HttpStatusCode.Created
                || responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                
                responseObject = JsonConvert.DeserializeObject<T>(responseContent);

                if (responseMessage.Headers.Any(p => p.Key == "Link"))
                {
                    responseObject.Pagination.Parse(responseMessage.Headers.FirstOrDefault(p => p.Key == "Link").Value);
                }
            }
            else if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent){
                return default(T);
            }
            else
            {
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                throw new InvalidOperationException(responseContent);
            }

            return responseObject;
        }

        private static async Task<HttpResponseMessage> makeApiCall(string endpoint, object body, string method) {
            HttpResponseMessage responseMessage = null;
            HttpContent content = null;

            if (body != null)
            {
                var jsonContent = JsonConvert.SerializeObject(body,
                    Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ContractResolver = new CamelCasePropertyNamesContractResolver()

                    });

                content = new StringContent(jsonContent
                    , Encoding.UTF8
                    , "application/json");
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

            return responseMessage;
        }
    }
}
