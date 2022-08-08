using System.Text;

namespace DemoApp;

public class Board
{
    // private int id; // field
    //
    // public int Id { get; set; }
    //
    private string winner = "Empty";

    public readonly int[] MagicSquare3X3Ints = new[] { 6, 1, 8, 7, 5, 3, 2, 9, 4 };

    // public int Value { get; set; }
    //
    public string[] board;

    //private static CellState[] board;

    ~Board()
    {
        //this.Value = MagicSquare3X3Ints[id];

        var board = Enumerable.Repeat(CellState.Empty, 9).ToArray();
    }

    // }

    // public string Board
    // {
    //     get
    //     {
    //         foreach (string state in states) {
    //             // The `state` variable takes on the value of an element in `states` and updates every iteration.
    //             Console.WriteLine(state);
    //         }
    // }

    // public void SetPos(CellState cell, int id)
    // {
    //     board[id] = cell;
    // }
    public void SetPos(int index, string value)
    {
        board[index] = value;
    }

    // public (CellState, bool) HasWinner()
    // {
    //     
    // }
    public string Winner
    {
        // get method
        get { return winner; }
        // set method
        set { winner = value; }
    }

    enum Colors
    {
        Red = 1,
        Blue = 2
    };

    public enum CustomerType
    {
        None,
        Bronze,
        Silver,
        Gold
    }

    public class InvoiceItem
    {
        public decimal Cost { get; set; }
        public string? Description { get; set; }
    }

    static List<InvoiceItem> GetInvoiceItems()
    {
        var items = new List<InvoiceItem>();
        var rand = new Random();
        for (int i = 0; i < 100; i++)
            items.Add(
                new InvoiceItem
                {
                    Cost = rand.Next(i),
                    Description = "Invoice Item #" + (i + 1)
                });

        return items;
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append(nameof(Board));
        stringBuilder.Append(" {\n");

        if (PrintMembers(stringBuilder))
            stringBuilder.Append(" ");

        stringBuilder.Append("\n}");

        return stringBuilder.ToString();
    }

    protected virtual bool PrintMembers(StringBuilder builder)
    {
        builder.Append("  " + nameof(Winner));
        builder.Append(" = ");
        builder.Append(Winner);
        builder.Append(", \n");
        builder.Append("  " + nameof(MagicSquare3X3Ints));
        builder.Append(" = ");
        builder.Append(MagicSquare3X3Ints);
        builder.Append(", \n");
        builder.Append("  " + nameof(board));
        builder.Append(" = ");
        builder.Append(board);


        return true;
    }

    public static void Main(string[] args)
    {
        var order = new Board();
        Console.WriteLine(order);
        List<InvoiceItem> lineItems = GetInvoiceItems();

        decimal total = 0;

        foreach (var item in lineItems)
            total += item.Cost;

        total = ApplyDiscount(total, CustomerType.Gold);

        Console.WriteLine($"Total Invoice Balance: {total:C}");

        decimal ApplyDiscount(decimal total, CustomerType customerType)
        {
            switch (customerType)
            {
                case CustomerType.Bronze:
                    return total - total * .10m;
                case CustomerType.Silver:
                    return total - total * .05m;
                case CustomerType.Gold:
                    return total - total * .02m;
                case CustomerType.None:
                default:
                    return total;
            }
        }
    }
}