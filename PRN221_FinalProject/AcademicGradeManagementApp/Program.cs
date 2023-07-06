using Business.IRepository;
using Business.Repository;
using Bussiness.Mapping;
using DataAccess.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AddPageRoute("/login", "");
});
builder.Services.AddTransient<IAccountRepository, AccountRepository>()
    .AddDbContext<PRN221_PROJECTContext>(opt => builder.Configuration.GetConnectionString("WebConnectionString"));

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSession();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseHttpsRedirection();
app.UseSession();
app.UseStaticFiles();
app.MapRazorPages();
app.Run();
