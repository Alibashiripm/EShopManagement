using EShopManagement.Shared.Abstractions.Exceptions;

namespace EShopManagement.Domain.Exceptions
{
    public class SmallNumberException : EShopManagementException
    {


        public SmallNumberException(string typeName,int minimum) : base($"The {typeName} entered number is very small, the minimum integer is {minimum}")
        {
        }
    }
}
