using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net;
using System.Web;
using System.Xml;
using System.IO;


namespace GeoCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            GeoCodingTest.GeoLocation geolocation = GeoCode.GetCoordinates("Port Augusta, South Australia");
            Console.WriteLine(geolocation.latitude);
            Console.WriteLine(geolocation.longitude);
            Console.WriteLine(geolocation.geocodeurl);
            GeoCodingTest.MonashCode monashcode = processMonash.GetMonashCode(geolocation.latitude, geolocation.longitude);
           
            /*
            String uri = "http://maps.googleapis.com/maps/api/geocode/xml?address=1128+West+Hastings+Street,+Vancouver+British+Columbia+Canada&sensor=true";
            WebRequest.DefaultWebProxy = new WebProxy();
            WebRequest myWebRequest = WebRequest.Create(uri);
            var response = myWebRequest.GetResponse();
            

            Console.WriteLine(response.GetResponseStream());
            using (var sr = new StreamReader(response.GetResponseStream()) )
            {
                Console.WriteLine(sr.ReadToEnd());
            }
             */
        }
    }
}
