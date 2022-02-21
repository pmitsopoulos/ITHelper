using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Contracts.Persistence
{
    public interface IApiMethodHelper
    {
        Task InvokeDelete<T>(string uri);
        Task<T> InvokeGet<T>(string uri);
        Task<T>? InvokePost<T>(string uri, T obj);
        Task<T> InvokePut<T>(string uri,T obj);
        void SetUrl(string baseUrl);
        void SetApiKey(string apiKey);
        public HttpClient http { get; set; }
    }
}
