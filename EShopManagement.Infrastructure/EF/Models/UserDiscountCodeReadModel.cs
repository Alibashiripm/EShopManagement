namespace EShopManagement.Infrastructure.EF.Models
{
    internal class UserDiscountCodeReadModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserReadModel User { get; set; }
        public string DiscountCode { get; set; }

    }
}
