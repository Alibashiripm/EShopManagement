using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.Factories.User
{
    public interface IUserFactory
    {
        Entities.User.User Create(string UserName, string Email,string UserAvatarName,string ActiveCode);
    } 
}
