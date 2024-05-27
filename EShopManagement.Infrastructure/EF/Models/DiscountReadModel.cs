using EShopManagement.Domain.ValueObjects.Order.Discount;

namespace EShopManagement.Infrastructure.EF.Models
{
    internal class DiscountReadModel
    {
        public int Id { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountPercent{ get; set; }
        public DiscountDateRange _dateRange{ get; set; }
        public int UsableCount{ get; set; }
        public bool IsDeleted { get;  set; }
    }
}
