using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace meli_mutations.Model;

public class Models {

    public class DnaRequest
    {
        [JsonPropertyName("dna")]
        public string[] Dna { get; set; } = default!;
    }

    public class StatsResponse {
        [JsonPropertyName("count_mutant_dna")]
        public int CountMutantDna { get; set; }
        [JsonPropertyName("count_human_dna")]
        public int CountHumanDna { get; set; }
        [JsonPropertyName("ratio")]
        public double Ratio { get; set; }
    }
}
