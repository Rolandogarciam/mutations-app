using Azure;
using Azure.Data.Tables;

namespace meli_mutations.Entity;

public class Entities {
    public record Mutant : ITableEntity
    {
        public string RowKey { get; set; } = default!;

        public string PartitionKey { get; set; } = default!;

        public bool Value { get; init; } = default!;

        public ETag ETag { get; set; } = default!;

        public DateTimeOffset? Timestamp { get; set; } = default!;
    }
}