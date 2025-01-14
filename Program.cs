using System.Configuration;
using Microsoft.EntityFrameworkCore;
using ProjectDotNET.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian hết hạn session
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Cấu hình session
builder.Services.AddDistributedMemoryCache(); // Cung cấp bộ nhớ phân tán để lưu trữ session
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian hết hạn session
});

builder.Services.AddDbContext<Shop_Context>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("kiemtraketnoi"))
);

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
app.UseSession();

// Sử dụng session middleware
app.UseSession(); // Thêm dòng này để sử dụng session

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
