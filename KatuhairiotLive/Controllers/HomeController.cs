using KatuhairiotLive.Helpers;
using KatuhairiotLive.Models;
using KatutyotLib;
using KatutyotLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Xml.Serialization;

namespace KatuhairiotLive.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly HkarttaDBContext db;
        public readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger,  IConfiguration config)
        {
            _logger = logger;
            _config = config;

            var optionsBuilder = new DbContextOptionsBuilder<HkarttaDBContext>();
            optionsBuilder.UseSqlServer(_config.GetConnectionString("HkarttaDB"));
            db = new HkarttaDBContext(optionsBuilder.Options);

        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        // Lista() w/XML serializer:
        public IActionResult Lista()
        {
            using HttpClient client = new HttpClient(GetZipHandler());
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            client.DefaultRequestHeaders.Add("accept-encoding", "gzip");

            var apiXML = ApiWebRequestHelper.GetXmlRequest<Tietyö>("https://kartta.hel.fi/ws/geoserver/avoindata/wfs?request=GetCapabilities");

            ViewBag.Result = apiXML;
            return View();

        }

        // Lista() w/XML serializer 2:
        public IActionResult Index(string haku)
        {
            //using HttpClient client = new HttpClient(GetZipHandler());
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            //client.DefaultRequestHeaders.Add("accept-encoding", "gzip");
            //var apiJson = ApiWebRequestHelper.GetJsonRequest<Tietyö>("https://kartta.hel.fi/ws/geoserver/avoindata/wfs?request=GetCapabilities");

            List<Tietyö> työt = new List<Tietyö>();
            APIUtil paikka = new APIUtil();
            työt = paikka.Tietyöt();

            if (!string.IsNullOrWhiteSpace(haku))
            {
                foreach (var item in työt.Where(t => t.status == "(Käynnissä)"))
                {
                    if (item.osoite.StartsWith(haku) || item.kaupunginosa.StartsWith(haku))
                    {
                        Console.WriteLine($"{item.kaupunginosa}: {item.osoite}");
                    }
                    else
                    {
                        Console.WriteLine("Ei häiriöitä tällä hetkellä");
                    }
                }
            }
            else
            {
                Console.WriteLine("joku mättää nyt");
            }
            
            return View();

        }

        /* Lista() w/JSON serializer:*/

        //public IActionResult Lista()
        //{
        //    using HttpClient client = new HttpClient(GetZipHandler());
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.Add("accept-encoding", "gzip");
        //    var response = client.GetAsync($"{APIUtil.APIURL}").Result;
        //    string json = response.Content.ReadAsStringAsync().Result;



        //    List<Tietyö> res = JsonConvert.DeserializeObject<List<Tietyö>>(json); //NewtonSoftin serialisointi
        //                                                                          //List<Liikennepaikka> res = JsonSerializer.Deserialize<List<Liikennepaikka>>(json);  // Core:n oma
        //    ViewBag.Result = res;
        //    return View();

        // }

        private static HttpClientHandler GetZipHandler()
        {
            return new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
        }

        public IActionResult HairionNimi(string paikka)
        {
            List<Tietyö> homma;
            KatutyotLib.APIUtil hairiot = new KatutyotLib.APIUtil();
            homma = hairiot.Tietyöt();

            var tulos =
                (from h in homma
                 where h.kaupunginosa.ToLower() == paikka.ToLower()
                 select h.kaupunginosa).FirstOrDefault();

            ViewBag.Result = tulos;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}