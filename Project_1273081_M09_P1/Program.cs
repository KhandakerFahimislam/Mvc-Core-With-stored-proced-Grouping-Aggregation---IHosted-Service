using Microsoft.EntityFrameworkCore;
using Project_1273081_M09_P1.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TeacherDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();