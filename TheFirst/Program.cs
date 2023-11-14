using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TheFirst.Controllers.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// Notes

// When you configure database in your project, and you add that to dependency injection,
// We will be adding a new service here in our container can DbContext.

// Everything under the the HTTP request pipeline specifies how your application
// will respond to a web request.

// .Net core pipeline...
// 1. Request from Browser
// Auth, MVC, Static files... these are all middlewares that the goes through

// MVC - Model, View, Controllers
// Model - Represents the shape of the data
// Views - Represents the user interface
// Controllers - Handles the user request and acts as an interface between Model and View

// Routing Overview
// The URL pattern for routing is considered after the domain name.
// localhostL55555/{controller}/{action}/{id?}, id is optional
// localhost:55555/Category/Index/3

// Tag Helpers
// Enable server-side code to participate in creating and rendering HTML elements in Razor files.
// Very focused around the html elements and much more natural to use. 

// Action Result - return type which will return a View()
// Action Result in MVC
// ViewResult: View(): Renders a view as a Web Page
// PartialViewResult:PartialView()
// RedirectResult: Redirect()
// RedirectToRouteResult(): RedirectToAction()
// ContentResult: Content()
// JsonResult: Json
// JavaScriptResult:JavaScript()
// FileResult: File
// EmptyResult: (None)
// IActionResult can help with the return type because
// it is an overarching return type for any of the previous things mentioned