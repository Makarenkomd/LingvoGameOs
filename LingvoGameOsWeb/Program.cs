using LingvoGameOs.Db;
using LingvoGameOs.Db.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ��������� ������ ����������� �� appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite(connectionString)); // ���������� ������ �����������

// ��������� �������� IndentityContext � �������� ������� � ����������
builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlite(connectionString));

// ��������� ��� ������������ � ����
builder.Services.AddIdentity<User, IdentityRole>()
                // ������������� ��� ��������� - ��� ��������
                .AddEntityFrameworkStores<IdentityContext>();

// ��������� cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.Cookie = new CookieBuilder
    {
        IsEssential = true
    };
});

builder.Services.AddTransient<IGamesRepository, GamesDbRepository>();
builder.Services.AddTransient<IPlayerUsersRepository, PlayerUsersDbRepository>();
builder.Services.AddTransient<IDevUsersRepository, DevUsersDbRepository>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

// ����������� ��������������
app.UseAuthentication();

// ����������� �����������
app.UseAuthorization();

// ������������� ��������������
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    IdentityInitializer.Initialize(userManager, rolesManager);
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
