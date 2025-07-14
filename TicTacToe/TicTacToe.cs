using System.Data.SqlTypes;

namespace TicTacToe;

public class TicTacToe
{
    string[] board = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    bool isPlayer1Turn = true;

    public void Turns()
    {
        while (true)
        {
            Console.Clear();
            Board();
            if (isPlayer1Turn)
                Console.WriteLine("Player 1 Turn");
            else
                Console.WriteLine("Player 2 Turn");
            string input = Console.ReadLine();
            if (!int.TryParse(input , out int number) || number < 1 || number > 9)
            {
                Console.WriteLine("You chose number that is not on the board. Try again.");
                Console.ReadLine();
                continue;
            }
            
                int index = Convert.ToInt32(input) - 1;

                if (board[index] == "X" || board[index] == "O")
                {
                    Console.WriteLine("You chose place where there already is someones choice. Try again");
                    Console.ReadLine();
                    continue;
                }

            board[index] = isPlayer1Turn ? "X" : "O";
            isPlayer1Turn = !isPlayer1Turn;
        }
    }
  
    public void Board()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i * 3 + j] + "|");
            }

            Console.WriteLine();
            Console.WriteLine("------");
        }
    }
}