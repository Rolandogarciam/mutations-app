using System.Text;

namespace meli_mutations.Core;

public static class MutantResolver {
    private const int MAX_MUTATION = 2;
    private const string A_PATTERN_MUTANT = "AAAA";
    private const string C_PATTERN_MUTANT = "CCCC";
    private const string G_PATTERN_MUTANT = "GGGG";
    private const string T_PATTERN_MUTANT = "TTTT";

    //   Complexity
    //   Time: O(n^2) Quadratic Time => m = matrix len
    //   Space: O(1)
    public static bool Resolve(string[] dna) 
    {
        int mutations = 0
        , N = dna.Length
        , M = A_PATTERN_MUTANT.Length
        , coordinateFoundX = N
        , coordinateFoundY = N;

        StringBuilder southStr = new StringBuilder()
        , eastStr = new StringBuilder()
        , southEastStr = new StringBuilder()
        , northEastStr = new StringBuilder();

        for (int y = 0; y < N; y++) 
        {
            for (int x = 0; x < N; x++) 
            {
                if (mutations >= MAX_MUTATION) 
                    break;
                    
                if (y < N-M && !IsCoalition(coordinateFoundX, coordinateFoundY, x, y, "south")) { 
                    southStr.Append(dna[y+0][x]);
                    southStr.Append(dna[y+1][x]);
                    southStr.Append(dna[y+2][x]);
                    southStr.Append(dna[y+3][x]);
                }

                if (x < N-M && !IsCoalition(coordinateFoundX, coordinateFoundY, x, y, "east")) {
                    eastStr.Append(dna[y][x+0]);
                    eastStr.Append(dna[y][x+1]);
                    eastStr.Append(dna[y][x+2]);
                    eastStr.Append(dna[y][x+3]);
                }

                if (y < N-M && x < N-M && !IsCoalition(coordinateFoundX, coordinateFoundY, x, y, "southEast")) { 
                    southEastStr.Append(dna[y][x]);
                    southEastStr.Append(dna[y+1][x+1]);
                    southEastStr.Append(dna[y+2][x+2]);
                    southEastStr.Append(dna[y+3][x+3]);
                }

                if (x < N-M && y >= M-1 && !IsCoalition(coordinateFoundX, coordinateFoundY, x+3, y-3, "northEast")) {
                    northEastStr.Append(dna[y][x]);
                    northEastStr.Append(dna[y-1][x+1]);
                    northEastStr.Append(dna[y-2][x+2]);
                    northEastStr.Append(dna[y-3][x+3]);
                }

                FindMutation(southStr.ToString(), x, y, ref coordinateFoundX, ref coordinateFoundY, ref mutations);
                FindMutation(eastStr.ToString(), x, y, ref coordinateFoundX, ref coordinateFoundY, ref mutations);
                FindMutation(southEastStr.ToString(), x, y, ref coordinateFoundX, ref coordinateFoundY, ref mutations);
                FindMutation(northEastStr.ToString(), x, y, ref coordinateFoundX, ref coordinateFoundY, ref mutations);

                southStr.Clear();
                eastStr.Clear();
                southEastStr.Clear();
                northEastStr.Clear();
            }
        }
        return (mutations >= MAX_MUTATION);
    } 

    private static void FindMutation(string pattern, int x, int y, ref int coordinateX, ref int coordinateY, ref int mutations) 
    {
        if(A_PATTERN_MUTANT == pattern || C_PATTERN_MUTANT == pattern || G_PATTERN_MUTANT == pattern || T_PATTERN_MUTANT == pattern) {
            mutations++;
            coordinateX = x;
            coordinateY = y;
        } 
    }

    //
    // Get rid with intersection between two line segment
    //
    private static bool IsCoalition(int coordinateFoundX, int coordinateFoundY, int coordinateX, int coordinateY, string direction) {
        bool result = false;
        switch (direction) {
            case "south":
                result = (
                    coordinateY == coordinateFoundY+1 
                    || coordinateY == coordinateFoundY+2
                    || coordinateY == coordinateFoundY+3);
                break;
            case "east":
                result = (
                    coordinateX == coordinateFoundX+1 
                    || coordinateX == coordinateFoundX+2
                    || coordinateX == coordinateFoundX+3);
                break;
            case "southEast":
                result = (
                    coordinateX == coordinateFoundX+1 
                    || coordinateX == coordinateFoundX+2
                    || coordinateX == coordinateFoundX+3)
                    && (
                    coordinateY == coordinateFoundY+1 
                    || coordinateY == coordinateFoundY+2
                    || coordinateY == coordinateFoundY+3);
                break;
            case "northEast":
                result = (
                    coordinateX == coordinateFoundX+1 
                    || coordinateX == coordinateFoundX+2
                    || coordinateX == coordinateFoundX+3)
                    && (
                    coordinateY == coordinateFoundY-1 
                    || coordinateY == coordinateFoundY-2
                    || coordinateY == coordinateFoundY-3);
                break;
            default:
                throw new InvalidOperationException("not found direction");
        }
        return result;
    }
}