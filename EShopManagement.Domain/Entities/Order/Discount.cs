using EShopManagement.Shared.Abstractions.Domain;
using EShopManagement.Domain.ValueObjects.Order.Discount;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.Entities.Order
{
    public class Discount : AggregateRoot<int>
    {
     
        public int  Id { get;private set; }
        public DiscountCode _discountCode;
        public DiscountPercent _discountPercent;
        public DiscountDateRange _dateRange;
        public int UsableCount { get; private set; }
 
        public bool IsDeleted { get; private set; }

        internal  Discount(DiscountCode discountCode, DiscountPercent discountPercent, DiscountDateRange dateRange, int usableCount, bool isDeleted)
        {
       
            _discountCode = discountCode;
            _discountPercent = discountPercent;
            _dateRange = dateRange;
            UsableCount = usableCount;
            IsDeleted = isDeleted;
        }
        public Discount()
        {
            
        }

        public void SoftRemove()
        {
            IsDeleted = true;
        } 
        public void ReduceCount()
        {
            UsableCount -= 1;
        }
    }
}
