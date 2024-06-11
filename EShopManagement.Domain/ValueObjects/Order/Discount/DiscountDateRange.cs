using EShopManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.ValueObjects.Order.Discount
{
    public record DiscountDateRange
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public DiscountDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate >= endDate)
                throw new TimeInconsistencyException();

            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
