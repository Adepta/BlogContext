using DataLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DataLibrary.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("EFBlogContextConnection") ?? throw new InvalidOperationException("Connection string 'EFBlogContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Entity Framework Database
builder.Services.AddDbContext<EFBlogContext>(options =>
    options.UseSqlServer(
        
        // Change this line when you are running it locally - I use Docker as my DB.
        "Data Source=host.docker.internal;Initial Catalog=BlogDatabase;User Id=sa;Password=S3cur3P@ssW0rd!;Integrated Security=False;MultipleActiveResultSets=True;TrustServerCertificate=True;"));

builder.Services.AddDefaultIdentity<BlogUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<EFBlogContext>();

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
app.MapRazorPages();

app.Run();

