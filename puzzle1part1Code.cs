string[] lines = System.IO.File.ReadAllLines(@"C:\Users\nljvve.VI.000\OneDrive\Documents\Adventofcode\2021\puzzleinput1.txt");
string prevline = "0";
int counter = 0;
foreach (string line in lines) {
    if (prevline == "0")
    {
        Console.WriteLine($"{line} (N/A)");
    }
    else
    {
        if (Int32.Parse(line) > Int32.Parse(prevline))
        {
            Console.WriteLine($"{line} (increased)");
            counter++;
        }
        else
            Console.WriteLine($"{line} (decreased)");
    }
    prevline = line;
}
Console.WriteLine($"Total increases: {counter}");