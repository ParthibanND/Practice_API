using BussinessLayer.Repository;
using BussinessLayer.RepositoryManager;
using DataAcessLayer.Repository;
using DataAcessLayer.RepositoryManager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connectionString = builder.Configuration.GetConnectionString("LocalDb");
builder.Services.AddDbContext<DataBase.Model.Models.PrjDashBoardContext>(Options => Options.UseSqlServer(connectionString));
builder.Services.AddScoped(typeof(DataBase.Model.Models.PrjDashBoardContext));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

# region DataAcessLayer
builder.Services.AddTransient<ICommonData,CommonData>();
# endregion
# region BussinessLayer
builder.Services.AddTransient<ICommon,Common>();
# endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
