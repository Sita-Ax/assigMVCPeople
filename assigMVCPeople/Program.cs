using assigMVCPeople.Models.DB;
using assigMVCPeople.Models.Repos;
using assigMVCPeople.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<PeopleDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPeopleRepo, DbPeopleRepo>();
builder.Services.AddScoped<IPeopleService, PeopleService>();

builder.Services.AddScoped<ICountryRepo, DbCountryRepo>();
builder.Services.AddScoped<ICountryService, CountryService>();

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<PeopleDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<ICityRepo, DbCityRepo>();
builder.Services.AddScoped<ICityService, CityService>();

builder.Services.AddScoped<ILanguageRepo, DbLanguageRepo>();
builder.Services.AddScoped<ILanguageService, LanguageService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

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
app.UseAuthentication();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();

