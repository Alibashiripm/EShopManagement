using EShopManagement.Application.Commands.Order;
using EShopManagement.Application.Commands.User;
using EShopManagement.Application.Queries.User;
using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EShopManagement.WebMVC.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class PremiumController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;


        public PremiumController(ICommandDispatcher commandDispatcher)
        {

            _commandDispatcher = commandDispatcher;
        }



        [Route("UserPanel/PremiumPayment")]

        public async Task<IActionResult> PremiumPayment()
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == "Email")?.Value;
            PremiumSubscriptionPayment command = new PremiumSubscriptionPayment(email, "PremiumPayment", "https://localhost:44350/PremiumPaymentResult");
            var result = await _commandDispatcher.DispatchAsync<PremiumSubscriptionPayment, string>(command);
            return Redirect(result);
        }
        [Route("PremiumPaymentResult")]

        public async Task<IActionResult> PremiumPaymentResult(string orderId)
        {
            var reuestQueries = HttpContext.Request.Query;
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            PremiumSubscription command = new PremiumSubscription(int.Parse(orderId), userId, reuestQueries);
            var result = await _commandDispatcher.DispatchAsync<PremiumSubscription, bool>(command);
            return View(result);
        }


    }
}
