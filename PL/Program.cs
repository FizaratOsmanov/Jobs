using BL.Profiles;
using BL.Services.Abstractions;
using BL.Services.Implementations;
using DATA.Contexts;
using DATA.Repositories.Abstractions;
using DATA.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ISliderItemService,SliderItemService>();
builder.Services.AddScoped<ISliderItemRepository,SliderItemRepository>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IJobRepository,JobRepository>();
builder.Services.AddScoped<IJobService,JobService>();
builder.Services.AddAutoMapper(typeof(SliderItemProfile));
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
