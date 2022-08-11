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
    //
    // [Fact]
    // public void CheckHasWinnerLogic()
    // {
    //     var game = new Game();
    //     var xWinStatePreWinCondition = game.hasWon('X');
    //     var oWinStatePreWinCondition = game.hasWon('O');
    //     game.MakeMove(0);
    //     game.MakeMove(1);
    //     game.MakeMove(3);
    //     game.MakeMove(2);
    //     game.MakeMove(6);
    //     var xWinStatePostWinCondition = game.hasWon('X');
    //     var oWinStatePostWinCondition = game.hasWon('O');
    //     Assert.False(xWinStatePreWinCondition);
    //     Assert.False(oWinStatePreWinCondition);
    //     Assert.False(oWinStatePostWinCondition);
    //     Assert.True(xWinStatePostWinCondition);
    // }
}