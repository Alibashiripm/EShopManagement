using EShopManagement.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http;

namespace EShopManagement.Application.Commands.Order
{
    public record InvoicePaymentResult(int OrderId,int UserId,  IQueryCollection ReuestQueries) :ICommand;
   
}
