namespace ToyBox.Tests;

public class GameTest
{
    [Fact]
    public void HasBoardProperty()
    {
        // assign
        var game = new Game();

        // act
        var gameBoard = game.board;

        // assert
        Assert.Equal(9, gameBoard.Length);
        Assert.Equal(gameBoard.Empty, gameBoard[0]);
        //Array.ForEach(gameBoard, (x) => Assert.Equal(gameBoard.Empty, x));
    }
    

    [Fact]
    public void HasStringRepresentation()
    {
        var game = new Game();

        var stringRepr = game.ToString();

        Assert.StartsWith("{\"session_id\":\"", stringRepr);
        Assert.Contains("\"board_state\":[\" \",\" \",\" \",\" \",\" \",\" \",\" \",\" \",\" \"],", stringRepr);
    }

    [Fact]
    public void HasCurrentPlayerInitializedToX()
    {
        var game = new Game();

        var currentPlayer = game.CurrentPlayer;

        Assert.Equal('X', currentPlayer);
    }

    [Fact]
    public void HasMakeMoveMethod()
    {
        var game = new Game();
        var states = new string[] { };

        var state1 = game.MakeMove(0);
        var state2 = game.MakeMove(1);

        Assert.Equal('X', game.board[0]);
        Assert.Equal('O', game.board[1]);
    }
    [Fact]
    public void CanInitializeInProgressGameFromContext()
    {
        var game = new Game();
        game.MakeMove(0);
        game.MakeMove(1);
        var savedState = game.GameState;

        var resumedGame = new Game(savedState);
        Assert.Equal('X', resumedGame.board[0]);
        Assert.Equal('O', resumedGame.board[1]);
        Assert.Equal(game.SessionId, resumedGame.SessionId);
        
    }
}