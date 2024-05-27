namespace EShopManagement.Application.DTOs.Product.Client
{
    public class ClientLeaveProductCommentDto
    {
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int ProductId { get; set; }
        public int UserId{ get; set; }
     }
}
