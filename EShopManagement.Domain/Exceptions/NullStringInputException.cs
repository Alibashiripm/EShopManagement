using EShopManagement.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.Exceptions
{
    public class NullStringInputException : EShopManagementException
    {
        

            public NullStringInputException(string typeName) : base($"The {typeName} cannot be empty.")
            {
            }
    
    }
}
