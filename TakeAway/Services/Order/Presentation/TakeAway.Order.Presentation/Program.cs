using TakeAway.Order.Application.Features.CQRS.Handlers.AdressHandlers.Read;
using TakeAway.Order.Application.Features.CQRS.Handlers.AdressHandlers.Write;
using TakeAway.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Read;
using TakeAway.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Write;
using TakeAway.Order.Application.Interfaces;
using TakeAway.Order.Application.Services;
using TakeAway.Order.Persistence.Context;
using TakeAway.Order.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<OrderContext>();

#region CQRS OrderDetail
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>(); 
builder.Services.AddScoped<GetOrderDetailQueryHandler>(); 
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
builder.Services.AddScoped<DeleteOrderDetailCommandHandler>();
#endregion

#region CQRS Adress

builder.Services.AddScoped<GetAdressByIdQueryHandler>();
builder.Services.AddScoped<GetAdressQueryHandler>();
builder.Services.AddScoped<CreateAdressCommandHandler>();
builder.Services.AddScoped<UpdateAdressCommandHandler>();
builder.Services.AddScoped<DeleteAdressCommandHandler>();
#endregion

builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
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
