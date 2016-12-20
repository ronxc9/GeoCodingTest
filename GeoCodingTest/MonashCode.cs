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
using Newtonsoft.Json;
namespace GeoCodingTest
{
    public interface IMonashCode
    {
       int monashCode { get; set; }
     

    }
    public struct MonashCode : IMonashCode
    {
        private int _monashCode;
 

        public MonashCode(int monashCode)
        {

            _monashCode = monashCode;
        }
        public int monashCode
        {
            get { return _monashCode; }
            set { _monashCode = value; }
        }
      
    }

    public  class processMonash
    {
        public static String GetMonashCode(double latitude, double longitude)
        {
            string uri = "https://www.googleapis.com/fusiontables/v2/query?sql=SELECT%20MMM_CLASS%20FROM%201RqeH2UnuBNkH6yw-kvIotT1i9xlXw8B8XEGsdrpi%20WHERE%20ST_INTERSECTS(geometry,%20CIRCLE(LATLNG(" + latitude + "," + longitude +"),1))&key=AIzaSyB6-WrgN30yZYipBofQHrMwTvyeW2k6RuI";
            WebRequest.DefaultWebProxy = new WebProxy();
            WebRequest myWebRequest = WebRequest.Create(uri);
            try
            {
                var response = myWebRequest.GetResponse();
                string monashInfo;
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    monashInfo = sr.ReadToEnd();
                }
                JsonObject jsonboj = JsonConvert.DeserializeObject<JsonObject>(monashInfo);
                Console.WriteLine(monashInfo);
                return (jsonboj.rows[0][0]);
            }
            catch
            {
                return ("Invalid address");
            }   
            
        }
    }


}
