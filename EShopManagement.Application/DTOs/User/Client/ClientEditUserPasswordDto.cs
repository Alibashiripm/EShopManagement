namespace EShopManagement.Application.DTOs.User.Client
{
    public class ClientEditUserPasswordDto
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

    }
}
