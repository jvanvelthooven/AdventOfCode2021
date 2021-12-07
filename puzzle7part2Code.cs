// read input
string[] input = System.IO.File.ReadAllLines(@"C:\Users\nljvve.VI.000\OneDrive\Documents\Adventofcode\2021\puzzle7input.txt");

// get crab locations
List<int> crabs = new List<int>(input[0].Split(',').Select(Int32.Parse));

// set fuel
int[] fuel = new int[crabs.Max()];

// calc paths
for (int path = 0; path < crabs.Max(); path++)
    foreach (int crab in crabs)
    {
        int distance = Math.Abs(crab - path);
        int cost = 0;
        for (int step = 0; step < distance; step++)
            cost += step + 1;
        fuel[path] += cost;
    }

// choose minimum
Console.WriteLine(fuel.Min());