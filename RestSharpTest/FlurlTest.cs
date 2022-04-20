using Flurl;
using NUnit.Framework;
using Flurl.Http;
using System;
using System.Threading.Tasks;

namespace RestSharpTest
{
    public class FlurlTest
    {
        [Test]
        public async Task FlurlPostTest()
        {
            var url = new Url("https://localhost:5001/Auth/Login");
            url.WithHeader("Content-Type", "application/json");
            url.WithHeader("Accept", "text/plain");
            var body = new
            {
                username = "testUser",
                password = "Test1234!"
            };

            var response = await url.PostJsonAsync(body);
            var convertedResponse = await response.GetJsonAsync<ServiceResponse<string>>();

            Console.WriteLine(convertedResponse.Data);

        }

        public class ServiceResponse<T>
        {
            public T Data { get; set; }
            public bool Success { get; set; } = true;
            public string Message { get; set; } = null;
        }
    }
}
