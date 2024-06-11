using EShopManagement.Application.Commands.User;
using EShopManagement.Application.DTOs.User.Authentication;
using EShopManagement.Application.Queries.User;
using EShopManagement.Application.Services;
using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EShopManagement.WebMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public AuthController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUser query)
        {

            var result = await _queryDispatcher.QueryAsync(query);

            if (result.Succeeded)
            {
                return Redirect("/UserPanel");
            }
            else if (!result.Succeeded && !result.IsLockedOut&& !result.IsNotAllowed)
            {

                ModelState.AddModelError("UserNameOrEmail", ".This UserName(or Email) or Password is wrong");
                return View(query);
            }
            else  if (result.IsNotAllowed)
            {
                ModelState.AddModelError("UserNameOrEmail", "This account is not active. Refer to your email to activate");
                return View(query);
            }
            else
            {

                ModelState.AddModelError("UserNameOrEmail", ".This account is locked. Please try again in a few minutes");
                return View(query);
            }
        }
        [HttpGet]
        [Route("Register")]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(CreateUser command)
        {
            var result = await _commandDispatcher.DispatchAsync<CreateUser, IdentityResult>(command); ;
            if (result.Succeeded)
            {
                return Redirect($"/ConfrimRegister?name={command.userName}&email={command.email}");
            }
            else
            {
                ModelState.AddModelError("userName", ".This username or email is already registered on the site");
                return View(command);
            }

        }

        [Route("ConfrimRegister")]
        public async Task<IActionResult> ConfrimRegister(string name,string email)
        {
            string[] model = [name, email];
            return View(model);
        }
        [Route("ActiveAccount")]
        public async Task<IActionResult> ActiveAccount(string name, string activeCode)
        {
            ConfrimUserEmail command = new(name, activeCode);
            await _commandDispatcher.DispatchAsync<ConfrimUserEmail, bool>(command);
            return View();
        }
        [Route("/Logout")]
        public async Task<IActionResult> Logout()
        {
            return View();
        }
    }
}
