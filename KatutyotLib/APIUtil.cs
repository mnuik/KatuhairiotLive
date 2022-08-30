using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using KatutyotLib.Models;


using Newtonsoft.Json;
using KatuhairiotLive.Helpers;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace KatutyotLib
{

    public class APIUtil
    {
        private const string APIURL = "https://kartta.hel.fi/ws/geoserver/avoindata/wfs?SERVICE=WFS&VERSION=1.1.0&REQUEST=GetFeature&TYPENAME=avoindata:Kaivuilmoitus_alue&OUTPUTFORMAT=json";

        //    public List<Tietyö> Tietyöt()
        //    {

        //    using HttpClient client = new HttpClient(GetZipHandler());
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        //        client.DefaultRequestHeaders.Add("accept-encoding", "gzip");
        //    var result = ApiWebRequestHelper.GetJsonRequest<List<Tietyö>>("https://kartta.hel.fi/ws/geoserver/avoindata/wfs?SERVICE=WFS&VERSION=1.1.0&REQUEST=GetFeature&TYPENAME=avoindata:Kaivuilmoitus_alue&OUTPUTFORMAT=json");

        //    return result;
        //}
        public List<Tietyö> Tietyöt()
        {
            
            using HttpClient client = new HttpClient(GetZipHandler());
            
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("accept-encoding", "gzip");

                var response = client.GetAsync(APIURL).Result;
                string json = response.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions();

            List<Tietyö> res = JsonConvert.DeserializeObject<List<Tietyö>>(json);   //NewtonSoftin serialisointi
                                                                                    // List<Tietyö> res = JsonSerializer.Deserialize<List<Tietyö>>(json);  // Core:n oma
            return res;


            //public List<Juna> JunanTieto(string junaNumero)
            //{
            //    string json = "";
            //    string url = $"{APIURL}/trains/latest/{junaNumero}";

            //    using HttpClient client = new HttpClient(GetZipHandler());
            //    {
            //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //        var response = client.GetAsync(url).Result;
            //        var responseString = response.Content.ReadAsStringAsync().Result;
            //        json = responseString;
            //    }
            //    List<Juna> res = JsonConvert.DeserializeObject<List<Juna>>(json);
            //    return res;


            //}

        }
            private static HttpClientHandler GetZipHandler()
            {
                return new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                };
            }
       
    }
}
