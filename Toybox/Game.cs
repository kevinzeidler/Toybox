using System.Text;

namespace ToyBox;

public class Game
{
    public int turnNumber;

    public char CurrentPlayer
    {
        get
        {
            if (turnNumber % 2 == 0)
            {
                return 'X';
            }
            else
            {
                return 'O';
            }
        }
    }

    private readonly int[] MagicSquare3X3Ints = new[] { 6, 1, 8, 7, 5, 3, 2, 9, 4 };

    // public int Value { get; set; }
    //
    public char[] board;

    public Game()
    {
        board = new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        turnNumber = 0;
    }

    public Game(char[] newBoard)
    {
        board = newBoard;
        turnNumber = 0;
    }

    public string MakeMove(int index)
    {
        board[index] = CurrentPlayer;
        turnNumber += 1;
        var boardState = ToString();
        return boardState;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (var i = 1; i <= board.Length; i++)
        {
            sb.Append(board[i - 1]);
            if (i > 0 && i % 3 == 0)
            {
                sb.Append('\n');
            }
        }

        return sb.ToString();
    }

    public bool hasWon(char player)
    {
        for (int i = 0; i < 9; i++)
        for (int j = 0; j < 9; j++)
        for (int k = 0; k < 9; k++)
            if (i != j && i != k && j != k)
                if (board[i] == player && board[j] == player && board[k] == player)
                    if (MagicSquare3X3Ints[i] + MagicSquare3X3Ints[j] + MagicSquare3X3Ints[k] == 15)
                        return true;
        return false;
    }
}