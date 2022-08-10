using System.Collections;

namespace ToyBox;

public class SessionManager : IDictionary
{
    public Dictionary<string, Game> Sessions;

    public SessionManager()
    {
        Sessions = new Dictionary<string, Game>();
    }

    public Context NewGame()
    {
        var game = new Game();
        this[game.SessionId] = game;
        return game.GameState;
    }

    public Context UpdateGame(string sessionId, int index)
    {
        var activeGame = Sessions[sessionId];
        var result = activeGame.MakeMove(index);
        return activeGame.GameState;
    }

    public void Add(object key, object? value)
    {
        ((IDictionary)Sessions).Add(key, value);
    }

    public void Clear()
    {
        Sessions.Clear();
    }

    public bool Contains(object key)
    {
        return ((IDictionary)Sessions).Contains(key);
    }

    public IDictionaryEnumerator GetEnumerator()
    {
        return ((IDictionary)Sessions).GetEnumerator();
    }

    public void Remove(object key)
    {
        ((IDictionary)Sessions).Remove(key);
    }

    public bool IsFixedSize => ((IDictionary)Sessions).IsFixedSize;

    public bool IsReadOnly => ((IDictionary)Sessions).IsReadOnly;

    public object? this[object key]
    {
        get => ((IDictionary)Sessions)[key];
        set => ((IDictionary)Sessions)[key] = value;
    }

    public ICollection Keys => ((IDictionary)Sessions).Keys;

    public ICollection Values => ((IDictionary)Sessions).Values;

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)Sessions).GetEnumerator();
    }

    public void CopyTo(Array array, int index)
    {
        ((ICollection)Sessions).CopyTo(array, index);
    }

    public int Count => Sessions.Count;

    public bool IsSynchronized => ((ICollection)Sessions).IsSynchronized;

    public object SyncRoot => ((ICollection)Sessions).SyncRoot;
}