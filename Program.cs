using System.Configuration;
using Microsoft.EntityFrameworkCore;
using ProjectDotNET.Models;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ session và cấu hình session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian hết hạn session
    options.Cookie.HttpOnly = true;  // Đảm bảo cookie chỉ được truy cập qua HTTP
    options.Cookie.IsEssential = true; // Đảm bảo session cookie cần thiết cho ứng dụng
});
builder.Services.AddHttpContextAccessor();

// Thêm bộ nhớ phân tán cho session
builder.Services.AddDistributedMemoryCache(); // Cung cấp bộ nhớ phân tán để lưu trữ session

// Add services to the container.
builder.Services.AddControllersWithViews();

// Cấu hình DbContext với MySQL
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

// Sử dụng session middleware
app.UseSession(); // Đây là phần quan trọng, đảm bảo session được sử dụng trong pipeline

app.UseAuthorization();

// Cấu hình đường dẫn mặc định cho các controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
