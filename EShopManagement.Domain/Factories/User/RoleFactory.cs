using EShopManagement.Domain.Entities.User;

namespace EShopManagement.Domain.Factories.User
{
    public class RoleFactory : IUserRoleFactory
    {
        public Role Create(string RoleName)
      => new(RoleName);
    }
}
