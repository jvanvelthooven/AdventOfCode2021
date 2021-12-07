// read input
string[] input = System.IO.File.ReadAllLines(@"C:\Users\nljvve.VI.000\OneDrive\Documents\Adventofcode\2021\puzzle7input.txt");

// get crab locations
List<int> crabs = new List<int>(input[0].Split(',').Select(Int32.Parse));

// set fuel
int[] fuel = new int[crabs.Count];

// calc paths
for (int path = 0; path < crabs.Count; path++)
    foreach (int crab in crabs)
        fuel[path] += Math.Abs(crab - path);

// choose minimum
Console.WriteLine(fuel.Min());