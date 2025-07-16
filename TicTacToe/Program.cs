namespace TicTacToe;

class Program
{
    static void Main(string[] args)
    {
        TicTacToe game = new TicTacToe();
        do
        {
            Console.WriteLine("Play vs computer? (y/n)");
            string mode = Console.ReadLine();
            bool vsComputer = mode.ToLower() == "y";

            game = new TicTacToe(vsComputer);
            game.Turns();
            Console.WriteLine("Do you want to play again? (y/n)");
            string answer = Console.ReadLine();

            if (answer.ToLower() == "y")
            {
                game.ResetBoard();
            }
            else
            {
                break;
            }
        } while (true);
        
    }
}