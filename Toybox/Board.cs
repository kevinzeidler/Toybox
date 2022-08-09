using System.Collections;
using System.Text;

namespace ToyBox;

public class Board: IEnumerable
{
    // @Shawn - apparently `const` fields are protected by default? Using `const` instead of `readonly` prevents others
    // from referring to these fields at all, which is problematic for tests and certain Game methods
    public readonly char Empty = ' ';
    public readonly char Player1 = 'X';
    public readonly char Player2 = 'O';
    public List<Tuple<char, int>> history;

    public char[] state;

    public Board()
    {
        InitializeEmptyBoard();
    }


    public Board(char[] initialState)
    {
        InitializeEmptyBoard();
        state = initialState;
    }

    // To enable client code to validate input
    // when accessing your indexer.
    public int Length => state.Length;

    public int TurnNumber => state.Count(cell => cell == Player1 || cell == Player2) + 1;

    // Indexer declaration.
    // If index is out of range, the temps array will throw the exception.
    public char this[int index]
    {
        get => state[index];
        set => state[index] = value;
        // history.Append((value, index));
    }

    private void InitializeEmptyBoard()
    {
        // 
        state = new[]
        {
            Empty, Empty, Empty,
            Empty, Empty, Empty,
            Empty, Empty, Empty
        };
        history = new List<Tuple<char, int>>();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (var i = 0; i < state.Length; i++)
        {
            if (i > 0 && i % 3 == 0) sb.Append('\n');

            sb.Append(state[i]);
        }

        var boardString = sb.ToString();
        return boardString;
    }

    public IEnumerator GetEnumerator()
    {
        return state.GetEnumerator();
    }


    public List<char[]> ToList()
    {
        var gridRepr = new[]
        {
            new[] { state[0], state[1], state[2] },
            new[] { state[3], state[4], state[5] },
            new[] { state[6], state[7], state[8] }
        };
        return gridRepr.ToList();
    }
}