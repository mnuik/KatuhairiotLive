using Microsoft.AspNetCore.Mvc;

namespace KatuhairiotLive.Controllers
{
    public class KaupunginosaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
