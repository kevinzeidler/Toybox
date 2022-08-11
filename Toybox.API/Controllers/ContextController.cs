using Microsoft.AspNetCore.Mvc;
using ToyBox;

namespace Toybox.API.Controllers;

public class ContextController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    private static SessionManager sessions = new SessionManager();
    
    [HttpGet("tictactoe")]
    public IEnumerable<Context> Get()
    {
        return new[] { new Context() };
    }
}