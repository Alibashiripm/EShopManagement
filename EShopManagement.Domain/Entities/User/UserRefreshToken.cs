namespace EShopManagement.Domain.Entities.User
{
    public class UserRefreshToken  
    {
        public UserRefreshToken()
        {
            CreatedAt = DateTime.Now;
        }
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsValid { get; set; }
    }
}
