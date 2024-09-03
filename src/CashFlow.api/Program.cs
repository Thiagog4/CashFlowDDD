using CashFlow.api.Filters;
using CashFlow.api.Middleware;
using CashFlow.Application;
using CashFlow.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddMvc(options=> options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddInfrastructure();
builder.Services.AddApplication();
var app = builder.Build();

app.UseMiddleware<CultureMiddleware>();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
