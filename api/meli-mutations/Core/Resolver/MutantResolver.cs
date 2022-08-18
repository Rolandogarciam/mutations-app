using System.Text;

namespace meli_mutations.Core.Resolver;

public static class MutantResolver {
    private const int MAX_MUTATION = 2;
    public const string A_PATTERN_MUTANT = "AAAA";
    public const string C_PATTERN_MUTANT = "CCCC";
    public const string G_PATTERN_MUTANT = "GGGG";
    public const string T_PATTERN_MUTANT = "TTTT";

    //   Complexity
    //   Time: O(n^2*m) Quadratic Time => n = matrix len & m = pattern length
    //   Space: O(1)
    public static bool Resolve(string[] dna) 
    {
        int mutations = 0
        , N = dna.Length
        , M = A_PATTERN_MUTANT.Length
        , coordinateFoundX = N+1
        , coordinateFoundY = N+1;

        if (!ValidDna(dna))
            return false; 

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
                
                for(int k = 0;k < M; k++) {

                    if (y <= N-M && !IsCoalition(coordinateFoundX, coordinateFoundY, x, y, "south")) {
                        southStr.Append(dna[y+k][x]);
                    }

                    if (x <= N-M && !IsCoalition(coordinateFoundX, coordinateFoundY, x, y, "east")) {
                        eastStr.Append(dna[y][x+k]);
                    }

                    if (y <= N-M && x < N-M && !IsCoalition(coordinateFoundX, coordinateFoundY, x, y, "southEast")) { 
                        southEastStr.Append(dna[y+k][x+k]);
                    }

                    if (x <= N-M && y >= M-1 && !IsCoalition(coordinateFoundX, coordinateFoundY, x+3, y-3, "northEast")) {
                        northEastStr.Append(dna[y-k][x+k]);
                    }
                }

                FindMutation(x, y, ref coordinateFoundX, ref coordinateFoundY, ref mutations, southStr.ToString(), eastStr.ToString(), southEastStr.ToString(), northEastStr.ToString());

                southStr.Clear();
                eastStr.Clear();
                southEastStr.Clear();
                northEastStr.Clear();
            }
        }
        return (mutations >= MAX_MUTATION);
    } 

    private static void FindMutation(int x, int y, ref int coordinateX, ref int coordinateY, ref int mutations, params string[] patterns) 
    {   
        foreach(string pattern in patterns) {
            if(A_PATTERN_MUTANT == pattern || C_PATTERN_MUTANT == pattern || G_PATTERN_MUTANT == pattern || T_PATTERN_MUTANT == pattern) {
                mutations++;
                coordinateX = x;
                coordinateY = y;
            } 
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
                    coordinateX == coordinateFoundX
                    || coordinateY == coordinateFoundY+1
                    || coordinateY == coordinateFoundY+2
                    || coordinateY == coordinateFoundY+3) && coordinateX == coordinateFoundX;
                break;
            case "east":
                result = (
                    coordinateX == coordinateFoundX
                    || coordinateX == coordinateFoundX+1
                    || coordinateX == coordinateFoundX+2
                    || coordinateX == coordinateFoundX+3) && coordinateY == coordinateFoundY;
                break;
            case "southEast":
                result = (
                    coordinateX == coordinateFoundX
                    || coordinateX == coordinateFoundX+1 
                    || coordinateX == coordinateFoundX+2
                    || coordinateX == coordinateFoundX+3)
                    && (
                    coordinateX == coordinateFoundX
                    || coordinateY == coordinateFoundY+1 
                    || coordinateY == coordinateFoundY+2
                    || coordinateY == coordinateFoundY+3);
                break;
            case "northEast":
                result = (
                    coordinateX == coordinateFoundX
                    || coordinateX == coordinateFoundX+1 
                    || coordinateX == coordinateFoundX+2
                    || coordinateX == coordinateFoundX+3)
                    && (
                    coordinateY == coordinateFoundY 
                    || coordinateY == coordinateFoundY-1 
                    || coordinateY == coordinateFoundY-2
                    || coordinateY == coordinateFoundY-3);
                break;
            default:
                throw new InvalidOperationException("Not found direction");
        }
        return result;
    }

    // Complexity Time: O(N)
    public static bool ValidDna(string[] data ) {
        int N = data.Length;
        bool result = true;
        if (N < MutantResolver.A_PATTERN_MUTANT.Length)
            result  = false;
        else {
            for (int i = 0; i < N; i++) {
                if(data[i].Length > N)
                    return false;
            }
        }
        return result;
    }
}