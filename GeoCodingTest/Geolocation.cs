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
    public interface IGeoLocation
    {
        double latitude { get; set; }
        double longitude { get; set; }
        string geocodeurl { get; set; }
    }
 
    public struct GeoLocation : IGeoLocation
    {
        private double _latitude;
        private double _longitude;
        private string _geocodeurl;
 
        public GeoLocation(double latitude, double longitude, string geocodeurl)
        {
            _latitude = latitude;
            _longitude = longitude;
            _geocodeurl = geocodeurl;
        }
 
        public double latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }
 
        public double longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
 
        public string geocodeurl
        {
            get {return _geocodeurl; }
            set { _geocodeurl = value; }
        }
    }
 
    public class GeoCode
    {
        const string _googleUri = "http://maps.googleapis.com/maps/api/geocode/xml?address=";
        //sample
        //http://maps.googleapis.com/maps/api/geocode/xml?address=1128+West+Hastings+Street,+Vancouver+British+Columbia+Canada&sensor=true
 
        private static Uri GetGeoCodeURI(string address)
        {
            address = HttpUtility.UrlEncode(address);
            string uri = String.Format("{0}{1}&sensor=false", _googleUri, address);

            return new Uri(uri);
        }
 
        public static GeoLocation GetCoordinates(string address)
        {
            
            Uri uri = GetGeoCodeURI(address);
            WebRequest.DefaultWebProxy = new WebProxy();
            WebRequest myWebRequest = WebRequest.Create(uri);
            var response = myWebRequest.GetResponse();

            string geoCodeInfo;
           // Console.WriteLine(response.GetResponseStream());
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                geoCodeInfo = sr.ReadToEnd();
                
            }

            //Console.WriteLine(geoCodeInfo);
         

   
            
            
            

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(geoCodeInfo);
                //Console.WriteLine(xmlDoc);
            try
            {
                //string geoCodeInfo = wc.DownloadString(uri);
                //XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(geoCodeInfo);
                
                //Console.WriteLine(xmlDoc);
                string status = xmlDoc.DocumentElement.SelectSingleNode("status").InnerText;
                
                double geolat = 0.0;
                double geolong = 0.0;
                XmlNodeList nodeCol = xmlDoc.DocumentElement.SelectNodes("result");

                foreach (XmlNode node in nodeCol)
                {
                    geolat = Convert.ToDouble(node.SelectSingleNode("geometry/location/lat").InnerText, System.Globalization.CultureInfo.InvariantCulture);
                    geolong = Convert.ToDouble(node.SelectSingleNode("geometry/location/lng").InnerText, System.Globalization.CultureInfo.InvariantCulture);
                }
                return new GeoLocation(geolat, geolong, uri.ToString());
            }
            catch
            {
                return new GeoLocation(0.0, 0.0, "http://x");
            }
        }
 
    }
}
