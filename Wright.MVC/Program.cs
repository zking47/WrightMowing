using Microsoft.EntityFrameworkCore;
using Wright.Data;
using Wright.Models.AutoMap;
using Wright.Services.CategoryServices;
using Wright.Services.ListingServices;
using Wright.Services.MowerTypeServices;
using Wright.Services.SalesInventoryServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WrightDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IListingService, ListingService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISalesInventoryService, SalesInventoryService>();
builder.Services.AddScoped<IMowerTypeService, MowerTypeService>();
builder.Services.AddAutoMapper(typeof(ListingMapProfile));
builder.Services.AddAutoMapper(typeof(CategoryMapProfile));
builder.Services.AddAutoMapper(typeof(SalesInventoryMapProfile));
builder.Services.AddAutoMapper(typeof(MowerTypeMapProfile));

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
