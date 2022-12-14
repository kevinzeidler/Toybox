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
        // asserr
        Assert.All<char>(emptyBoard.state, state => Assert.Equal(emptyBoard.Empty, state));
        Assert.Equal(1, turnNumber);
        Assert.Equal(11, stringRepr.Length);
        Assert.Equal(3, gridRepr.Count);
        Assert.Equal(emptyBoard.Empty, topLeft);
    }
    [Fact]
    public void CanSerializeToString()
    {
        var emptyBoard = new Board();
        var repr = emptyBoard.ToString();
        Assert.NotEmpty(repr);
    }

    [Fact]
    public void CanResumeInProgressGame()
    {
        var state = new char[] { ' ', ' ', 'X', ' ', 'O', 'X', ' ', ' ', 'O' };
        var board = new Board(state);
        Assert.Equal(state, board.state);
        
    }

    [Fact]
    public void HasArraylikeInterface()
    {
        var board = new Board();
        var xToken = board.Player1;
        var oToken = board.Player2;
        var empty = board.Empty;
        var notTheBoard = board.ToList();
        var enumeratedItems = new List<char> ();
        foreach (char enumeratedItem in board)
        {
            enumeratedItems.Add(enumeratedItem); 
            
        }


        board[4] = xToken;
        board[0] = oToken;
        board[1] = xToken;
        board[7] = oToken;
        var turnNumberAfterAssignments = board.TurnNumber;
        var gridState2D = board.ToList();

        var row1 = gridState2D[0];
        var row2 = gridState2D[1];
        var row3 = gridState2D[2];
        Assert.Equal(9, enumeratedItems.Count);
        Assert.Equal(5, turnNumberAfterAssignments);
        Assert.Equal(new[] { oToken, xToken, empty }, row1);
        Assert.Equal(new[] { empty, xToken, empty }, row2);
        Assert.Equal(new[] { empty, oToken, empty }, row3);
    }

    [Fact]
    public void CanInitializeInProgressGameFromCharArray()
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