using System.Linq.Expressions;
using Azure.Data.Tables;

namespace meli_mutations.Db;

public class TableStorageService<T> : 
          ITableStorageService<T> where T : class, ITableEntity, new()
{
    private readonly TableClient _tableClient;

    public TableStorageService(TableServiceClient tableServiceClient, string tableName)
        => _tableClient = tableServiceClient.GetTableClient(tableName);

    public async Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> query)
        => await _tableClient.QueryAsync(query).ToListAsync();

    
    public async Task<Azure.Response> AddEntityAsync(T value)
        => await _tableClient.AddEntityAsync<T>(value);
}