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

}
