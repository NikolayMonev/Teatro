using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Teatro.Data;
using Teatro.Models;

var builder = WebApplication.CreateBuilder(args);

// ����������� ��������� �� ������ �����
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));  // ��� ��������� ����� ���� �����

// ����������� Identity � RoleStore
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// �������� �� ����� ������
builder.Services.AddControllersWithViews();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
