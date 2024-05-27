namespace EShopManagement.Application.DTOs.Product.Client
{
    public class ClientProductCommentDto
    {
        public string Content { get; set; }
        public string CreateDate { get; set; }
        public int ProductId { get; set; }
        public string UserName{ get; set; }
        public string UserAvatarName { get; set; }
    } 
}
