using KatuhairiotLive.Models;
using KatutyotLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
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