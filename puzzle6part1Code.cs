// read input
string[] input = System.IO.File.ReadAllLines(@"C:\Users\nljvve.VI.000\OneDrive\Documents\Adventofcode\2021\puzzle6input.txt");

// get numbers
List<int> fish = new List<int>(input[0].Split(',').Select(Int32.Parse));

// set days
int days = 80;

// run through days
for (int day = 0; day < days; day++)
{
    // run through numbers
    int adds = 0;
    for (int counter = 0; counter < fish.Count; counter++)
    {
        if (fish[counter] == 0)
        {
            fish[counter] = 6;
            adds++;
        }
        else
        {
            fish[counter] = fish[counter] - 1;
        }
    }
    for (int add = 0; add < adds; add++)
    {
        fish.Add(8);
    }
}
Console.WriteLine(fish.Count);