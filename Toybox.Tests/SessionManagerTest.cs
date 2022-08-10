namespace ToyBox.Tests;


public class SessionManagerTest
{
    [Fact]
    public void CanInitializeNewSession() 
    {
        var sessionManager = new SessionManager();
        var ctx1 = sessionManager.NewGame();
        var sess1 = ctx1.SessionId;
        var retrievedGame = sessionManager.Sessions[sess1];
        var retrievedGameId = retrievedGame.SessionId;
        Assert.Equal(sess1, retrievedGameId);
        Assert.Equal(ctx1, retrievedGame.GameState);
    }

    [Fact]
    public void CanUpdateInProgressGame()
    {
        var sessionManager = new SessionManager();
        var ctx1 = sessionManager.NewGame();
        var sess1 = ctx1.SessionId;
        sessionManager.UpdateGame(sess1, 4);
        sessionManager.UpdateGame(sess1, 1);
        sessionManager.UpdateGame(sess1, 2);
        var gameState = sessionManager.UpdateGame(sess1, 5);
        Assert.False(gameState.HasWinner);
        Assert.True(gameState.HasNextMove);
        Assert.Equal('O', gameState.CurrentPlayer);
        Assert.Null(gameState.WinningSquares);

        var gameStatePostVictory = sessionManager.UpdateGame(sess1, 6);
        Assert.True(gameState.HasWinner);
        Assert.False(gameState.HasNextMove);
        Assert.Equal('X', gameState.CurrentPlayer);
        Assert.Equal('O', gameState.Winner);
        Assert.Equal(new int[] { 2, 4, 6 }, gameState.WinningSquares);
        
    }

}