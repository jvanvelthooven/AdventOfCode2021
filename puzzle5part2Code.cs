// read input
string[] lines = System.IO.File.ReadAllLines(@"C:\Users\nljvve.VI.000\OneDrive\Documents\Adventofcode\2021\puzzle5input.txt");

// create map
//int size = (lines[0].Length - 6) / 4;
int[,] board = new int[1000, 1000];

// run through lines
foreach (string line in lines)
{
    // get first coordinate
    string first = line.Split(" -> ")[0];
    // get second coordinate
    string second = line.Split(" -> ")[1];
    // get x and y of first
    int x1 = Int32.Parse(first.Split(",")[0]);
    int y1 = Int32.Parse(first.Split(",")[1]);
    // get x and y of second
    int x2 = Int32.Parse(second.Split(",")[0]);
    int y2 = Int32.Parse(second.Split(",")[1]);

    // check for diagonal lines
    if (!(x1 - x2 == 0 || y1 - y2 == 0 || Math.Abs(x1 - x2) == Math.Abs(y1 - y2)))
    {
        continue;
    }
    //Console.WriteLine($"{x1},{y1} -> {x2},{y2}");

    // draw it
    if (x1 == x2)
    {
        if (y1 > y2)
            for (int i = y1; i >= y2; i--)
                board[x1, i] += 1;
        else
            for (int i = y1; i <= y2; i++)
                board[x1, i] += 1;
    }
    else if (y1 == y2)
    {
        if (x1 > x2)
            for (int i = x1; i >= x2; i--)
                board[i, y1] += 1;
        else
            for (int i = x1; i <= x2; i++)
                board[i, y1] += 1;
    }
    else
    {
        if (x1 > x2)
        {
            if (y1 > y2)
                for (int i = 0; i <= (x1 - x2); i++)
                    board[x1 - i, y1 - i] += 1;
            else
                for (int i = 0; i <= (x1 - x2); i++)
                    board[x1 - i, y1 + i] += 1;
        }
        else
        {
            if (y1 > y2)
                for (int i = 0; i <= (x2 - x1); i++)
                    board[x1 + i, y1 - i] += 1;
            else
                for (int i = 0; i <= (x2 - x1); i++)
                    board[x1 + i, y1 + i] += 1;
        }
    }
    //Console.WriteLine(" === ");
    //for (int i = 0; i < 10; i++)
    //    Console.WriteLine($"{board[0, i]} {board[1, i]} {board[2, i]} {board[3, i]} {board[4, i]} {board[5, i]} {board[6, i]} {board[7, i]} {board[8, i]} {board[9, i]}");
}

// create overlap variable
int overlap = 0;

// calculate overlap
for (int a = 0; a < 1000; a++)
    for (int b = 0; b < 1000; b++)
        if (board[a, b] > 1)
            overlap++;

// output
Console.WriteLine(overlap);