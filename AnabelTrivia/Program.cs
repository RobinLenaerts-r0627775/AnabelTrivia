using AnabelTrivia.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var _configurations = new ConfigurationManager();
// Add services to the container.
builder.Services.AddRazorPages();
//var connectionstring = builder.Configuration.GetConnectionString("Reynolds");
var connectionstring = "server=localhost;port=3306;database=AnabelTrivia;user=admin;password=klp246135;pooling=false";
builder.Services.AddDbContextPool<DatabaseContext>(options => options
    .UseMySQL(connectionstring));
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();