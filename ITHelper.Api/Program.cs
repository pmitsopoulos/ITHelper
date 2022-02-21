using ITHelper.Application.Contracts.Persistence;
using ITHelper.Application.Features.NetworkFeatures;
using ITHelper.Persistence.Repositories.ApiClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<PingNetwork>();

builder.Services.AddScoped<IApiMethodHelper>(s => new ApiMethodHelper(new HttpClient()));
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
