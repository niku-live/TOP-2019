using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.DataContext
{
    class WebApiDataContext : IDataContext
    {
        public string BaseUrl { get; set; }

        public WebApiDataContext(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        private async Task<IEnumerable<Student>> LoadFromWebServiceAsync()
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri(BaseUrl) };
            var result = client.GetAsync("students").Result;
            return await result.Content.ReadAsAsync<Student[]>();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return LoadFromWebServiceAsync().Result;
        }
    }
}
