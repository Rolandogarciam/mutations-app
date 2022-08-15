namespace meli_mutations.Db;

public class CosmosDbCtx {
    public string _connection;
    public string Connection {
        get => _connection;
        set => _connection = value;
    }

    public CosmosDbCtx() {

    }

    public string GetVal(string key) {
        return key;
    }

}