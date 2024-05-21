using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Travela.DataAccessLayer.Context;
using Travela.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<TravelaContext>();
builder.Services.AddDbContext<TravelaContext>();
builder.Services.AddHttpClient();
var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
// PROJE GENEELÝ AUTHENTÝCATÝON
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});

builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.LoginPath = "/Login/Index";
});
// Add services to the container.
builder.Services.AddControllersWithViews();

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
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
