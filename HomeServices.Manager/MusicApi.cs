using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace HomeServices.Manager
{
    public class MusicApi
    {
        public string AddDirectory(string path)
        {
            var client = new RestClient("http://localhost:53216");
            var request = new RestRequest($"api/music/filldb?path={path}");
            var response = client.Get(request);

            return response.Content;
        }

        public string Test()
        {
            var client = new RestClient("http://localhost:53216");
            var request = new RestRequest($"/api/music/test");
            var response = client.Get(request);

            return response.Content;
        }
    }
}
