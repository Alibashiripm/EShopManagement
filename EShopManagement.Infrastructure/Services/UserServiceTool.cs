using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EShopManagement.Infrastructure.Services
{
    internal static class UserServiceTool
    {
        public static async Task<StringType> ClassifyStringAsync(string input)
        {
        
            if (Regex.IsMatch(input, @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$"))
            {
                return StringType.Email;
            }
            else
            {
                return StringType.UserName;
            }

        }
    }
    public enum StringType
    {

        Email,
        UserName

    }
}
