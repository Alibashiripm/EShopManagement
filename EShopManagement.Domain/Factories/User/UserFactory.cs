namespace EShopManagement.Domain.Factories.User
{
    public class UserFactory : IUserFactory
    {
        public Entities.User.User Create(string UserName, string Email,  string UserAvatarName, string ActiveCode)
      => new(UserName,
                Email,
              
                UserAvatarName,
                ActiveCode);
    }
}
