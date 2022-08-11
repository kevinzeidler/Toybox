namespace ToyBox.Tests;


public class SessionManagerTest
{
    [Fact]
    public void CanInitializeNewSession() 
    {
        var sessionManager = new SessionManager();
        var ctx1 = sessionManager.NewGame();
        var sess1 = ctx1.SessionId;
        var retrievedGame = sessionManager[sess1];
        var retrievedGameId = retrievedGame.SessionId;
        Assert.Equal(sess1, retrievedGameId);
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
        Assert.Equal('X', gameState.CurrentPlayer);
        Assert.Null(gameState.WinningSquares);

        var gameStatePostVictory = sessionManager.UpdateGame(sess1, 6);
        Assert.True(gameStatePostVictory.HasWinner);
        Assert.False(gameStatePostVictory.HasNextMove);
        Assert.Equal('O', gameStatePostVictory.CurrentPlayer);
        Assert.Equal('X', gameStatePostVictory.Winner);
        Assert.Equal(new int[] { 2, 4, 6 }, gameStatePostVictory.WinningSquares);
        
    }
    
    [Fact]
    public void CanGetListOfCurrentSessions()
    {
        var sessionManager = new SessionManager();
        var ctx1 = sessionManager.NewGame();
        var sess1 = ctx1.SessionId;
        var ctx2 = sessionManager.NewGame();
        var sess2 = ctx2.SessionId;
        var ctx3 = sessionManager.NewGame();
        var sess3 = ctx3.SessionId;
        Assert.Equal(3, sessionManager.Count);
        Assert.Contains(sess1, sessionManager.Keys);
        Assert.Contains(sess2, sessionManager.Keys);
        Assert.Contains(sess3, sessionManager.Keys);
    }
    
    [Fact]
    public void CanGetSessionById()
    {
        var sessionManager = new SessionManager();
        var ctx1 = sessionManager.NewGame();
        var sess1 = ctx1.SessionId;
        var ctx2 = sessionManager.NewGame();
        var sess2 = ctx2.SessionId;
        var ctx3 = sessionManager.NewGame();
        var sess3 = ctx3.SessionId;
        Assert.Equal(3, sessionManager.Count);
        Assert.Contains(sess1, sessionManager.Keys);
        Assert.Contains(sess2, sessionManager.Keys);
        Assert.Contains(sess3, sessionManager.Keys);
        var retrievedGame = sessionManager[sess1];
        var retrievedGameId = retrievedGame.SessionId;
        Assert.Equal(sess1, retrievedGameId);
    }
    [Fact]
    public void HasDictionaryLikeInterface()
    {
        var sessionManager = new SessionManager();
        var ctx1 = sessionManager.NewGame();
        var sess1 = ctx1.SessionId;
        var game1 = sessionManager[sess1];
        var allGames = sessionManager.Values;
        var allSessions = sessionManager.Keys;
        Assert.Equal(new List<string> { sess1 }, allSessions);
        Assert.Contains(game1, allGames);
        Assert.Equal(new List<Game> { game1 }, allGames);
        
    }
    [Fact]
    public void CanDeleteSession()
    {
        var sessionManager = new SessionManager();
        var ctx1 = sessionManager.NewGame();
        var sess1 = ctx1.SessionId;
        var ctx2 = sessionManager.NewGame();
        var sess2 = ctx2.SessionId;
        var ctx3 = sessionManager.NewGame();
        var sess3 = ctx3.SessionId;
        Assert.Equal(3, sessionManager.Count);
        Assert.Contains(sess1, sessionManager.Keys);
        Assert.Contains(sess2, sessionManager.Keys);
        Assert.Contains(sess3, sessionManager.Keys);
        // alternately
        Assert.True(sessionManager.Contains(sess1));
        Assert.True(sessionManager.Contains(sess2));
        Assert.True(sessionManager.Contains(sess3));
        sessionManager.DeleteSession(sess1);
        Assert.Equal(2, sessionManager.Count);
        // alternately 
        sessionManager.Remove(sess2);
        Assert.Equal(1, sessionManager.Count);

        Assert.DoesNotContain(sess1, sessionManager.Keys);
        Assert.False(sessionManager.Contains(sess2));
        Assert.True(sessionManager.Contains(sess3));
    }
    
    [Fact]
    public void CanDeleteAllSessions()
    {
        var sessionManager = new SessionManager();
        var ctx1 = sessionManager.NewGame();
        var sess1 = ctx1.SessionId;
        var ctx2 = sessionManager.NewGame();
        var sess2 = ctx2.SessionId;
        var ctx3 = sessionManager.NewGame();
        var sess3 = ctx3.SessionId;
        Assert.Equal(3, sessionManager.Count);
        Assert.Contains(sess1.ToString(), sessionManager.Keys);
        Assert.Contains(sess2.ToString(), sessionManager.Keys);
        Assert.Contains(sess3.ToString(), sessionManager.Keys);
        // alternately
        Assert.True(sessionManager.Contains(sess1));
        Assert.True(sessionManager.Contains(sess2));
        Assert.True(sessionManager.Contains(sess3));
        sessionManager.Remove(sess1);
        sessionManager.Remove(sess2);
        Assert.DoesNotContain(sess1, sessionManager.Keys);
        Assert.DoesNotContain(sess2, sessionManager.Keys);
        Assert.Contains(sess3, sessionManager.Keys);
        sessionManager.Clear();
        Assert.DoesNotContain(sess3, sessionManager.Keys);
        Assert.Equal(0, sessionManager.Count);
    }

}

