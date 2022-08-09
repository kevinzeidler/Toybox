namespace ToyBox
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game();
            game.MakeMove(4);
            game.MakeMove(8);
            game.MakeMove(6);
            game.MakeMove(2);
            game.MakeMove(7);
            game.MakeMove(5);
            game.MakeMove(0);

        }
    }
    
}

