// read input
string[] input = System.IO.File.ReadAllLines(@"C:\Users\nljvve.VI.000\OneDrive\Documents\Adventofcode\2021\puzzle6input.txt");

// get numbers
List<int> fishStart = new List<int>(input[0].Split(',').Select(Int32.Parse));

// create fish 2d array
double[] fishGrowth = new double[9];

// fill 2d array from input
foreach (int fish in fishStart)
{
    switch (fish)
    {
        case 1:
            fishGrowth[1]++;
            break;
        case 2:
            fishGrowth[2]++;
            break;
        case 3:
            fishGrowth[3]++;
            break;
        case 4:
            fishGrowth[4]++;
            break;
        case 5:
            fishGrowth[5]++;
            break;
    }
}

// set days
int days = 256;

// run through days
for (int day = 0; day < days; day++)
{
    //Console.WriteLine(string.Join(",", fishGrowth.Select(x => x.ToString()).ToArray()));
    double[] fishNext = new double[9];
    // run through sizes from 1 to 9
    for (int nr = 1; nr < 9; nr++)
        fishNext[nr - 1] = fishGrowth[nr];

    // special for 0
    fishNext[8] = fishGrowth[0];
    fishNext[6] = fishGrowth[7] + fishGrowth[0];

    // set for next step
    fishGrowth = fishNext;
}
// output sum of fishes
Console.WriteLine(fishGrowth.Sum());