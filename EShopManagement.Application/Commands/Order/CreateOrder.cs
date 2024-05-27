using EShopManagement.Application.DTOs.Order;
using EShopManagement.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Commands.Order
{
    public record CreateOrder(OrderDto Order):ICommand;
}
