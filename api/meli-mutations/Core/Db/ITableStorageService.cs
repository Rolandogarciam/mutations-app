using System.Linq.Expressions;

namespace meli_mutations.Db;

public interface ITableStorageService<T> {
    Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> query);
    Task<Azure.Response> AddEntityAsync(T value);
}