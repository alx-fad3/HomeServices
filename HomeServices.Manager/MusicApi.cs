using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.IO;

namespace HomeServices.Manager
{
    public class MusicApi
    {
        public string AddDirectory(string path)
        {
            //var dirs = Directory.GetDirectories(path, "", SearchOption.AllDirectories);
            //if (dirs.Length > 5) return AddManyDirectories(dirs);

            var client = new RestClient("http://localhost:53216");
            var request = new RestRequest($"api/music/filldb?path={path}");
            var response = client.Get(request);

            return response.Content;
        }

        public string AddManyDirectories(IEnumerable<string> directories)
        {
            var responses = new List<string>();
            foreach(var d in directories)
            {
                var client = new RestClient("http://localhost:53216");
                var request = new RestRequest($"api/music/filldb?path={d}");
                var response = client.Get(request);
                responses.Add(response.Content);
            }

            return responses[0];
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
