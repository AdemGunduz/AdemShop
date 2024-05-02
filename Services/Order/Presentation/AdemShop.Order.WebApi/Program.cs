using AdemShop.Order.Application.Features.CQRS.Handlers.AddressHandler;
using AdemShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandler;
using AdemShop.Order.Application.Interfaces;
using AdemShop.Order.Application.Services;
using AdemShop.Order.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddApplicationService(builder.Configuration);

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();