namespace ToyBox;

public class Program
{
    // There must be a better way to accomplish this... it works, but I'm not entirely sure on the logistics of
    // unit testing a static application component that's only initialized at runtime?
    public static Dictionary<string, Game> CurrentSessions = new();

    public static Context HandleRequest(string session_id, int choice)
    {
        var targetGame = CurrentSessions[session_id];
        var result = targetGame.MakeMove(choice);
        return targetGame.GameState;
    }

    public static void Main(string[] args)
    {
        var game1 = new Game();
        var game2 = new Game();
        var guid1 = game1.SessionId;
        var guid2 = game2.SessionId;
        Console.WriteLine(CurrentSessions.ToString());

        CurrentSessions[guid1] = game1;
        CurrentSessions[guid2] = game2;


        var output = HandleRequest(guid1, 4);
        Console.WriteLine(output.ToString());
        HandleRequest(guid2, 0);
        HandleRequest(guid1, 6);
        HandleRequest(guid2, 2);
        HandleRequest(guid1, 5);

        var ctx = new Context();
    }
}