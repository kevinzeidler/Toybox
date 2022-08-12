namespace Toybox.API;

using System.Text.Json.Serialization;
using ToyBox;

public class APIContext
{




    public APIContext(Context gameContext)
    {
        SessionId = gameContext.SessionId;
        BoardState = gameContext.BoardState;
        CurrentPlayer = gameContext.CurrentPlayer;
        HasWinner = gameContext.HasWinner;
        Winner = gameContext.Winner;
        WinningSquares = gameContext.WinningSquares;
        HasNextMove = gameContext.HasNextMove;
        StringRepr = gameContext.StringRepr;
        Grid = new string[]
        {
            String.Concat(BoardState.Take(3)),
            String.Concat(BoardState.Skip(3).Take(3)),
            String.Concat(BoardState.Skip(6).Take(3)),
        
        };
    }


    [JsonPropertyName("session_id")] public string SessionId { get; set; }

    [JsonPropertyName("board_state")] public char[]? BoardState { get; set; }

    [JsonPropertyName("round")] public int TurnNumber { get; set; }
    
    [JsonPropertyName("current_player")] public char? CurrentPlayer { get; set; }

    [JsonPropertyName("winning_player")] public char? Winner { get; set; }

    [JsonPropertyName("has_next_move")] public bool? HasNextMove { get; set; }

    [JsonPropertyName("has_winner")] public bool? HasWinner { get; set; }

    [JsonPropertyName("winning_squares")] public int[]? WinningSquares { get; set; }

    public string? StringRepr { get; set; }
    [JsonPropertyName("grid")] public string[] Grid { get; set; } 

}