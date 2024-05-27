namespace EShopManagement.Infrastructure.EF.Models
{
    internal class RoleReadModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<UserReadModel> Users { get; set; }
        public bool IsDeleted { get;  set; }
    }
}
