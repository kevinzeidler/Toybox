using System.Text;
using System.Text.Json;

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
        Console.WriteLine(boardState);
        return boardState;
    }

    // public int GameState
    // {
    //     get
    //     {
    //         var wi
    //         var winX = hasWon('X');
    //         var winO = hasWon('O');
    //         var winEither = winX || winO;
    //         var stalemate = !winEither && turnNumber >= 8;
    //         var inProgress = 
    //         
    //
    //     }
    // }
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

        var boardString = sb.ToString();
        var victoryConditions = HasWinner();
        var context = new Context
        {
            BoardState = board,
            GameState = 1,
            CurrentPlayer = CurrentPlayer,
            HasWinner = victoryConditions.Item1,
            Winner = victoryConditions.Item2,
            WinningSquares = victoryConditions.Item3,
            HasNextMove = victoryConditions.Item4
            
            
        };
        string jsonString = JsonSerializer.Serialize(context);

        return jsonString;
    }

    public (bool, char?, int[]?, bool) HasWinner()
    {
        
        for (int i = 0; i < 9; i++)
        for (int j = 0; j < 9; j++)
        for (int k = 0; k < 9; k++)
            if (i != j && i != k && j != k)
                if (board[i] == board[j] && board[j] == board[k] && board[i] != ' ')
                    if (MagicSquare3X3Ints[i] + MagicSquare3X3Ints[j] + MagicSquare3X3Ints[k] == 15)
                    {
                        var winningSquares = new int[] { i, j, j };
                        return (true, board[i], winningSquares, false);
                    }

        var hasNextMove = turnNumber <= board.Length;
        return (false, null, null, hasNextMove);
    }
}