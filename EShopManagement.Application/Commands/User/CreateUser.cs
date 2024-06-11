using EShopManagement.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Commands.User
{
    public record CreateUser(string userName, string email, string password  ):ICommand;
}
