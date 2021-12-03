// create list from file
List<string> list = new List<string>(System.IO.File.ReadAllLines(@"C:\Users\nljvve.VI.000\OneDrive\Documents\Adventofcode\2021\puzzle3input.txt"));
// start running through columns for the oxygen generator
for (int col = 0; col < list[0].Length; col++)
{
    // create lists for ones and zeries
    List<string> linesOne = new List<string>();
    List<string> linesZero = new List<string>();

    // run through all lines
    foreach (string line in list)
    {
        // check if it's a 0 or 1
        if (line[col] == '0')
            linesZero.Add(line);
        else
            linesOne.Add(line);
    }

    // check what to do
    if (linesOne.Count == linesZero.Count)
        list = linesOne;
    else if (linesOne.Count > linesZero.Count)
        list = linesOne;
    else
        list = linesZero;

    // check list if there is 1 left
    if (list.Count == 1)
        // break loop
        break;
}

// set oxygen
string oxygen = list.Count;

// reread list from file
list = new List<string>(System.IO.File.ReadAllLines(@"C:\Users\nljvve.VI.000\OneDrive\Documents\Adventofcode\2021\puzzle3input.txt"));
// start running through columns for the CO2 scrubber
for (int col = 0; col < list[0].Length; col++)
{
    // create lists for ones and zeries
    List<string> linesOne = new List<string>();
    List<string> linesZero = new List<string>();

    // run through all lines
    foreach (string line in list)
    {
        // check if it's a 0 or 1
        if (line[col] == '0')
            linesZero.Add(line);
        else
            linesOne.Add(line);
    }

    // check what to do
    if (linesOne.Count == linesZero.Count)
        list = linesZero;
    else if (linesOne.Count > linesZero.Count)
        list = linesZero;
    else
        list = linesOne;

    // check list if there is 1 left
    if (list.Count == 1)
        // break loop
        break;
}
Console.WriteLine(list[0]);