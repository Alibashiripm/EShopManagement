using EShopManagement.Application.Commands.User;
using EShopManagement.Application.DTOs.User.Client;
using EShopManagement.Application.Queries.User;
using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Shared.Abstractions.Queries;
using EShopManagement.WebMVC.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EShopManagement.WebMVC.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class EditUserController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public EditUserController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }
      
        [Route("UserPanel/EditAvatar")]
        public async Task<IActionResult> EditAvatar()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            GetUserAavtarForClient query = new GetUserAavtarForClient() { UserId = userId };
            var model = await _queryDispatcher.QueryAsync(query);
            return View(model);
        }
        [Route("UserPanel/EditAvatar")]
        [HttpPost]
        public async Task<IActionResult> EditAvatar([FromForm] ClientEditUserAvatarDto dto, IFormFile avatar)

        {

            dto.UserAvatarName = await ImageSaver.SaveImage(avatar, "wwwroot/UserAvatar", "wwwroot/UserAvatar/Thumb");
            ClientUpdateUserAvatar command = new ClientUpdateUserAvatar(dto);
            await _commandDispatcher.DispatchAsync(command);
            return Redirect("/UserPanel");
        }
        [Route("UserPanel/ChangePassword")]
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }
        [Route("UserPanel/ChangePassword")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromForm] ClientEditUserPasswordDto dto)
        {
            dto.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            ClientUpdateUserPassword command = new ClientUpdateUserPassword(dto);
            await _commandDispatcher.DispatchAsync(command);
            return Redirect("/UserPanel");
        } 


    }
}
