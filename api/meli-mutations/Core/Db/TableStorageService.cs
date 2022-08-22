using Azure.Data.Tables;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace meli_mutations.Db;

[ExcludeFromCodeCoverage]
public class TableStorageService<T> :
          ITableStorageService<T> where T : class, ITableEntity, new()
{
    private readonly TableClient _tableClient;

    public TableStorageService(TableServiceClient tableServiceClient, string tableName)
        => _tableClient = tableServiceClient.GetTableClient(tableName);

    public async Task<Azure.Response> AddEntityAsync(T value)
        => await _tableClient.AddEntityAsync<T>(value);

    public async Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> query)
            => await _tableClient.QueryAsync(query).ToListAsync();
}