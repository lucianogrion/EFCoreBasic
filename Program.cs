using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EFTestingAPP.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EFTestingAPPContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EFTestingAPPContext") ?? throw new InvalidOperationException("Connection string 'EFTestingAPPContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
