using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace meli_mutations.Core;

public static class MutantResolver {
    //   Complexity
    //   Time: O(n^2) Quadratic Time
    //   Space: O(1)
    public static bool Resolve(string[] dna) 
    {
        StringBuilder strBldrSouth = new StringBuilder();
        StringBuilder strBldrEast = new StringBuilder();
        StringBuilder strBldrSouthEast = new StringBuilder();
        StringBuilder strBldrNorthEast = new StringBuilder();
        
        string[] feasibleResult = {"AAAA", "GGGG", "CCCC", "TTTT"};
        int N = dna.Length;
        
        int mutations = 2;

        for (int x = 0; x < N; x++) 
        {
            for (int y = 0; y < N; y++) 
            {
                if (mutations <= 0) 
                    break;

                if (y < N - 3 - 1 ) { 
                    strBldrSouth.Append(dna[x][y]);
                    strBldrSouth.Append(dna[x][y + 1]);
                    strBldrSouth.Append(dna[x][y + 2]);
                    strBldrSouth.Append(dna[x][y + 3]);

                }

                if (x < N - 3 - 1) {
                    strBldrEast.Append(dna[x][y]);
                    strBldrEast.Append(dna[x + 1][y]);
                    strBldrEast.Append(dna[x + 2][y]);
                    strBldrEast.Append(dna[x + 3][y]);
                }

                if (x < N - 3 - 1 && y < N - 3 - 1 ) { 
                    strBldrSouthEast.Append(dna[x][y]);
                    strBldrSouthEast.Append(dna[x + 1][y + 1]);
                    strBldrSouthEast.Append(dna[x + 2][y + 2]);
                    strBldrSouthEast.Append(dna[x + 3][y + 3]);
                }


                if (x < N - 3 - 1 && y > 3) {
                    strBldrNorthEast.Append(dna[x][y]);
                    strBldrNorthEast.Append(dna[x + 1][y - 1]);
                    strBldrNorthEast.Append(dna[x + 2][y - 2]);
                    strBldrNorthEast.Append(dna[x + 3][y - 3]);
                }

                if (feasibleResult.Any(x => x == strBldrSouth.ToString()))
                    mutations--;
                
                if (feasibleResult.Any(x => x == strBldrSouthEast.ToString()))
                    mutations--;

                if (feasibleResult.Any(x => x == strBldrEast.ToString()))
                    mutations--;

                if (feasibleResult.Any(x => x == strBldrNorthEast.ToString()))
                    mutations--;
                
                strBldrSouth.Clear();
                strBldrEast.Clear();
                strBldrSouthEast.Clear();
                strBldrNorthEast.Clear();
            }
        }
        return (mutations <= 0);
    } 
}