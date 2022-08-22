using meli_mutations.Core.Resolver;
using Xunit;

namespace meli_test;

public class DnaIsInvalid
{
    [Fact]
    public void WhenTheDnaContainsDifferentLenght()
    {
        string[] dna = new string[] {
            "GTGA",
            "CGTA",
            "TCTA",
            "TAGTA"
        };

        Assert.False(MutantResolver.Resolve(dna));
    }

    [Fact]
    public void WhenTheDnaLenIsLessThanPattern()
    {
        string[] dna = new string[] {
            "GTG",
            "CGT",
            "TCT",
        };

        Assert.False(MutantResolver.Resolve(dna));
    }
}