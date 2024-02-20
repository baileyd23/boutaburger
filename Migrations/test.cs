using boutaburger.Data;
using Microsoft.AspNetCore.Identity;

namespace boutaburger.Migrations
{
    public class test
    { 
   public static async Task Initialize(boutaburgerContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)

    {
        context.Database.EnsureCreated();
        string adminRole = "Admin";
        string memberRole = "member";
        string password4all = "password";

        if (await roleManager.FindByNameAsync(adminRole) == null)
        {
            await roleManager.CreateAsync(new IdentityRole(adminRole));
        }

        if (await roleManager.FindByIdAsync(memberRole) == null)
        {
            await userManager.CreateAsync(new IdentityUser(memberRole));
        }

        if (await userManager.FindByNameAsync("admin@admin.com") == null)
        {
            var user = new IdentityUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                PhoneNumber = "4329785197"
            };
            var result = await userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                await userManager.AddPasswordAsync(user, password4all);
                await userManager.AddToRoleAsync(user, adminRole);
            }
        }

        if (await userManager.FindByNameAsync("member@member.com") == null)
        {
            var user = new IdentityUser
            {
                UserName = "member@member.com",
                Email = "member@member.com",
                PhoneNumber = "4326893413"
            };
            var result = await userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                await userManager.AddPasswordAsync(user, password4all);
                await userManager.AddToRoleAsync(user, memberRole);
            }
        }
    }
}
}
