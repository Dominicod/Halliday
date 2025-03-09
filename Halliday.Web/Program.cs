using Halliday.Infrastructure.Injections;
using Serilog;
using Serilog.Filters;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddSerilog(i =>
{
    i.Filter.ByExcluding(Matching.WithProperty<string>("RequestPath", p => p.StartsWith("/health")));
    i.WriteTo.Async(wt => wt.Console());
    i.ReadFrom.Configuration(configuration);
});
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseHealthChecks("/health");

app.Run();