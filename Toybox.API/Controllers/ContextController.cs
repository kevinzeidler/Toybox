using System.Collections;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using ToyBox;

// using System.Web.Http;

namespace Toybox.API.Controllers;

[ApiController]
[Route("/api/v1/tictactoe")]
public class ContextController : Controller
{
    // GET
    // public IActionResult Index()
    // {
    //     return View();
    // }
    private SessionManager _sessions;
    public ContextController(SessionManager sessions)
    {
        _sessions = sessions;
    }

    [HttpGet("games")]
    public IEnumerable<APIContext> ListGames()
    {
        var response = new List<APIContext>();
        foreach (Game game in _sessions.Values)
        {
            response.Add(new APIContext(game.GameState));
        }
        return response;
    }
    
    [HttpPost("games" )]
    public APIContext CreateGame()
    {
        var ctx = _sessions.NewGame();
        var response = new APIContext(ctx);
        return response;
        
    }
    
    [HttpGet(template: "games/{sessionId}")]
    public APIContext GetGame(string sessionId)
    {
        try
        {
            var fetched = _sessions[sessionId];
            var response = new APIContext(fetched.GameState);

            return response;
        }
        catch (KeyNotFoundException)
        {
            throw new BadHttpRequestException(string.Concat("Invalid session ID: ", sessionId), 400);
        }
    }
    
    [HttpPut(template: "games/{sessionId}/{selectedTile}")]
    public APIContext UpdateGame(string sessionId, int selectedTile)
    {
        try
        {
            var fetched = _sessions[sessionId];
            if (!fetched.CanGo(selectedTile)) {
                // Concatenate the selected tile to the error message to notify client of invalid move
                var errorMessage = string.Concat("Invalid selection: ", selectedTile.ToString());
                throw new BadHttpRequestException(message: errorMessage, 400);
            }
            
            fetched.MakeMove(selectedTile);
            var response = new APIContext(fetched.GameState);

            return response;
        }
        catch (KeyNotFoundException)
        {
            throw new BadHttpRequestException(string.Concat("Invalid session ID: ", sessionId), 400);
        }
    }
    [HttpDelete(template: "games")]
    public void ClearAllSessions()
    {
        _sessions.Clear();
    }
    
    [HttpDelete(template: "games/{sessionId}")]
    public void DeleteSession(string sessionId)
    {
        try { _sessions.Remove(sessionId); }
        catch (KeyNotFoundException) 
        { 
            throw new BadHttpRequestException(string.Concat("Invalid session ID: ", sessionId), 400);
        } 
    }
    
    
}