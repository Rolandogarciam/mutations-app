using Azure.Data.Tables;
using meli_mutations.Db;
using meli_mutations.Repository;
using static meli_mutations.Entity.Entities;

namespace meli_mutations;

public class Program 
{
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddResponseCaching();
        builder.Services.AddSingleton<TableServiceClient>(new TableServiceClient(Environment.GetEnvironmentVariable("COSMOS_CONNECTION_STRING")));
        builder.Services.AddSingleton<ITableStorageService<Mutant>>(provider =>
            new TableStorageService<Mutant>(provider.GetRequiredService<TableServiceClient>(), "mutant-app"));
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
    }
} 