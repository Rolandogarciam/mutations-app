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

        Assert.False(MutantResolver.Resolve(dna));
    }

    [Fact]
    public void WhenTheDnaIsLargeAndIsMutant()
    {
        string[] dna = new string[] {
            "GTGTGTA",
            "CGTCTAA",
            "TCTCATA",
            "ACTATGC",
            "GAATTAC",
            "CAACTAG",
            "AGGGTCG"
        };

        Assert.True(MutantResolver.Resolve(dna));
    }

    [Fact]
    public void WhenTheDnaIsMutant()
    {
        string[] dna = new string[] {
            "GTGTGTA",
            "CGTCTAA",
            "TCTCATA",
            "ACTATGC",
            "GAATTAC",
            "CAACTAG",
            "AGGGTCG"
        };

        Assert.True(MutantResolver.Resolve(dna));
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

        Assert.True(MutantResolver.Resolve(dna));
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

        Assert.True(MutantResolver.Resolve(dna));
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

    [Fact]
    public void WhenTheDnaIsCoalitionWithDifferentDirection()
    {
        string[] dna = new string[] {
            "GCCAV",
            "CGCCT",
            "GCCCC",
            "CGCGT",
            "TGAAT"
        };

        Assert.True(MutantResolver.Resolve(dna));
    }

    [Fact]
    public void WhenTheDnaIsCoalitionWithSameDirection()
    {
        string[] dna = new string[] {
            "CCTAGCC",
            "CGCCTCA",
            "CGCACTA",
            "CTCGAAC",
            "CAGATGA",
            "CATATTA",
            "CACATCG"
        };
        Assert.False(MutantResolver.Resolve(dna));
    }

    [Fact]
    public void WhenTheDnaIsCoalitionWithSameDirectionOblique()
    {
        string[] dna = new string[] {
            "GCGTACGTAC",
            "AGGTACGTAC",
            "CTGGTTCCTT",
            "CCTGTTCCTT",
            "TTTCGCGGGA",
            "AAGTAGCTAG",
            "ACGTGTACCT",
            "GGCTTAGTAC",
            "TACGACGTAC",
            "AGCGGTACAG"
        };

        Assert.False(MutantResolver.Resolve(dna));
    }

    [Fact]
    public void WhenTheDnaIsMutantWithSameDirectionOblique()
    {
        string[] dna = new string[] {
            "GCGTACGTAC",
            "AGGTACGTAC",
            "CTGGTTCCTT",
            "CCTGTTCCTT",
            "TTTCGCGGGA",
            "AAGTAGCTAG",
            "ACGTGTGCCT",
            "GGCTTAGGAC",
            "TACGACGTAC",
            "AGCGGTACAG"
        };

        Assert.True(MutantResolver.Resolve(dna));
    }
}