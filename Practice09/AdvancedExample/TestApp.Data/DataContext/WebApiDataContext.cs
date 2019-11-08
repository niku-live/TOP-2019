using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.DataContext
{
    public class WebApiDataContext : IDataContext
    {
        public string BaseUrl { get; set; }
        private HttpClient Client { get => new HttpClient() { BaseAddress = new Uri(BaseUrl) }; }

        public WebApiDataContext(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await Client.GetAsync("students").Result.Content.ReadAsAsync<Student[]>();
        }

        public async Task<Student> AddOnUpdateStudentAsync(Student student)
        {
            return await Client.PostAsJsonAsync<Student>("students", student).Result.Content.ReadAsAsync<Student>();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await Client.GetAsync($"students/{id}").Result.Content.ReadAsAsync<Student>();
        }
    }
}
