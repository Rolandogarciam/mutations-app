using System.Linq.Expressions;

namespace meli_mutations.Db;

public interface ITableStorageService<T> {
    Task<List<T>> QueryAsync(Expression<Func<T, bool>> query);
    Task<IEnumerable<T>> GetAllRowsAsync();
    Task<Azure.Response> AddEntityAsync(T value);
}