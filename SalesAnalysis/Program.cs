using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;
using SalesAnalysis.DataAccess;
using SalesAnalysis.Interfaces.DataAccess;
using SalesAnalysis.Interfaces.Services;
using SalesAnalysis.Models;
using SalesAnalysis.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<SaleDatabaseSettings>(
    builder.Configuration.GetSection(nameof(SaleDatabaseSettings))
);
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600;
});

builder.Services.AddSingleton<ISaleDataAccess, SaleDataAccess>();
builder.Services.AddSingleton<ISaleService, SaleService>();

builder.Services.AddSingleton<SaleDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<SaleDatabaseSettings>>().Value);
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
