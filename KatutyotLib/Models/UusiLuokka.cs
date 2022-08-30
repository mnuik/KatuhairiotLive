using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatutyotLib.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class Data
    {
        public string type { get; set; }
        public Feature[] features { get; set; }

        public Crs crs { get; set; }
    }
    public class Crs
    {
        public string type { get; set; }
        public Properties properties { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public string id { get; set; }
        public Geometry geometry { get; set; }
        public string geometry_name { get; set; }
        public Properties properties { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<List<List<List<double>>>> coordinates { get; set; }
    }

    public class Properties
    {
        public int id { get; set; }
        public string hakemus { get; set; }
        public string hakemustunnus { get; set; }
        public string tyo_alkaa { get; set; }
        public string tyo_paattyy { get; set; }
        public string toiminnallinen_kunto { get; set; }
        public string tyon_tarkoitus { get; set; }
        public string osoite { get; set; }
        public string kaupunginosa { get; set; }
        public string status { get; set; }
        public string hakija { get; set; }
        public string tyon_suorittaja { get; set; }
        public string geometrytype { get; set; }
        public string tyo_alkaa_txt { get; set; }
        public string tyo_paattyy_txt { get; set; }
        public string toiminnallinen_kunto_txt { get; set; }
        public string name { get; set; }
    }

    public class Root
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
        public int totalFeatures { get; set; }
        public int numberMatched { get; set; }
        public int numberReturned { get; set; }
        public DateTime timeStamp { get; set; }
        public Crs crs { get; set; }
    }


}
