namespace EShopManagement.Domain.Factories.User
{
    public class UserFactory : IUserFactory
    {
        public Entities.User.User Create(string UserName, string Email)
     {
        


          return  new(UserName,
                   Email          
                );
        }
    }
}
