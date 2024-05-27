using EShopManagement.Domain.Entities.User;

namespace EShopManagement.Infrastructure.EF.Models
{
    internal class UserPremiumReadModel
    {
        public int Id { get; set; }
        public int UserId { get; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public UserReadModel User { get; set; }
        public bool IsDeleted { get; set; }

    }
}
