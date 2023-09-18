using FileStorageAPI;
using FileStorageAPI.Services;
using Microsoft.Extensions.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.Configure<AppSettings>(opts => builder.Configuration.GetSection("AppSettings").Bind(opts));

//serilog configuration
var serilogConfiguration = new LoggerConfiguration()
    .WriteTo.File("log.txt")
    .CreateLogger();

//setting the logging providers
builder.Services.AddLogging(x =>
{
    //if you want to remove all default registered logging providers
    //x.ClearProviders();

    //console logging is default
    //x.AddConsole();

    x.AddSerilog(serilogConfiguration);

    //if you want with one logger to log on more places add in configuration
    //for example if we put addconsole and addserilog in the configuration, the created logger will log on both places, in console and in file
});
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
