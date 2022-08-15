using meli_mutations.Db;

namespace meli_mutations.Repository;

public class KvRespository {
    public CosmosDbCtx db {get; set;}
    public string GetValue(string key) {
        return this.db.GetVal(key);
    }
}