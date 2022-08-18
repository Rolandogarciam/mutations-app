using meli_mutations.Core.Resolver;
using Xunit;

namespace meli_test;

public class DnaResovlerTest
{
    [Fact]
    public void WhenTheDnaIsHuman()
    {   
        string[] dna = new string[] {
            "GTGTGTA",
            "CGTCTAA",
            "TCTCATA",
            "ACTATGC",
            "GAATGAC",
            "CAACTAG",
            "AGGGTCG"
        };

        Assert.Equal(false, MutantResolver.Resolve(dna));
    }

    [Fact]
    public void WhenTheDnaIsMutant()
    {   
        string[] dna = new string[] {
            "GTGTGTA",
            "CGTCTAA",
            "TCTCATA",
            "ACTATGC",
            "GAATGAC",
            "CAACTAG",
            "AGGGTCG"
        };
        
        Assert.Equal(true, MutantResolver.Resolve(dna));
    }

    [Fact]
    public void WhenTheDnaIsLargeAndIsMutant()
    {   
        string[] dna = new string[] {
            "GTGTGTA",
            "CGTCTAA",
            "TCTCATA",
            "ACTATGC",
            "GAATGAC",
            "CAACTAG",
            "AGGGTCG"
        };
        
        Assert.Equal(true, MutantResolver.Resolve(dna));
    }

    [Fact]
    public void WhenTheDnaLenIsLessThanPattern()
    {   
        string[] dna = new string[] {
            "GTG",
            "CGT",
            "TCT",
        };
        
        Assert.Equal(false, MutantResolver.Resolve(dna));
    }

    [Fact]
    public void WhenTheDnaIsMutantPatternContinuesX()
    {    
        string[] dna = new string[] {
            "ACGTAC",
            "ACGTAC",
            "GTTTTA",
            "CAAAAG",
            "ACGTAC",
            "CAACTA"
        };
        
        Assert.Equal(true, MutantResolver.Resolve(dna));
    }

    [Fact]
    public void WhenTheDnaIsMutantPatternContinuesY()
    {    
        string[] dna = new string[] {
            "ACAGAA",
            "ACGTAC",
            "TTGTGA",
            "CGGTGT",
            "ACGTAA",
            "CAACTA"
        };
        
        Assert.Equal(true, MutantResolver.Resolve(dna));
    }
}