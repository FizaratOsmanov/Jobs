using System.Reflection;
using CORE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DATA.Contexts;

public class AppDbContext:IdentityDbContext<AppUser,IdentityRole,string>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<SliderItem> SliderItems { get; set; }
    public DbSet<ApplyJob> ApplyJobs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "dfec424a-b225-4e2e-bd46-4b041b13abda", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "1cedefe1-ed59-4a08-89c2-1b4bc2ed00bb", Name = "User", NormalizedName = "USER" }
            );
        AppUser admin = new()
        {
            Id = "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            FirstName="Fizaret",
            LastName="Osmanov",
            PhotoPath="Admin.webp",
            Profession="Developer",
            Email="fizaratzo-ab205@code.edu.az",
            PhoneNumber="+994 (50) 732 5300",
            Address="Baku",
            Country="Azerbaijan"      
        };
        PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();


                                                               
        admin.PasswordHash = hasher.HashPassword(admin,"admin123");
        builder.Entity<AppUser>().HasData(admin);              


        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { UserId = admin.Id, RoleId = "dfec424a-b225-4e2e-bd46-4b041b13abda" });
        base.OnModelCreating(builder);
    }
}
