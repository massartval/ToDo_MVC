using Microsoft.Extensions.DependencyInjection;
using ToDo_MVC.Models.Repositories;
using ToDo_MVC.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;
services.AddControllersWithViews();
services.AddHttpClient("Api", client =>
{
    client.BaseAddress = new Uri(configuration.GetSection("api").Value);
    //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
});
services.AddScoped<IItemRepository, ItemService>();

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
