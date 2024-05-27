using EShopManagement.Shared.Abstractions.Exceptions;

namespace EShopManagement.Domain.Exceptions
{
    public class InputTooShortException : EShopManagementException
    {


        public InputTooShortException(string typeName,int minimumLength) : base($"The {typeName} length is less than the minimum set, i.e. {minimumLength}")
        {
        }
    }   
}
