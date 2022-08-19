using static meli_mutations.Entity.Entities;

namespace meli_mutations.Repository;

public interface IMutantRepository {
    Task<Azure.Response> Add(Mutant entity);
    Task<Mutant?> Get(string rowKey);
    Task<IEnumerable<Mutant>> All();
}