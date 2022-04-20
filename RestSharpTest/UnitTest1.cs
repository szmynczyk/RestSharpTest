using NUnit.Framework;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace RestSharpTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var client = new RestClient("https://localhost:5001/Auth/Login");
            var request = new RestRequest();

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "text/plain");
            var body = new
            {
                username = "testUser",
                password = "Test1234!"
            };
            //var body = @"{" + "\n" +
            //@"  ""username"": ""testUser""," + "\n" +
            //@"  ""password"": ""Test1234!""" + "\n" +
            //@"}";
            request.AddJsonBody(body);
            //request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = await client.PostAsync(request);
            Console.WriteLine(response.Content);
            Console.WriteLine("dupa");
        }
    }
}