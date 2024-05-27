using EShopManagement.Application.DTOs.Order;

namespace EShopManagement.Application.DTOs.User.Client
{
    public class PaymentFactorDto
    {
   
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal OrderSum { get; set; }
        public bool IsFinaly { get; set; }
        public DateTime CreateDate { get; set; }
        public List<OrderDetailDto> DetailDto { get; set; }
    }

}
