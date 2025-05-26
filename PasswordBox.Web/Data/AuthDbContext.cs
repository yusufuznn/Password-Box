using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PasswordBox.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRoleId = "c9ebd36c-b6f5-420e-b953-4ef6b9109401";
            var userRoleId = "368d8881-c62b-41be-9879-f553248137d5";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            var adminId = "01e38f29-6266-4ce1-8c07-5c3168e7efdd";
            var adminUser = new IdentityUser
            {
                UserName = "yusufuzun@passBox.com",
                Email = "yusufuzun@passBox.com",
                NormalizedEmail = "yusufuzun@passBox.com".ToUpper(),
                NormalizedUserName = "yusufuzun@passBox.com".ToUpper(),
                Id = adminId
            };

            adminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(adminUser, "yusufuzn123");

            builder.Entity<IdentityUser>().HasData(adminUser);

            var adminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = adminId
                },
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);

        }







    }
}
