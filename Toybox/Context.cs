using System.Text.Json.Serialization;

namespace ToyBox;

public class Context
{
    

    public Context(string sessionId, char[] boardState, int gameState, char? currentPlayer, bool hasWinner,
        char? winner, int[]? winningSquares, bool hasNextMove, string stringRepr)
    {
        SessionId = sessionId;
        BoardState = boardState;
        GameState = gameState;
        CurrentPlayer = currentPlayer;
        HasWinner = hasWinner;
        Winner = winner;
        WinningSquares = winningSquares;
        HasNextMove = hasNextMove;
        StringRepr = stringRepr;
    }

    [JsonPropertyName("session_id")] public string SessionId { get; set; }

    [JsonPropertyName("board_state")] public char[] BoardState { get; set; }

    [JsonPropertyName("round")] public int TurnNumber { get; }

    [JsonPropertyName("game_state")] public int GameState { get; set; }

    [JsonPropertyName("current_player")] public char? CurrentPlayer { get; set; }

    [JsonPropertyName("winning_player")] public char? Winner { get; set; }

    [JsonPropertyName("has_next_move")] public bool HasNextMove { get; set; }

    [JsonPropertyName("has_winner")] public bool HasWinner { get; set; }

    [JsonPropertyName("winning_squares")] public int[]? WinningSquares { get; set; }
    
    [JsonPropertyName("as_string")] public string? StringRepr { get; set; }
}