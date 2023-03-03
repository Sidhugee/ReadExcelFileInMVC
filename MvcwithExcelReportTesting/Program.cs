using Microsoft.EntityFrameworkCore;
using MvcwithExcelReportTesting.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connectionString = "Server=DESKTOP-9B46UUQ; Database=PracticeWork;TrustServerCertificate=True;Trusted_Connection=SSPI;";
builder.Services.AddDbContext<CustomerContext>(option =>option.UseSqlServer(connectionString));
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
    pattern: "{controller=ExcelDatabase}/{action=Index}/{id?}");

app.Run();
