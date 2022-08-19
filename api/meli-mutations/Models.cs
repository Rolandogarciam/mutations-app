using System.Runtime.Serialization;

namespace meli_mutations.Model;

public class Models {
    
    public class DnaRequest
    {
        public string[] dna { get; set; } = default!;
    }

    public class StatsResponse {
        public int count_mutant_dna { get; set; }
        public int count_human_dna { get; set; }
        public double ratio { get; set; }
    }
}
