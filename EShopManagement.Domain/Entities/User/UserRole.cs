﻿using Microsoft.AspNetCore.Identity;


namespace EShopManagement.Domain.Entities.User
{
    public class UserRole:IdentityUserRole<int>
    {
        public User User { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedUserRoleDate { get; set; }
    }
}