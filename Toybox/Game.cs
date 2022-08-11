using System.Text;
using System.Text.Json;

namespace ToyBox;

public class Game
{
    private static readonly Random random = new();

    private readonly int[] MagicSquare3X3Ints = { 6, 1, 8, 7, 5, 3, 2, 9, 4 };

    // public int Value { get; set; }
    //
    public Board board;

    // Originally I implemented this as a `Guid` instance, but invoking `Guid()` returns a zeroed-out identifier
    // that definitely isn't unique. I'm guessing there's probably a documentation page that explains everything,
    // but let's get this working first with a basic randomly-generated string then maybe consider using a more
    // appropriate data type 
    public string SessionId;

    public Game()
    {
        board = new Board();
        SessionId = RandomString(16);
    }

    public Game(Context prevState)
    {
        board = new Board(prevState.BoardState);
        SessionId = prevState.SessionId;
    }

    public int turnNumber => board.TurnNumber;

    public char CurrentPlayer
    {
        get
        {
            if (turnNumber % 2 == 0)
                return board.Player2;
            return board.Player1;
        }
    }

    public Context GameState
    {
        get
        {
            var sb = new StringBuilder();
            for (var i = 1; i <= board.Length; i++)
            {
                sb.Append(board[i - 1]);
                if (i > 0 && i % 3 == 0) sb.Append('\n');
            }

            
            var boardString = sb.ToString();
            var victoryConditions = HasWinner();
            var context = new Context(sessionId: SessionId, boardState: board.state, 1, currentPlayer: CurrentPlayer,
                hasWinner: victoryConditions.hasWinner, winner: victoryConditions.winner,
                winningSquares: victoryConditions.winningSquares, hasNextMove: victoryConditions.hasNextMove);
            return context;
        }
    }

    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public bool CanGo(int index)
    {
        return GameState.HasNextMove && board[index] == board.Empty;
    }

    public string MakeMove(int index)
    {
        if (CanGo(index)) board[index] = CurrentPlayer;

        var boardState = ToString();
        Console.WriteLine(boardState);
        return boardState;
    }

    public override string ToString()
    {
        var jsonString = JsonSerializer.Serialize(GameState);
        return jsonString;
    }

    private (bool hasWinner, char? winner, int[]? winningSquares, bool hasNextMove) HasWinner()
    {
        for (var i = 0; i < 9; i++)
            for (var j = 0; j < 9; j++)
                for (var k = 0; k < 9; k++)
                    if (i != j && i != k && j != k)
                        if (board[i] == board[j] && board[j] == board[k] && board[i] != ' ')
                            if (MagicSquare3X3Ints[i] + MagicSquare3X3Ints[j] + MagicSquare3X3Ints[k] == 15)
                            {
                                var winningSquares = new[] { i, j, k };
                                return (true, board[i], winningSquares, false);
                            }

        var hasNextMove = turnNumber <= board.Length;
        return (false, null, null, hasNextMove);
    }
}