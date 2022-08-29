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

namespace KatutyotLib
{
   
        public class APIUtil
        {

      
            public List<Tietyö> Tietyöt()
            {
           
            using HttpClient client = new HttpClient(GetZipHandler());
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                client.DefaultRequestHeaders.Add("accept-encoding", "gzip");
            var result = ApiWebRequestHelper.GetXmlRequest<List<Tietyö>>("https://kartta.hel.fi/ws/geoserver/avoindata/wfs?request=GetCapabilities");
    
            return result;
            }

   
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

    //public List<Juna> JunatVälillä(string mistä, string minne)
    //{
    //    string json = "";
    //    string url = $"{APIURL}/schedules?departure_station={mistä}&arrival_station={minne}";
    //    using (var client = new HttpClient(GetZipHandler()))
    //    {
    //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //        var response = client.GetAsync(url).Result;
    //        var responseString = response.Content.ReadAsStringAsync().Result;
    //        json = responseString;
    //    }
    //    List<Juna> res = JsonConvert.DeserializeObject<List<Juna>>(json);
    //    return res;
    //}

    //public List<Juna> KahdenAsemanVälillä(string saapumisAsema, string lähtöAsema)
    //{
    //    string json = "";
    //    string url = $"{APIURL}/live-trains/station/{saapumisAsema}/{lähtöAsema}";
    //    using (var client = new HttpClient(GetZipHandler()))
    //    {
    //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //        var response = client.GetAsync(url).Result;
    //        var responseString = response.Content.ReadAsStringAsync().Result;
    //        json = responseString;
    //    }
    //    List<Juna> res = JsonConvert.DeserializeObject<List<Juna>>(json);
    //    return res;
    //}
    //public List<Juna> SaapuvatJaLähtevät(string lähtöAsema)
    //{
    //    string json = "";
    //    string url = $"{APIURL}/live-trains/station/{lähtöAsema}?arrived_trains=0&arriving_trains=10&departed_trains=0&departing_trains=10&include_nonstopping=false&version=0";
    //    using (var client = new HttpClient(GetZipHandler()))
    //    {
    //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //        var response = client.GetAsync(url).Result;
    //        var responseString = response.Content.ReadAsStringAsync().Result;
    //        json = responseString;
    //    }
    //    List<Juna> res = JsonConvert.DeserializeObject<List<Juna>>(json);
    //    return res;
    //}

    //public List<Juna> SeuraavaJuna(string mistä, string minne)
    //{
    //    string json = "";
    //    string url = $"{APIURL}/live-trains/station/{mistä}/{minne}";
    //    using (var client = new HttpClient(GetZipHandler()))
    //    {
    //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //        var response = client.GetAsync(url).Result;
    //        var responseString = response.Content.ReadAsStringAsync().Result;
    //        json = responseString;
    //    }
    //    List<Juna> res = JsonConvert.DeserializeObject<List<Juna>>(json);
    //    return res;
    //}

    //public List<Kulkutietoviesti> LiikennepaikanJunat(string paikka)
    //{
    //    string json = "";
    //    string url = $"{APIURL}/train-tracking?station={paikka}&departure_date={DateTime.Today.ToString("yyyy-MM-dd")}";
    //    using (var client = new HttpClient(GetZipHandler()))
    //    {
    //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //        var response = client.GetAsync(url).Result;
    //        var responseString = response.Content.ReadAsStringAsync().Result;
    //        json = responseString;
    //    }
    //    List<Kulkutietoviesti> res = JsonConvert.DeserializeObject<List<Kulkutietoviesti>>(json);
    //    return res;
    //}

    private static HttpClientHandler GetZipHandler()
            {
                return new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                };
            }
        }
    }
