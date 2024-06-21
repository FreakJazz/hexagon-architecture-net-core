using Microsoft.AspNetCore.Mvc;

namespace Services.Api.Controllers
{
    public class ClinicaController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
