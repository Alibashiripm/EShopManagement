using EShopManagement.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Exceptions
{
    public class AlreadyExistsException : EShopManagementException
    {
        public string TypeName { get; }
        public string ExistedName { get; }
        public AlreadyExistsException(string typeName,string existedName)
            : base($"{typeName} with name '{existedName}' already exists.")
        {
           TypeName = typeName;
            ExistedName = existedName;
        }
    }
}
