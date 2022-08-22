using meli_mutations.Db;
using System.Diagnostics.CodeAnalysis;
using static meli_mutations.Entity.Entities;

namespace meli_mutations.Repository;

[ExcludeFromCodeCoverage]
public class MutantRepository : IMutantRepository
{
    private readonly ITableStorageService<Mutant> _tableStorageService;

    public MutantRepository(ITableStorageService<Mutant> tableStorageService)
    {
        if (tableStorageService == null)
        {
            throw new ArgumentException("tableStorageService is not initilize");
        }
        _tableStorageService = tableStorageService;
    }

    public async Task<Azure.Response> Add(Mutant entity)
        => await this._tableStorageService.AddEntityAsync(entity);

    public async Task<IEnumerable<Mutant>> All()
        => await this._tableStorageService.QueryAsync(x => x.PartitionKey == "mutations");

    public async Task<Mutant?> Get(string rowKey)
    {
        var entity = await this._tableStorageService.QueryAsync(x => x.RowKey == rowKey && x.PartitionKey == "mutations");
        return entity.FirstOrDefault();
    }
}