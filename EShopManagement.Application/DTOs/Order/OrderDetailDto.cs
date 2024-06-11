namespace EShopManagement.Application.DTOs.Order
{
    public class OrderDetailDto
    {

        public int DetailId { get; set; }
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public decimal Price { get; set; }
 
    }
}
