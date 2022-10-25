using RookiesShop.Api.Data;
using Microsoft.EntityFrameworkCore;
using RookiesShop.Api.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//connection string
builder.Services.AddDbContext<RookieShopdbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RookieShop")));

//add service
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IUserService,UserService>();
//next
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
