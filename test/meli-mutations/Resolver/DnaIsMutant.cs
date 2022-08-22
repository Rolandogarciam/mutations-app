using meli_mutations.Core.Resolver;
using Xunit;

namespace meli_test.Resolver
{
    public class DnaIsMutantTest
    {
        [Fact]
        public void WhenTheDnaIsIntersectionWithDifferentDirection()
        {
            string[] dna = new string[] {
                "GCCAV",
                "CGCCT",
                "CCCCC",
                "CGCGT",
                "TGCAT"
            };
            Assert.True(MutantResolver.Resolve(dna));
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
        public void WhenTheDnaIsMutantPatternContinuousHorizontal()
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
        public void WhenTheDnaIsMutantPatternContinuousVertical()
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
        public void WhenTheDnaIsMutantWithSameDirectionHorizontal()
        {
            // See main diagonal
            string[] dna = new string[] {
                "GGGGGGGGGG",
                "AAGTACGTAC",
                "CTCCTTCCTT",
                "CCTCTTCCTT",
                "TTTCGCGGGA",
                "AAGTAGCTAG",
                "ACGTGTGCCT",
                "GGCTTAGGAC",
                "TACGACGTAC",
                "AGCGGTACAG"
            };
            Assert.True(MutantResolver.Resolve(dna));
        }

        [Fact]
        public void WhenTheDnaIsMutantWithSameDirectionOblique()
        {
            // See main diagonal
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

        [Fact]
        public void WhenTheDnaIsMutantWithSameDirectionObliqueNorthEast()
        {
            // See main diagonal
            string[] dna = new string[] {
                "CCGTACGTAC",
                "ATGTACGTCC",
                "CTAGTTCCTT",
                "CCTTGTCCTT",
                "TTTCACGGGA",
                "AAGTCCCTAG",
                "ACGCGTGCCT",
                "GGCTTAGGAC",
                "TCCGACGTAC",
                "AGCGGTACAA"
            };
            Assert.True(MutantResolver.Resolve(dna));
        }

        [Fact]
        public void WhenTheDnaIsMutantWithSameDirectionVertical()
        {
            string[] dna = new string[] {
                "GCGTACGTAC",
                "GCGTACGTAC",
                "GTTGTTCCTT",
                "GCTCTTCCTT",
                "GTTCCCGGGA",
                "GAGTAGCTAG",
                "GCGTGTACCT",
                "GGCTTAGAAC",
                "GACGACGTAC",
                "GGCGGTACAG"
            };
            Assert.True(MutantResolver.Resolve(dna));
        }
    }
}