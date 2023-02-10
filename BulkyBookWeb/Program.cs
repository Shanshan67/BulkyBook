using BulkyBookWeb.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages().AddRazorRuntimeCompilation();because of hot reload and the magic that have,this is no longer required
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContactsApiConnectionString")));
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
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

app.UseRouting();//routing will be done and it checked for authorization;if want to use authentication to pipeline,so
//app.UseAuthentication();//验证，before authorization
app.UseAuthorization();//授权

app.MapControllerRoute(//map the different pattern that we have for MVC.Based on this routing, it will be able to redirect a request to the cossesponding controllers and action
    name: "default",//have defined a default route
    pattern: "{controller=Home}/{action=Index}/{id?}");//https://localhost:xxx/{controller}/{action}/{id}; after port number will be the route that we want to use

app.Run();


