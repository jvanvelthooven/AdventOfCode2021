string[] lines = System.IO.File.ReadAllLines(@"C:\Users\nljvve.VI.000\OneDrive\Documents\Adventofcode\2021\puzzle3input.txt");
string gamma = "";
string epsilon = "";
for (int col = 0; col < lines[0].Length; col++)
{
    int ones = 0;
    int zeroes = 0;
    foreach (string line in lines)
    {
        if (line[col] == '0')
        {
            zeroes++;
        }
        else
        {
            ones++;
        }
    }
    if (ones > zeroes)
    {
        gamma += "1";
        epsilon += "0";
    }
    else
    {
        gamma += "0";
        epsilon += "1";
    }
}
Console.WriteLine(Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2));