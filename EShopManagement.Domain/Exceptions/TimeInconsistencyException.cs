using EShopManagement.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.Exceptions
{
    public class TimeInconsistencyException : EShopManagementException
    {
     public TimeInconsistencyException() : base($"Start date must be before end date")
        {
        }
    }
}
