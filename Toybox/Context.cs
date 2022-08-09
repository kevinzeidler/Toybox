using System.Text.Json.Serialization;

namespace ToyBox;

public class Context
{
    [JsonPropertyName("board_state")]
    public char[] BoardState { get; set; }
    
    [JsonPropertyName("game_state")]
    public int GameState { get; set;  }
    
    [JsonPropertyName("current_player")]
    public char? CurrentPlayer { get; set; }
    
    [JsonPropertyName("winning_player")]
    public char? Winner { get; set; }
    
    [JsonPropertyName("has_next_move")]
    public bool HasNextMove { get; set; }
    
    [JsonPropertyName("has_winner")]
    public bool HasWinner { get; set;  }

    [JsonPropertyName("winning_squares")]
    public int[]? WinningSquares { get; set; }
    
    [JsonPropertyName("choice")]
    public int? Choice { get; set; }

    
    
}