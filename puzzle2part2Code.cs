string[] lines = System.IO.File.ReadAllLines(@"C:\Users\nljvve.VI.000\OneDrive\Documents\Adventofcode\2021\puzzle2input.txt");
int x = 0;
int y = 0;
int aim = 0;
foreach (string line in lines)
{
    switch (line.Split(" ")[0])
    {
        case "forward":
            y += aim * Int32.Parse(line.Split(" ")[1]);
            x += Int32.Parse(line.Split(" ")[1]);
            break;
        case "down":
            aim += Int32.Parse(line.Split(" ")[1]);
            break;
        case "up":
            aim -= Int32.Parse(line.Split(" ")[1]);
            break;
    }
    Console.WriteLine($"{x} {y} {aim}");
}
Console.WriteLine(x * y);