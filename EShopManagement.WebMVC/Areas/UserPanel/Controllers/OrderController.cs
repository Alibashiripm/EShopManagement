using EShopManagement.Application.Commands.Order;
using EShopManagement.Application.Commands.User;
using EShopManagement.Application.Queries.Order;
using EShopManagement.Domain.Consts;
using EShopManagement.Domain.Entities.Order;
using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EShopManagement.WebMVC.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher ;
 
        public OrderController(IQueryDispatcher queryDispatcher,ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }
        public async Task<IActionResult> Index()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            GetUserAllOrders orders = new GetUserAllOrders() {UserId = userId };
           var ordersDto=await _queryDispatcher.QueryAsync(orders);
            return View(ordersDto);
        } 
         
        public IActionResult ShowOrder(int orderId, string type = "")
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            ViewBag.typeDiscount = type;
            GetUserOrder order = new GetUserOrder() {UserId = userId,OrderId= orderId };
            var orderDto = _queryDispatcher.QueryAsync(order);
            return View(orderDto);
        }
        public async Task<IActionResult> PayOrder(int orderId)
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == "Email")?.Value;
            InvoicePayment command = new InvoicePayment(email, "Buy Product", "https://localhost:44350/PayOrderResult",orderId);
            var result = await _commandDispatcher.DispatchAsync<InvoicePayment, string>(command);
            return Redirect(result);
        } 
        public async Task<IActionResult> PayOrderResult(string orderId)
        {
            var reuestQueries = HttpContext.Request.Query;
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            InvoicePaymentResult command = new InvoicePaymentResult(int.Parse(orderId), userId, reuestQueries);
            var result = await _commandDispatcher.DispatchAsync<InvoicePaymentResult, bool>(command);
            return View(result);
         
        }  
        public async Task<IActionResult> ApplyDiscount(int orderId,string code)
        {
            ApplyDiscount command = new ApplyDiscount(orderId,code);
            var respons =await _commandDispatcher.DispatchAsync<ApplyDiscount, DiscountResponseType>(command);
            return Redirect("/UserPanel/Order/ShowOrder/" + orderId + "?type=" + respons.ToString());

        }



    }
}
