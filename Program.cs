
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using WebApplication2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Database connection wtih the npgsql lib as we link it to the docker container
builder.Services.AddDbContext<CoffeeContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Host=localhost;Database=postgres;Username=postgres;Password=abc")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        // pattern: "{controller=Coffee}/{action=Index}")
        pattern: "{controller=Coffee}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();