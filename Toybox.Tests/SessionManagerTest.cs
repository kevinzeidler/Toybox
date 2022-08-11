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
        Assert.Equal(ctx1, retrievedGame.GameState);
    }

    [Fact]
    public void CanUpdateInProgressGame()
    {
        var sessionManager = new SessionManager();
        var ctx1 = sessionManager.NewGame();
        var sess1 = ctx1.SessionId;
        SessionManager.UpdateGame(sess1, 4);
        SessionManager.UpdateGame(sess1, 1);
        SessionManager.UpdateGame(sess1, 2);
        
        var gameState = SessionManager.UpdateGame(sess1, 5);
        Assert.False(gameState.HasWinner);
        Assert.True(gameState.HasNextMove);
        Assert.Equal('X', gameState.CurrentPlayer);
        Assert.Null(gameState.WinningSquares);

        var gameStatePostVictory = SessionManager.UpdateGame(sess1, 6);
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
        Assert.Equal(3, SessionManager.Count);
        Assert.Contains(sess1, SessionManager.Keys);
        Assert.Contains(sess2, SessionManager.Keys);
        Assert.Contains(sess3, SessionManager.Keys);
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
        Assert.Equal(3, SessionManager.Count);
        Assert.Contains(sess1, SessionManager.Keys);
        Assert.Contains(sess2, SessionManager.Keys);
        Assert.Contains(sess3, SessionManager.Keys);
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
        var allGames = SessionManager.Values;
        var allSessions = SessionManager.Keys;
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
        Assert.Equal(3, SessionManager.Count);
        Assert.Contains(sess1, SessionManager.Keys);
        Assert.Contains(sess2, SessionManager.Keys);
        Assert.Contains(sess3, SessionManager.Keys);
        // alternately
        Assert.True(SessionManager.Contains(sess1));
        Assert.True(SessionManager.Contains(sess2));
        Assert.True(SessionManager.Contains(sess3));
        SessionManager.DeleteSession(sess1);
        Assert.Equal(2, SessionManager.Count);
        // alternately 
        SessionManager.Remove(sess2);
        Assert.Equal(1, SessionManager.Count);

        Assert.DoesNotContain(sess1, SessionManager.Keys);
        Assert.False(SessionManager.Contains(sess2));
        Assert.True(SessionManager.Contains(sess3));
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
        Assert.Equal(3, SessionManager.Count);
        Assert.Contains(sess1.ToString(), SessionManager.Keys);
        Assert.Contains(sess2.ToString(), SessionManager.Keys);
        Assert.Contains(sess3.ToString(), SessionManager.Keys);
        // alternately
        Assert.True(SessionManager.Contains(sess1));
        Assert.True(SessionManager.Contains(sess2));
        Assert.True(SessionManager.Contains(sess3));
        SessionManager.Remove(sess1);
        SessionManager.Remove(sess2);
        Assert.DoesNotContain(sess1, SessionManager.Keys);
        Assert.DoesNotContain(sess2, SessionManager.Keys);
        Assert.Contains(sess3, SessionManager.Keys);
        SessionManager.Clear();
        Assert.DoesNotContain(sess3, SessionManager.Keys);
        Assert.Equal(0, SessionManager.Count);
    }

}

