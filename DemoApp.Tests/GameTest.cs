using System.Text;
using Xunit;

namespace DemoApp.Tests;

public class GameTest
{
    [Fact]
    public void HasBoardProperty()
    {
        // assign
        var game = new Game();

        // act
        var gameBoard = game.board;
        var action = new Action<string>(AssertAllEmpty);

        // assert
        Assert.Equal(9, gameBoard.Length);
        Assert.Equal(' ', gameBoard[0]);
        Array.ForEach(gameBoard, action);
    }

    private void AssertAllEmpty(char cell)
    {
        Assert.Equal(' ', cell);
    }

    [Fact]
    public void HasStringRepresentation()
    {
        var game = new Game();
        var stringRepr = game.ToString();
        Assert.Equal("...\n...\n...\n", stringRepr);
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
        Assert.Equal("X", game.board[0]);
        Assert.Equal("O", game.board[1]);
    }
}