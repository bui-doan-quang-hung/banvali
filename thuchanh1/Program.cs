using Microsoft.EntityFrameworkCore;
using thuchanh1.Models;
using thuchanh1.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connecttionString = builder.Configuration.GetConnectionString("QlbanVaLiContext");
builder.Services.AddDbContext<QuanlibanvaliContext>(x => x.UseSqlServer(connecttionString));

builder.Services.AddScoped<ILoaispRespository,LoaispRespository>();
builder.Services.AddSession();


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
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Login}/{id?}");

app.Run();
