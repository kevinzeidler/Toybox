namespace ToyBox.Tests;

public class BoardTest
{
    [Fact]
    public void CanInitializeObservableEmptyBoard()
    {
        // assign
        var emptyBoard = new Board();
        var turnNumber = emptyBoard.TurnNumber;
        var topLeft = emptyBoard[0];
        // act
        var stringRepr = emptyBoard.ToString();
        var gridRepr = emptyBoard.ToList();
        // asser
        Assert.Equal(turnNumber, 0);
        Assert.Equal(11, stringRepr.Length);
        Assert.Equal(3, gridRepr.Count);
        Assert.Equal(emptyBoard.Empty, topLeft);
    }

    [Fact]
    public void HasArraylikeInterface()
    {
        var board = new Board();
        var xToken = board.Player1;
        var oToken = board.Player2;
        var empty = board.Empty;
        var notTheBoard = board.ToList();


        board[4] = xToken;
        board[0] = oToken;
        board[1] = xToken;
        board[7] = oToken;
        var turnNumberAfterAssignments = board.TurnNumber;
        var gridState2D = board.ToList();

        var row1 = gridState2D[0];
        var row2 = gridState2D[1];
        var row3 = gridState2D[2];
        Assert.Equal(5, turnNumberAfterAssignments);
        Assert.Equal(new[] { oToken, xToken, empty }, row1);
        Assert.Equal(new[] { empty, xToken, empty }, row2);
        Assert.Equal(new[] { empty, oToken, empty }, row3);
    }

    [Fact]
    public void CanInitializeInProgressGameFromString()
    {
        var board = new Board();
        var desiredState = new[]
        {
            board.Empty, board.Player1, board.Player1,
            board.Player2, board.Player1, board.Player2,
            board.Player2, board.Player1, board.Player2
        };
        var desiredSerialState = desiredState;
        var occupiedBoard = new Board(desiredSerialState);

        Assert.Equal(9, occupiedBoard.TurnNumber);
    }
}