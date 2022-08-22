using meli_mutations.Core.Resolver;
using Xunit;

namespace meli_test.Resolver
{
    public class DnaIsHumanTest
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
        public void WhenTheDnaIsHumanWithOnePattern()
        {
            string[] dna = new string[] {
                "GTGTGTA",
                "CGTCTAA",
                "TCTCGTA",
                "ACCCTGG",
                "GATTGAG",
                "CCACTAG",
                "AGGGTCG"
            };
            Assert.False(MutantResolver.Resolve(dna));
        }

        [Fact]
        public void WhenTheDnaIsIntersectionWithSameDirectionOblique()
        {
            // See main diagonal
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
        public void WhenTheDnaIsIntersectionWithSameDirectionObliqueNortEast()
        {
            // See main diagonal
            string[] dna = new string[] {
                "GCGTACGTAC",
                "ACGTACGTCC",
                "CTCGTTCCTT",
                "CCTGTCCCTT",
                "TTTCGCGGGA",
                "AAGTCACTAG",
                "ACGCGTACCT",
                "GGATTAGTAC",
                "TACGACGTAC",
                "AGCGGTACAG"
            };
            Assert.False(MutantResolver.Resolve(dna));
        }

        [Fact]
        public void WhenTheDnaIsIntersectionWithSameDirectionVertical()
        {
            // See first column
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
    }
}