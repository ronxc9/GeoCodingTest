using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoCodingTest
{
    public class JsonObject
    {
        public string kind { get; set; }
        public List<string> columns { get; set; }
        public List<List<string>> rows { get; set; }
    }
}
