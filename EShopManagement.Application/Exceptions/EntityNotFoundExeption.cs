using EShopManagement.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Exceptions
{
    internal class EntityNotFoundExeption:EShopManagementException
    {
        public string Id { get; set; }
        public string TypeName { get; set; }
        public EntityNotFoundExeption(string id,string typeName):base($"{typeName} with ID '{id}' was not found.")
        {
           Id= id;
           TypeName= typeName;
        }
    }
  
  
}
