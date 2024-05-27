using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Exceptions;
using EShopManagement.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Commands.Order.Handlers
{
    internal sealed class InvoicePaymentHandler : ICommandHandler<InvoicePayment>
    {
        private readonly IOrderService service;

        public InvoicePaymentHandler(IOrderService service)
        {
            this.service = service;
        }
        public async Task HandleAsync(InvoicePayment command)
        {
            if (await service.IsOrderExistWithIdAsync(command.OrderId))
            {
                throw new EntityNotFoundExeption(command.OrderId.ToString(),"Order");
            }
            await service.FinalizeOrderAsync(command.OrderId, command.UserId);
         }
    }
}
