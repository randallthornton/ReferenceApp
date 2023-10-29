using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public class UsersDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        SeedData(builder);
    }

    private void SeedData(ModelBuilder builder)
    {
        var userId = "E728777F-88F4-4747-8959-0B1EE2363D22";
        var roleId = "ADF10E5E-668D-481A-8EDF-41F95A2F23F3";

        var role = new IdentityRole
        {
            Name = "Admin",
            Id = roleId,
            NormalizedName = "Admin",
            ConcurrencyStamp = roleId
        };

        PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();

        var user = new AppUser
        {
            UserName = "bob",
            Id = userId,
            Email = "bob@bob.com",
            EmailConfirmed = true,
            NormalizedUserName = "BOB",
            NormalizedEmail = "BOB@BOB.COM",
            SecurityStamp = userId
        };

        user.PasswordHash = passwordHasher.HashPassword(user, "bob");

        builder.Entity<AppUser>().HasData(user);
        builder.Entity<IdentityRole>().HasData(role);
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            UserId = userId,
            RoleId = roleId,
        });
    }
}
