using Microsoft.AspNetCore.Mvc;

namespace Findergers1._0.Controllers.HomePage
{
    public class HomePageController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
