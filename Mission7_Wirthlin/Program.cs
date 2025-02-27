using Microsoft.EntityFrameworkCore;
using Mission7_Wirthlin.Data;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Configure EF Core with SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=/Users/nicko/RiderProjects/Mission7_Wirthlin/JoelHiltonMovieCollection.sqlite"));

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();