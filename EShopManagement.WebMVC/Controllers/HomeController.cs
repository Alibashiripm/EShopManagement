 using Microsoft.AspNetCore.Mvc;
 

namespace EShopManagement.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }  
    }
}
