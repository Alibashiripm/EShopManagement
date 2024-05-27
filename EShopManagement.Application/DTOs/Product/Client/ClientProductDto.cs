namespace EShopManagement.Application.DTOs.Product.Client
{
    public class ClientProductDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string FileName { get; set; }
        public decimal Price { get; set; }
        public string Tags { get; set; }
        public string SubCategoryTitle { get; set; }
        public string CategoryTitle { get; set; }
        public long CellerId { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsPremium { get; set; }
        public string CreateDate { get; set; }
        public string? UpdateDate { get; set; }
        public string ImageName { get; set; }
    }  
}
