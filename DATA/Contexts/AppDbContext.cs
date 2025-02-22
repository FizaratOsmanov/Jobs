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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "021a3b3d-22f9-42e7-9aa3-7a3b09375ff5", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "bb7c4e4a-6dfd-4681-a78f-9c5a9f90ed4c", Name = "User", NormalizedName = "USER" }
            );
        AppUser admin = new()
        {
            Id = "9418a5f2-920a-48aa-8e48-9a7b388a1fed",
            UserName = "fizaret",
            NormalizedUserName = "FIZARET",
            FirstName="Fizaret",
            LastName="Osmanov",
            PhotoPath="admin.jpg",
            Profession="Developer",
            Email="fizaratzo-ab205@code.edu.az",
            PhoneNumber="+994 (50) 732 5300",
            Address="Baku",
            Country="Azerbaijan"      
        };
        PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();


                                                                
        admin.PasswordHash = hasher.HashPassword(admin,"fizaret123");
        builder.Entity<AppUser>().HasData(admin);              


        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { UserId = admin.Id, RoleId = "021a3b3d-22f9-42e7-9aa3-7a3b09375ff5" });
        base.OnModelCreating(builder);
    }
}
