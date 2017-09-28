using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GoogleMaps.LocationServices;
using DarkSkyApi;
using DarkSkyApi.Models;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("What is your location?");

            var address = Console.ReadLine();
            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(address);
            var latitude = point.Latitude;
            var longitude = point.Longitude;

            Console.WriteLine("Your latitude and longitude is (" + latitude.ToString() + "," + longitude.ToString() + ")" + Environment.NewLine);
            Console.WriteLine("Press enter to view your forecast!");
            Console.ReadLine();

            using (var client = new WebClient())
            {
                var forecast =
                    client.DownloadString("https://api.darksky.net/forecast/9585905bb193932089b2a674929322cf/" +
                                          latitude + "," + longitude);

                Console.WriteLine(forecast);
                Console.ReadLine();

            }
        }
    }
}


            