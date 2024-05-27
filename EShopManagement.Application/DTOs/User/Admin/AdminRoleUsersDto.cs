namespace EShopManagement.Application.DTOs.User.Admin
{
    public class AdminRoleUsersDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<int>UserIds { get; set; }
    }
}
