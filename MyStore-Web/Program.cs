using Microsoft.EntityFrameworkCore;
using MyStore_Core.Interfaces;
using MyStore_Core.Mapping_Profiles;
using MyStore_Core.Servicess;
using MyStore_Data.Entities;
using MyStore_Web.Mapping_profile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyStoreDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionname"));
});
builder.Services.AddAutoMapper(typeof(SliderProfile));
builder.Services.AddAutoMapper(typeof(SliderviewProfile));
builder.Services.AddScoped<ISliderServicess, SliderServicess>();
builder.Services.AddScoped<IFileManager, FileManager>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
