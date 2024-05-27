namespace EShopManagement.Application.DTOs.Product.Admin
{
    public class AdminPtoductsListDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price{ get; set; }
        public string? SubCategoryTitle { get; set; }
        public string ImageName { get; set; }

        public string CategoryTitle { get; set; }
        public string CellerUserName { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsPremium { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
