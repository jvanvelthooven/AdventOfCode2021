// read input
string[] input = System.IO.File.ReadAllLines(@"C:\Users\nljvve.VI.000\OneDrive\Documents\Adventofcode\2021\puzzle8input.txt");

// create double to calc end result
double totalTimes = 0;

// get numbers
for (int lineCounter = 0; lineCounter < input.Length; lineCounter++)
{
    // create sets for single line
    List<string> firstSet = new List<string>(input[lineCounter].Split(" | ")[0].Split(' ').OrderBy(x => x.Length));
    List<string> secondSet = new List<string>(input[lineCounter].Split(" | ")[1].Split(' '));

    // create character options array
    string[] charOptions = { "", "", "", "", "", "", "" };

    // run through list
    for (int set = 0; set < firstSet.Count; set++)
    {
        // Check if we are done
        if (charOptions[0].Length == 1 && charOptions[1].Length == 1 && charOptions[2].Length == 1 && charOptions[3].Length == 1 && charOptions[4].Length == 1 && charOptions[5].Length == 1 && charOptions[6].Length == 1)
        {
            break;
        }

        // check length of set
        switch (firstSet[set].Length)
        {
            // 1
            case 2:
                charOptions[2] = firstSet[set];
                charOptions[5] = firstSet[set];
                break;
            // 7
            case 3:
                string seven = firstSet[set];
                foreach (char nr in charOptions[2])
                    seven = seven.Replace(nr.ToString(), "");
                charOptions[0] = seven;
                break;
            // 4
            case 4:
                string four = firstSet[set];
                foreach (char nr in charOptions[2])
                    four = four.Replace(nr.ToString(), "");
                charOptions[1] = four;
                charOptions[3] = four;
                break;
            // 2,3,5
            case 5:
                // remove known
                char[] replaceFive = (charOptions[0] + charOptions[1] + charOptions[2] + charOptions[3] + charOptions[5] + charOptions[6]).ToCharArray();
                Array.Sort(replaceFive);
                string five = firstSet[set];
                foreach (char nr in replaceFive)
                    five = five.Replace(nr.ToString(), "");

                // check if we found G
                if (charOptions[6] == "")
                {
                    // three or five
                    if (five.Length == 1)
                    {
                        // fill G
                        charOptions[6] = five;

                        // check if this is a five
                        if (charOptions[2].Length > 1 && !(firstSet[set].Contains(charOptions[2][0]) && firstSet[set].Contains(charOptions[2][1])))
                        {
                            // fill c & f
                            if (firstSet[set].Contains(charOptions[2][0]))
                            {
                                charOptions[2] = charOptions[2][1].ToString();
                                charOptions[5] = charOptions[5][0].ToString();
                            }
                            else
                            {
                                charOptions[2] = charOptions[2][0].ToString();
                                charOptions[5] = charOptions[5][1].ToString();
                            }
                        }

                        // check if this is a three
                        if (charOptions[1].Length > 1 && !(firstSet[set].Contains(charOptions[1][0]) && firstSet[set].Contains(charOptions[1][1])))
                        {
                            // fill c & f
                            if (firstSet[set].Contains(charOptions[1][0]))
                            {
                                charOptions[1] = charOptions[1][1].ToString();
                                charOptions[3] = charOptions[3][0].ToString();
                            }
                            else
                            {
                                charOptions[1] = charOptions[1][0].ToString();
                                charOptions[3] = charOptions[3][1].ToString();
                            }
                        }
                    }
                }
                else
                {
                    // two
                    if (five.Length == 1)
                    {
                        charOptions[4] = five;
                        if (charOptions[1].Length > 1)
                        {
                            // fill b & d
                            if (firstSet[set].Contains(charOptions[3][0]))
                            {
                                charOptions[3] = charOptions[3][0].ToString();
                                charOptions[1] = charOptions[1][1].ToString();
                            }
                            else
                            {
                                charOptions[3] = charOptions[3][1].ToString();
                                charOptions[1] = charOptions[1][0].ToString();
                            }
                        }
                    }
                    // two
                    if (five.Length == 0 && charOptions[1].Length > 1 && !(firstSet[set].Contains(charOptions[1][0]) && firstSet[set].Contains(charOptions[1][1])))
                    {
                        // fill b & d
                        if (firstSet[set].Contains(charOptions[3][0]))
                        {
                            charOptions[3] = charOptions[3][0].ToString();
                            charOptions[1] = charOptions[1][1].ToString();
                        }
                        else
                        {
                            charOptions[3] = charOptions[3][1].ToString();
                            charOptions[1] = charOptions[1][0].ToString();
                        }
                    }
                    // five
                    if (five.Length == 0 && charOptions[2].Length > 1 && !(firstSet[set].Contains(charOptions[2][0]) && firstSet[set].Contains(charOptions[2][1])))
                    {
                        // fill c & f
                        if (firstSet[set].Contains(charOptions[2][0]))
                        {
                            charOptions[2] = charOptions[2][1].ToString();
                            charOptions[5] = charOptions[5][0].ToString();
                        }
                        else
                        {
                            charOptions[2] = charOptions[2][0].ToString();
                            charOptions[5] = charOptions[5][1].ToString();
                        }
                    }
                }
                break;
            // 0,6,9
            case 6:
                // remove known
                char[] replaceSix = (charOptions[0] + charOptions[1] + charOptions[2] + charOptions[3] + charOptions[4] + charOptions[5] + charOptions[6]).ToCharArray();
                Array.Sort(replaceSix);
                string six = firstSet[set];
                foreach (char nr in replaceSix)
                    six = six.Replace(nr.ToString(), "");

                // three or five
                if (six.Length == 1)
                {
                    charOptions[4] = six;
                }
                break;
            // 8
            case 7:
                char[] arr7 = firstSet[set].ToCharArray();
                string eight = firstSet[set];
                foreach (string nr in charOptions)
                    if (nr != "")
                        eight = eight.Replace(nr, "");
                charOptions[4] = eight;
                break;
        }
    }


    // set numbers
    string[] arOne = { charOptions[2], charOptions[5] };
    Array.Sort(arOne);
    string nrOne = string.Join("", arOne);
    string[] arFour = { charOptions[1], charOptions[2], charOptions[3], charOptions[5] };
    Array.Sort(arFour);
    string nrFour = string.Join("", arFour);
    string[] arSeven = { charOptions[0], charOptions[2], charOptions[5] };
    Array.Sort(arSeven);
    string nrSeven = string.Join("", arSeven);
    string[] arEight = charOptions;
    Array.Sort(arEight);
    string nrEight = string.Join("", arEight);

    // create double to calc times
    double times = 0;

    // fix secondSet
    foreach (string set in secondSet)
    {
        char[] code = set.ToCharArray();
        Array.Sort(code);
        string sortedSet = string.Join("", code);
        if (sortedSet == nrOne || sortedSet == nrFour || sortedSet == nrSeven || sortedSet == nrEight)
            times++;
    }
    // add to total
    totalTimes += times;
}
Console.WriteLine(totalTimes);