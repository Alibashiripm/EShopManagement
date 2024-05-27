using EShopManagement.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.Exceptions
{
    public class InputTooLongException : EShopManagementException
    {


        public InputTooLongException(string typeName,int maximumLength) : base($"{typeName} exceeds maximum length of {maximumLength} characters.")
        {
        }
    } 
}
