using System;
using BL;
using BL.Profiles;
using BL.Services.Abstractions;
using BL.Services.Implementations;
using DATA;
using DATA.Contexts;
using DATA.Repositories.Abstractions;
using DATA.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ISliderItemService,SliderItemService>();
builder.Services.AddScoped<ISliderItemRepository,SliderItemRepository>();
builder.Services.AddAutoMapper(typeof(SliderItemProfile));
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
//builder.Services.BLServices();
//builder.Services.DATAServices();

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
