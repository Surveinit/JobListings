using Microsoft.AspNetCore.Identity;

namespace JobListings.Helpers;

public class RoleSeeder
{
   public static async Task SeedRoles(IServiceProvider serviceProvider)
   {
      var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

      string[] roles = { "Company" };

      foreach (var role in roles)
      {
         if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
      }
   } 
}