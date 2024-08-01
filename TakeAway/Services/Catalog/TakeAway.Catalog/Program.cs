using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Reflection;
using TakeAway.Catalog.Services.CategoryServices;
using TakeAway.Catalog.Services.DailyDiscountServices;
using TakeAway.Catalog.Services.ProductServices;
using TakeAway.Catalog.Services.SliderServices;
using TakeAway.Catalog.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IDailyDiscountService, DailyDiscountService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISliderService, SliderService>();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCatalog";
    opt.RequireHttpsMetadata = false;
});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddControllers();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
