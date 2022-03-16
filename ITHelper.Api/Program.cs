using ITHelper.Application.Contracts.Persistence;
using ITHelper.Application.Features.NetworkFeatures;
using ITHelper.Application.Services;
using ITHelper.Persistence.Repositories.ApiClient;
using ITHelper.Persistence.Services;
using ITHelper.Identity.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureIdentityServices(builder.Configuration);


builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

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

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();
