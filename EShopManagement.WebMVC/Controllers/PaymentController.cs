using Microsoft.AspNetCore.Mvc;

namespace EShopManagement.WebMVC.Controllers
{
    public class PaymentController : Controller
    {
        [Route("PaymentResult")]
        public IActionResult PaymentResult(int id)
        {
            return View();
        }
    }
}
