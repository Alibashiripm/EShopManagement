using EShopManagement.Domain.Entities.User;

namespace EShopManagement.Domain.Factories.User
{
    public interface IUserRoleFactory
    {
         Role Create(string RoleName);
    }   
}
