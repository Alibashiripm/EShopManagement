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
    internal sealed class InvoicePaymentHandler : ICommandHandler<InvoicePayment, string>
    {
        private readonly IOrderService service;

        public InvoicePaymentHandler(IOrderService service)
        {
            this.service = service;
        }
        public async Task<string> HandleAsync(InvoicePayment command)
        {
            var result = await service.InvoicePaymentAsync(command.Email, command.Description, command.CallBackUrl, command.OrderId);
            return result;
        }
    }
    internal sealed class InvoicePaymentResultHandler : ICommandHandler<InvoicePaymentResult, bool>
    {
        private readonly IOrderService service;

        public InvoicePaymentResultHandler(IOrderService service)
        {
            this.service = service;
        }
        public async Task<bool> HandleAsync(InvoicePaymentResult command)
        {
            var result = await service.InvoicePaymentResultAsync(command.OrderId,command.UserId,command.ReuestQueries);
            return result;
        }
    }
}
