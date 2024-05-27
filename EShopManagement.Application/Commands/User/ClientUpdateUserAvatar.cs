﻿using EShopManagement.Application.DTOs.User.Client;
using EShopManagement.Shared.Abstractions.Commands;

namespace EShopManagement.Application.Commands.User
{
    public record ClientUpdateUserAvatar(ClientEditUserAvatarDto UserDto) :ICommand;
}
