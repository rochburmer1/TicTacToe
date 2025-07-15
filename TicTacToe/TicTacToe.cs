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

            if (CheckWinner())
            {
                Console.Clear();
                Board();
                Console.WriteLine(isPlayer1Turn ? "Player 1 Wins!" : "Player 2 Wins!");
                break;
            }

            if (board.Count(cell => cell == "X" || cell == "O") == 9)
            {
                Console.Clear();
                Board();
                Console.WriteLine("Draw!");
                break;
            }
            isPlayer1Turn = !isPlayer1Turn;
        }
    }

    public bool CheckWinner()
    {
        bool row1 = board[0] == board[1] && board[1] == board[2] && (board[0]=="X" || board[0] == "O");
        bool row2 = board[3] == board[4] && board[4] == board[5]&& (board[3]=="X" || board[3] == "O");;
        bool row3 = board[6] == board[7] && board[7] == board[8]&& (board[6]=="X" || board[6] == "O");;
        bool col1 = board[0] == board[3] && board[3] == board[6]&& (board[0]=="X" || board[0] == "O");;
        bool col2 = board[1] == board[4] && board[4] == board[7]&& (board[1]=="X" || board[1] == "O");;
        bool col3 = board[2] == board[5] && board[5] == board[8]&& (board[2]=="X" || board[2] == "O");;
        bool diag1 = board[0] == board[4] && board[4] == board[8]&& (board[0]=="X" || board[0] == "O");;
        bool diag2 = board[2] == board[4] && board[4] == board[6]&& (board[2]=="X" || board[2] == "O");;

        return row1 || row2 || row3 || col1 || col2 || col3 ||diag1 || diag2;
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