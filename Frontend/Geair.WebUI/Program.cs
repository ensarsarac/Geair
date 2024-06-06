using FluentValidation.AspNetCore;
using Geair.WebUI.Models;
using Geair.WebUI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Configuration;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews().AddFluentValidation(opt =>
{
    opt.DisableDataAnnotationsValidation = true;
    opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
});

//JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("Token");
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/SignIn/";
    opt.LogoutPath = "/Login/SignOut/";
    opt.AccessDeniedPath = "/Pages/AccessDenied/";
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "GeairJwt";
});

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("RequiredAdminRole", x => x.RequireRole("admin"));
    opt.AddPolicy("RequiredModeratorRole", x => x.RequireRole("moderator", "admin"));
});

builder.Services.AddMvc(opt =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettingsBaseUrlKey"));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/Pages/ErrorPage");
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
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
