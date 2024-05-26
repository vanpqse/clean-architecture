﻿using Microsoft.AspNetCore.Identity;
using ProductFake.Infrastructure.Identity.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ProductFake.Infrastructure.Identity.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "Admin",
                Email = "Admin@Admin.com",
                Name = "Saman",
                PhoneNumber = "09304241296",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (!userManager.Users.Any())
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Sam@12345");
                    await userManager.AddToRoleAsync(defaultUser, "Admin");
                }

            }
        }
    }
}
