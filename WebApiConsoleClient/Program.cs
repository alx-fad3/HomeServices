using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;

namespace WebApiConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://localhost:44344");
            Console.Write("Resource: ");
            var request = new RestRequest("/api/main/getdirectories");
            var response = client.Execute(request, Method.GET);

            var json = JsonConvert.DeserializeObject(response.Content, typeof(List<string>));
            foreach (var e in (List<string>)json)
            {
                Console.WriteLine(e);
            }
            Console.Read();
        }
    }
}
