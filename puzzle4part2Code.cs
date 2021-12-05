// read input
string[] lines = System.IO.File.ReadAllLines(@"C:\Users\nljvve.VI.000\OneDrive\Documents\Adventofcode\2021\puzzle4input.txt");

// get numbers
List<int> numbers = new List<int>(lines[0].Split(',').Select(Int32.Parse));

// add boardcounter
int boardCounter = 0;

// boards
int[][,] boards = new int[numbers.Count][,];
List<int> boardsSum = new List<int>();
List<int> boardsDone = new List<int>();
List<int> boardsSort = new List<int>();

// run through lines
for (int nb = 1; nb < lines.Length; nb++)
{
    // check empty line
    if (lines[nb] == "")
    {
        int[,] board = new int[5, 5];
        int sum = 0;
        for (int col = 0; col < 5; col++)
        {
            board[0, col] = Int32.Parse(Regex.Replace(lines[nb + 1].Trim(), " +", " ").Split(' ')[col].Trim());
            board[1, col] = Int32.Parse(Regex.Replace(lines[nb + 2].Trim(), " +", " ").Split(' ')[col].Trim());
            board[2, col] = Int32.Parse(Regex.Replace(lines[nb + 3].Trim(), " +", " ").Split(' ')[col].Trim());
            board[3, col] = Int32.Parse(Regex.Replace(lines[nb + 4].Trim(), " +", " ").Split(' ')[col].Trim());
            board[4, col] = Int32.Parse(Regex.Replace(lines[nb + 5].Trim(), " +", " ").Split(' ')[col].Trim());
            sum += (board[0, col] + board[1, col] + board[2, col] + board[3, col] + board[4, col]);
        }

        // add board
        boards[boardCounter] = board;

        // add sum
        boardsSum.Add(sum);

        // create a mirrorboard to check if lines are done
        int[,] boardMirror = new int[5, 5];
        for (int x = 0; x < 5; x++)
        {
            boardMirror[x, 0] = -1;
            boardMirror[x, 1] = -1;
            boardMirror[x, 2] = -1;
            boardMirror[x, 3] = -1;
            boardMirror[x, 4] = -1;
        }

        // create boolean found to break loop
        bool found = false;

        // Check when done
        for (int nbCounter = 0; nbCounter < numbers.Count; nbCounter++)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    if (board[i, j] == numbers[nbCounter])
                    {
                        boardMirror[i, j] = numbers[nbCounter];
                        if ((boardMirror[i, 0] >= 0 && boardMirror[i, 1] >= 0 && boardMirror[i, 2] >= 0 && boardMirror[i, 3] >= 0 && boardMirror[i, 4] >= 0) || (boardMirror[0, j] >= 0 && boardMirror[1, j] >= 0 && boardMirror[2, j] >= 0 && boardMirror[3, j] >= 0 && boardMirror[4, j] >= 0))
                        {
                            // add value to done
                            boardsDone.Add(nbCounter);
                            boardsSort.Add(nbCounter);
                            found = true;
                            break;
                        }
                    }
                if (found == true)
                    break;
            }
            if (found == true)
                break;
        }

        Console.WriteLine($"{boardCounter}:{boardsSum[boardCounter]}:{boardsDone[boardCounter]}");
        boardCounter++;
    }
}

// sort to get last 2
boardsSort.Sort();

// get last number
int lastNr = boardsSort[boardsSort.Count - 1];
int last = numbers[lastNr];

// get finalBoard from list
int[,] finalBoard = boards[boardsDone.IndexOf(lastNr)];
//for (int i = 0; i < 5; i++)
//{
//    Console.WriteLine($"{finalBoard[i, 0]} {finalBoard[i, 1]} {finalBoard[i, 2]} {finalBoard[i, 3]} {finalBoard[i, 4]}");
//}

// set remove to 0
int removeSum = 0;

// Check when done
for (int nbCounter = 0; nbCounter < numbers.Count; nbCounter++)
{
    for (int i = 0; i < 5; i++)
        for (int j = 0; j < 5; j++)
        {
            if (finalBoard[i, j] == numbers[nbCounter])
            {
                removeSum += numbers[nbCounter];
                if (finalBoard[i, j] == last)
                    goto finalBreak;
            }

        }
}
finalBreak:

// unmarked left
int unmarked = boardsSum[boardsDone.IndexOf(lastNr)] - removeSum;

// end answer
Console.WriteLine(last * unmarked);