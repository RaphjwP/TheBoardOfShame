using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBoardOfShame.Models
{
    public class Weather
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public double TempC { get; set; }

        public string WeatherStatus { get; set; }

        public string Location { get; set; }
    }
}
