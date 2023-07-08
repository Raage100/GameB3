using Game.Api;
using Game.Application;
using Game.Infrastructure;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPresentation()
                .AddApplication()
                .AddInfrastructure(builder.Configuration);
                
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy =>
    policy.WithOrigins("https://localhost:7211", "http://localhost:5222")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
);
app.UseExceptionHandler("/error");
app.UseAuthorization();

app.MapControllers();

app.Run();


