using Geair.Application.Interfaces;
using Geair.Application.Services;
using Geair.Application.Tools;
using Geair.Persistance.Concrete;
using Geair.Persistance.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatorService();
builder.Services.AddAutoMapperService();

builder.Services.AddDbContext<Context>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddScoped(typeof(IRoleRepository), typeof(RoleRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(IAircraftRepository), typeof(AircraftRepository));
builder.Services.AddScoped(typeof(ITravelRepository), typeof(TravelRepository));
builder.Services.AddScoped(typeof(IReservationTravelRepository), typeof(ReservationTravelRepository));
builder.Services.AddSingleton<ICloudStorageService, CloudStorageService>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();


//CORS politikalar�
builder.Services.AddCors(options =>
{
    options.AddPolicy("GeairWebApiCors",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

//Api tarafa�nda oturum a�ma i�lemi. Kullan�c� rollerine g�re apilere eri�im sa�lanmas�!!
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidAudience = JwtTokenModel.ValidAudience,
        ValidIssuer = JwtTokenModel.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenModel.Key)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime=true,
    };
});
//rollere g�re controller'a eri�im 
builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("RequiredAdminRole", x => x.RequireClaim(ClaimTypes.Role,"admin"));
    opt.AddPolicy("RequiredModeratorRole", x => x.RequireClaim(ClaimTypes.Role,"moderator","admin"));
});

//t�m apileri authorize seviyesine �ekme
builder.Services.AddMvc(cfg =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

    cfg.Filters.Add(new AuthorizeFilter(policy));
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("GeairWebApiCors");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
