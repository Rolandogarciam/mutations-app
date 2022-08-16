using System.Runtime.Serialization;

namespace meli_mutations.Model;

public class Models {
    public class DnaRequest
    {
        [DataMember(Name="data")]
        public string[] Data { get; set; } = default!;
    }

    public class DnaResponse
    {
        [DataMember(Name="result")]
        public bool Result { get; set; }
    }

    public class StatusResponse {
        
    }
}
