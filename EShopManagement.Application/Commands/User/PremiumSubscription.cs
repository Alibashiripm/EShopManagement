using EShopManagement.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace EShopManagement.Application.Commands.User
{
    public record PremiumSubscription(int OrderId,int UserId, IQueryCollection reuestQueries) : ICommand;
    
}
