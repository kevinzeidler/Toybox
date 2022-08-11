using System.Collections;

namespace ToyBox;

public class SessionManager
{
    public static Dictionary<string, Game> Sessions = new Dictionary<string, Game>();
    

    public Context NewGame()
    {
        var game = new Game();
        Sessions[game.SessionId] = game;
        return game.GameState;
    }

    public static Context UpdateGame(string sessionId, int index)
    {
        var activeGame = Sessions[sessionId];
        var result = activeGame.MakeMove(index);
        return activeGame.GameState;
    }

    public static void DeleteSession(string sessionId)
    {
        Remove(sessionId);
    }



    public static void Clear()
    {
        Sessions.Clear();
    }

    public static bool Contains(object key)
    {
        return ((IDictionary)Sessions).Contains(key);
    }

    // public IDictionaryEnumerator GetEnumerator()
    // {
    //     return ((IDictionary)Sessions).GetEnumerator();
    // }

    public static void Remove(object key)
    {
        ((IDictionary)Sessions).Remove(key);
    }
    //
    // public bool IsFixedSize => ((IDictionary)Sessions).IsFixedSize;
    //
    // public bool IsReadOnly => ((IDictionary)Sessions).IsReadOnly;
    //
    public Game this[string key]
    {
        get => Sessions[key];
        private set => Sessions[key] = value;
    }
    //
    public static IEnumerable<string> Keys => ((IDictionary<string, Game>)Sessions).Keys;
    //
    public static IEnumerable<Game> Values => ((IDictionary<string, Game>)Sessions).Values;
    //
    // IEnumerator IEnumerable.GetEnumerator()
    // {
    //     return ((IEnumerable)Sessions).GetEnumerator();
    // }
    //
    // public void CopyTo(Array array, int index)
    // {
    //     ((ICollection)Sessions).CopyTo(array, index);
    // }
    //
    public static int Count => Sessions.Count;
    //
    // public bool IsSynchronized => ((ICollection)Sessions).IsSynchronized;
    //
    // public object SyncRoot => ((ICollection)Sessions).SyncRoot;
}