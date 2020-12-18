using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TheBoardOfShame.Models;

namespace TheBoardOfShame.ViewModels
{
    public class WeatherViewModel
    {
        public WeatherAPI.Weather Weather;
        private const string URL =
            "http://api.openweathermap.org/data/2.5/weather?q=Oakville&appid=0257b00ab1bf0040d1e0d2a255b365a5";

        private string oakVille_lat = "43.4675";
        private string oakVille_long = "-79.6877";

        public string currentLocation;

        public WeatherViewModel()
        {
            Weather = new WeatherAPI.Weather();
            ApiCallAsync();
        }

        public async Task ApiCallAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage
                response = client.GetAsync(URL)
                    .Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var responseObject = await client.GetStringAsync(URL);
                //var json = JsonConvert.SerializeObject(responseObject);
                WeatherAPI.Root r = JsonConvert.DeserializeObject<WeatherAPI.Root>(responseObject, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

                Weather.description = r.weather.First().description;
                currentLocation = r.name;

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

                client.Dispose();
            }
        }

    }
}