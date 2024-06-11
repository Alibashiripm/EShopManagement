using EShopManagement.Application.DTOs.User.Client;
using EShopManagement.Application.Queries.User;
using EShopManagement.Application.Services;
using EShopManagement.Domain.Entities.User;
using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Shared.Abstractions.Queries;
using EShopManagement.WebMVC.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace EShopManagement.WebMVC.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {
         private readonly IQueryDispatcher _queryDispatcher;

        public HomeController(  IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
         }
        public async Task<IActionResult> Index()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            GetUserProfileForClient query = new GetUserProfileForClient() { UserId = userId };
            var model = await _queryDispatcher.QueryAsync(query);
            return View(model);
        }

    

    }
}
