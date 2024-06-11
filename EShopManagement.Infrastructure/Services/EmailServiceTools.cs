using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Infrastructure.Services
{
    public static  class EmailServiceTools
    {


        public static string GetConfirmEmailBody(string activeCode,string userName)
        {
            string activeMessage = $@" <div style=""direction: rtl; padding: 20px"">
    <h2> Dear {userName}!</h2>
    <p>Thanks for your registration, you need to activate your account to continue</p>
    <p>
        <a href=""https://EshopManagement.bashiridev.ir/ActiveAccount?name={userName}&activeCode={activeCode}"">Click here to activate</a>
    </p>
    </div>
";
            return activeMessage;
        }
    }

}
