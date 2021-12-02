string[] lines = System.IO.File.ReadAllLines(@"C:\Users\nljvve.VI.000\OneDrive\Documents\Adventofcode\2021\puzzle1input.txt");
int prevSum = 0;
int increase = 0;
for (int nb = 0; nb < (lines.Length - 2); nb++)
{
    int sum = Int32.Parse(lines[nb]) + Int32.Parse(lines[nb + 1]) + Int32.Parse(lines[nb + 2]);
    if (prevSum == 0)
    {
        Console.WriteLine($"{sum} (N/A)");
    }
    else if (sum > prevSum)
    {
        Console.WriteLine($"{sum} (increased)");
        increase++;
    }
    else if (sum == prevSum)
    {
        Console.WriteLine($"{sum} (no change)");
    }
    else
    {
        Console.WriteLine($"{sum} (decreased)");
    }
    prevSum = sum;
}
Console.WriteLine($"Total increase {increase}");