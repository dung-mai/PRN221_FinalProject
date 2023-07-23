using Business.IRepository;
using Business.Repository;
using Bussiness.Mapping;
using DataAccess.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddRazorPages();
builder.Services.AddTransient<IAccountRepository, AccountRepository>()
    .AddDbContext<PRN221_ProjectContext>(opt => builder.Configuration.GetConnectionString("WebConnectionString"));
builder.Services.AddTransient<IStudentRepository, StudentRepository>()
    .AddDbContext<PRN221_ProjectContext>(opt => builder.Configuration.GetConnectionString("WebConnectionString"));
builder.Services.AddTransient<IStudyCourseRepository, StudyCourseRepository>()
    .AddDbContext<PRN221_ProjectContext>(opt => builder.Configuration.GetConnectionString("WebConnectionString"));
builder.Services.AddTransient<IGradeComponentRepository, GradeComponentRepository>()
    .AddDbContext<PRN221_ProjectContext>(opt => builder.Configuration.GetConnectionString("WebConnectionString"));

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSession();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseSession();
app.UseStaticFiles();
app.MapRazorPages();
app.Run();
