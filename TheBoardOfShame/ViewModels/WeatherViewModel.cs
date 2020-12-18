using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using TheBoardOfShame.Models;

namespace TheBoardOfShame.ViewModels
{
    public class WeatherViewModel
    {
        private Weather _weather;
        private const string URL =
            "http://http://api.aerisapi.com/observations/43.4675,-79.6877?query&client_id=wztUyr2pGuOQTfc2iXxem&client_secret=5IpLXXTRTrCmr75ug3FegawR7PGKG5dqQzC2z4Ru";

        private string urlClient_id = "wztUyr2pGuOQTfc2iXxem";
        private string urlClient_Secret = "5IpLXXTRTrCmr75ug3FegawR7PGKG5dqQzC2z4Ru";
        private string oakVille_lat = "43.4675";
        private string oakVille_long = "-79.6877";

        public WeatherViewModel()
        {
            _weather = new Weather();
        }

        public void ApiCall()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage
                response = client.GetAsync("")
                    .Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var weatherObject =
                    response.Content.ReadAsAsync<IEnumerable<Weather>>()
                        .Result; //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (var weather in weatherObject)
                {
                    Console.WriteLine("{0}", weather.TempC);
                    Console.WriteLine(weather.Latitude);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

                client.Dispose();
            }
        }

    }
}