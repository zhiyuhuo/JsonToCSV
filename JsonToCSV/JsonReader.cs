using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonToCSV
{
    class JsonReader
    {
        Newtonsoft.Json.j
        String m_jsonFileDir = "";
        JObject o1 = JObject.Parse(File.ReadAllText(@"c:\videogames.json"));

    }
}
