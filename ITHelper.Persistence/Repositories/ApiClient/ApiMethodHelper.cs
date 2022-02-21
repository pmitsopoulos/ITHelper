using ITHelper.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Persistence.Repositories.ApiClient
{
    public class ApiMethodHelper : IApiMethodHelper
    {
        private string apiKey;
        private string baseUrl;
        public HttpClient http { get; set; }

        public ApiMethodHelper(HttpClient http)
        {
            this.http = http;
            http.DefaultRequestHeaders.Accept.Clear();
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<T> InvokeGet<T>(string uri)
        {
            var response = await http.GetFromJsonAsync<T>(GetUrl(uri));
            return response;
        }

        public async Task<T>? InvokePost<T>(string uri, T obj)
        {
            var response = await http.PostAsJsonAsync<T>(GetUrl(uri), obj);
            await HandleError(response);

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> InvokePut<T>(string uri, T obj)
        {
            var response = await http.PostAsJsonAsync<T>(GetUrl(uri), obj);
            await HandleError(response);

            return await response.Content.ReadFromJsonAsync<T>();
        }
        
        public async Task InvokeDelete<T>(string uri)
        {
            var response = await http.DeleteAsync(GetUrl(uri));
            await HandleError(response);
        }

        
        private string GetUrl(string uri)
        {
            return $"{baseUrl}/{uri}{apiKey}";
        }
        public void SetUrl(string baseUrl)
        {
            this.baseUrl = baseUrl ?? string.Empty;
        }

        private static async Task HandleError(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(error);
            }
        }

        public void SetApiKey(string apiKey)
        {
            this.apiKey = apiKey ?? string.Empty;
        }
    }
}
