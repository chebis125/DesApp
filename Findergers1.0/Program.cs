using Findergers1._0.Hubs;
using Findergers1._0.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
    {
        options.AddPolicy("permitir",
            builder =>
            {
                builder.AllowAnyOrigin();
            });
    });
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddDbContext<DesappDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseCors("permitir");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HomePage}/{action=HomePage}/{id?}");

app.MapHub<ChatHub>("/chatHub");
app.Run();
