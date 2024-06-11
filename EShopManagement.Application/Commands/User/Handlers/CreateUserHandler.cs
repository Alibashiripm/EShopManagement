using AutoMapper;
using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Services;
using EShopManagement.Domain.Factories.User;
using EShopManagement.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Commands.User.Handlers
{
    internal sealed class CreateUserHandler : ICommandHandler<CreateUser, IdentityResult>
    {
        private readonly IUserFactory factory;
         private readonly IUserService userService;

        public CreateUserHandler(IUserFactory factory, IUserService userService)
        {
            this.factory = factory;
             this.userService = userService;
        }
        public async Task<IdentityResult> HandleAsync(CreateUser command)
        {
            var user = factory.Create(command.userName, command.email );
            var result = await userService.RegisterUserAsync(user, command.password);
             return result;
        }
    }  
}
