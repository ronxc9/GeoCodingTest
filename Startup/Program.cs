using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoCodingTest;

namespace Startup
{
    class Program
    {
        static void Main(string[] args)
        {
            GeoCodingTest.GeoLocation geolocation = GeoCode.GetCoordinates("xx");
            Console.WriteLine(geolocation.latitude);
            Console.WriteLine(geolocation.longitude);
            Console.WriteLine(geolocation.geocodeurl);
            Console.WriteLine(processMonash.GetMonashCode(geolocation.latitude, geolocation.longitude));
        }
    }
}
