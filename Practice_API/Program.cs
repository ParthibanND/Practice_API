using BussinessLayer.Repository;
using BussinessLayer.RepositoryManager;
using Data.Model.Authentication;
using DataAcessLayer.Repository;
using DataAcessLayer.RepositoryManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connectionString = builder.Configuration.GetConnectionString("LocalDb");
builder.Services.AddDbContext<DataBase.Model.Models.PrjDashBoardContext>(Options => Options.UseSqlServer(connectionString));
builder.Services.AddScoped(typeof(DataBase.Model.Models.PrjDashBoardContext));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

# region JWTSettings
var jwetsetting = builder.Configuration.GetSection("JWTSetting");
builder.Services.Configure<JWTSetting>(jwetsetting);
var authkey = builder.Configuration.GetValue<string>("JWTSetting.SecurityKey") ?? "thisismysecuritykey";
builder.Services.AddAuthentication(item =>
{
    item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(item =>
{
    item.RequireHttpsMetadata = true;
    item.SaveToken = true;
    item.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authkey)),
    };
});
# endregion

# region DataAcessLayer
builder.Services.AddTransient<ICommonData,CommonData>();
builder.Services.AddTransient<IAuthenticationData,AuthenticationData>();
# endregion
# region BussinessLayer
builder.Services.AddTransient<ICommon,Common>();
builder.Services.AddTransient<IAuthentication, Authentication>();
# endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
