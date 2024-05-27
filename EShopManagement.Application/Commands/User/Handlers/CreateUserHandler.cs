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
    internal sealed class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserFactory factory;
        private readonly IGenericRepository<Domain.Entities.User.User, int> repository;
        private readonly IUserService userService;

        public CreateUserHandler(IUserFactory factory, IGenericRepository<Domain.Entities.User.User, int> repository, IUserService userService)
        {
            this.factory = factory;
            this.repository = repository;
            this.userService = userService;
        }
        public async Task HandleAsync(CreateUser command)
        {
            var user = factory.Create(command.userName, command.email, command.userAvatar, command.activeCode);
            await userService.RegisterUserAsync(user, command.password);
            await repository.CreateAsync(user);
        }
    }
}
