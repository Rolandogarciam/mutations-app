using Azure.Data.Tables;
using meli_mutations.Db;
using meli_mutations.Repository;
using static meli_mutations.Entity.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddResponseCaching();
builder.Services.AddSingleton<TableServiceClient>(new TableServiceClient(Environment.GetEnvironmentVariable("COSMOS_CONNECTION_STRING")));
builder.Services.AddSingleton<ITableStorageService<Mutant>>(provider =>
    new TableStorageService<Mutant>(provider.GetRequiredService<TableServiceClient>(), "mutations-app"));
builder.Services.AddScoped<IMutantRepository, MutantRepository>();


builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors();

app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();

app.Run();
