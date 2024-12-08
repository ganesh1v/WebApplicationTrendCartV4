using Microsoft.EntityFrameworkCore;
using WebApplicationTrendCartV4.Models;
using WebApplicationTrendCartV4.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TrendCartContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TrendCartConStr")));
builder.Services.AddScoped<IRepo<Role>, RoleRepo>();
builder.Services.AddScoped<IRepo<User>, UserRepo>();
builder.Services.AddScoped<IRepo<UserProfile>, UserProfileRepo>();
builder.Services.AddScoped<IRepo<Category>, CategoriesRepo>();
builder.Services.AddScoped<IRepo<Product>, ProductsRepo>();
builder.Services.AddScoped<IRepo<Order>, OrdersRepo>();
builder.Services.AddScoped<IRepo<OrderDetail>, OrderDetailsRepo>();
builder.Services.AddScoped<IRepo<ShoppingCart>, ShoppingCartRepo>();
builder.Services.AddScoped<IRepo<Payment>, PaymentsRepo>();
builder.Services.AddScoped<IRepo<AnalyticsLog>, AnalyticsLogRepo>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
