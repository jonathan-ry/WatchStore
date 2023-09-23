using AutoMapper;
using Client.Interfaces;
using Client.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Local host
//string baseUrl = "https://localhost:7066/api";

//Prod
string baseUrl = "https://acn-watchstore.azurewebsites.net/api";
builder.Services.AddScoped<IApiService>(s =>
{
    //Get services
    var serviceProvider = s.GetRequiredService<IServiceProvider>();

    //Get mapper service from services
    var mapper = serviceProvider.GetRequiredService<IMapper>();

    // Create an instance of ApiService with the base URL and AutoMapper
    return new ApiService(baseUrl, mapper);
});

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
