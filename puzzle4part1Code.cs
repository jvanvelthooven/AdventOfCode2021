// read input
string[] lines = System.IO.File.ReadAllLines(@"C:\Users\nljvve.VI.000\OneDrive\Documents\Adventofcode\2021\puzzle4input.txt");

// get numbers
var numbers = lines[0].Split(",");

for (int nb = 1; nb < lines.Length; nb++)
{
    // check empty line
    if (lines[nb] == "")
    {
        int[,] board = new int[5, 5];
        for (int col = 0; col < 5; col++)
        {
            board[0, col] = Int32.Parse(Regex.Replace(lines[nb + 1].Trim(), " +", " ").Split(' ')[col].Trim());
            board[1, col] = Int32.Parse(Regex.Replace(lines[nb + 2].Trim(), " +", " ").Split(' ')[col].Trim());
            board[2, col] = Int32.Parse(Regex.Replace(lines[nb + 3].Trim(), " +", " ").Split(' ')[col].Trim());
            board[3, col] = Int32.Parse(Regex.Replace(lines[nb + 4].Trim(), " +", " ").Split(' ')[col].Trim());
            board[4, col] = Int32.Parse(Regex.Replace(lines[nb + 5].Trim(), " +", " ").Split(' ')[col].Trim());
        }
        int[,] boardMirror = new int[5, 5];
        bool found = false;
        foreach (string number in numbers)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    //Console.WriteLine("{0},{1}: {2}", i, j, board[i, j]);
                    if (board[i, j] == Int32.Parse(number))
                    {
                        boardMirror[i, j] = Int32.Parse(number);
                        if ((boardMirror[i, 0] > 0 && boardMirror[i, 1] > 0 && boardMirror[i, 2] > 0 && boardMirror[i, 3] > 0 && boardMirror[i, 4] > 0) || (boardMirror[0, j] > 0 && boardMirror[1, j] > 0 && boardMirror[2, j] > 0 && boardMirror[3, j] > 0 && boardMirror[4, j] > 0))
                        {
                            Console.WriteLine($"[{i},{j}]: {number}");
                            found = true;
                            break;
                        }
                    }
            if (found == true)
            {
                break;
            }
        }
    }
}

// output
//Console.WriteLine(board[0,0]);