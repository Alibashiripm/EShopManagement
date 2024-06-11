using EShopManagement.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Infrastructure.Exceptions
{
   
    public class UserNotExistingExeption : EShopManagementException
    {
    
        public string ExistedName { get; }
        public UserNotExistingExeption(string existedName)
            : base($"The User with '{existedName}' not exists.")
        {
             ExistedName = existedName;
        }
    }
}
