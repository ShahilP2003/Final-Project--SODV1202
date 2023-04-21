using System;
using System.Data.Common;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;

namespace FinalProject
{
    public abstract class PlayerInfo
    {
        string Name;

        public PlayerInfo(string name)
        {
            Name = name;
        }
        public virtual string DisplayName()
        {
            return Name;
        }
    }


    public class players : PlayerInfo
    {
        int currentPlayer;
        public players(int player, string name) : base(name)
        {
            currentPlayer = player;
        }

        public int icon() { return currentPlayer; }

        public int UpdatePlayer()
        {
            if (currentPlayer == 1)
            {
                return currentPlayer++;
            }
            else if (currentPlayer == 2)
            {
                return currentPlayer--;
            }
            else { return currentPlayer = 1; }

        }

        public string DisplayPlayer()
        {
            if (currentPlayer == 1)
            {
                return "1";
            }
            else if (currentPlayer == 2)
            {
                return "2";
            }
            else
            {
                return "Invalid Player Count";
            }
        }

        public int GetInput()
        {
            Console.WriteLine("Enter the Column Number You Want to Place a Peice in: \nOptions: 1, 2, 3, 4, 5, 6, 7");
            int input = 0;
            try
            {
                input = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Invalid Input Try Again!\n");
            }
            input--;
            return input;
        }
    }

    public abstract class Draw 
    {
        //if grid is full meaning no zero int 2d it means draw
        //if draw reset the grid

        public void ResetGrid(int[,] grid)
        {
            int numRows = grid.GetLength(0);
            int numCols = grid.GetLength(1);
            bool hasZero = false;

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (grid[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }

                if (hasZero)
                {
                    break;
                }
            }

            if (!hasZero)
            {
                // Reset grid to all zeros
                for (int i = 0; i < numRows; i++)
                {
                    for (int j = 0; j < numCols; j++)
                    {
                        grid[i, j] = 0;
                    }
                }
            }
        }
    }


    public class Grid : Draw 
    {
        private int[,] grid = new int[6, 7];

        public void Display()
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Console.Write(grid[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        public void ReplaceGridValue(int col, int value)
        {
            try
            {
                for (int row = 5; row >= 0; row--)
                {

                    if (grid[row, col] == 0)
                    {
                        grid[row, col] = value;
                        break;
                    }

                }
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("Out Of The Board or Invalid Input\n");
            }
        }

        public bool CheckWinVertical(int col, int value)
        {
            bool win = false;
            for (int i = 0; i < 6; i++)
            {
                try
                {
                    if (grid[i, col] == value && grid[i - 1, col] == value && grid[i - 2, col] == value && grid[i - 3, col] == value)
                    {
                        win = true;
                        return win;
                    }
                    else if (grid[i, col] == value && grid[i + 1, col] == value && grid[i + 2, col] == value && grid[i + 3, col] == value)
                    {
                        win = true;
                        return win;
                    }
                }
                catch (System.IndexOutOfRangeException)
                {
                    break;
                }
            }
            return false;
        }

        public bool CheckWinHorizontal(int col, int value)
        {
            bool win = false;
            for (int i = 0; i < 6; i++)
            {
                try
                {
                    if (grid[i, col] == value && grid[i, col - 1] == value && grid[i, col - 2] == value && grid[i, col - 3] == value)
                    {
                        win = true;
                        return win;
                    }
                    else if (grid[i, col] == value && grid[i, col + 1] == value && grid[i, col + 2] == value && grid[i, col + 3] == value)
                    {
                        win = true;
                        return win;
                    }
                }
                catch (System.IndexOutOfRangeException)
                {
                    break;
                }
            }
            return false;
        }

        public bool CheckWinDiagonal(int col, int value)
        {
            bool win = false;
            for (int i = 0; i < 6; i++)
            {
                try
                {

                if (grid[i, col] == value)
                {

                    // Check for diagonal connections in the down-right direction
                    if (i + 3 < 6 && col + 3 < 7 && grid[i + 1, col + 1] == value && grid[i + 2, col + 2] == value && grid[i + 3, col + 3] == value)
                    {
                        win = true;
                        return win;
                    }
                    // Check for diagonal connections in the down-left direction
                    else if (i + 3 < 6 && col - 3 >= 0 && grid[i + 1, col - 1] == value && grid[i + 2, col - 2] == value && grid[i + 3, col - 3] == value)
                    {
                        win = true;
                        return win;
                    }
                    // Check for diagonal connections in the up-right direction
                    else if (i - 3 >= 0 && col + 3 < 7 && grid[i - 1, col + 1] == value && grid[i - 2, col + 2] == value && grid[i - 3, col + 3] == value)
                    {
                        win = true;
                        return win;
                    }
                    // Check for diagonal connections in the up-left direction
                    else if (i - 3 >= 0 && col - 3 >= 0 && grid[i - 1, col - 1] == value && grid[i - 2, col - 2] == value && grid[i - 3, col - 3] == value)
                    {
                        win = true;
                        return win;
                    }
                }
                }
                catch (System.IndexOutOfRangeException)
                {
                    break;
                }

            }
            return false;
        }

        public bool FindWinner(int col, int value)
        {
            if(CheckWinDiagonal(col, value) == true)
            {
                Console.WriteLine("Congradulations Player " + value);
                return true;
            }
            else if (CheckWinHorizontal(col, value) == true)
            {
                Console.WriteLine("Congradulations Player " + value);
                return true;
            }
            else if (CheckWinVertical(col, value) == true)
            {
                Console.WriteLine("Congradulations Player " + value);
                return true;
            }
            return false;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Connect 4!");
            Console.WriteLine("Rules: \n" +
                "Player 1 = 1 \n" +
                "Player 2 = 2 \n" +
                "First Player connect 4 of their # token wins");
            bool winner = false;

            Grid grid = new Grid();
            grid.Display();
            string name = "the gamer";
            players player = new players(1,name);
            int playersmove;

            while (winner == false)
            {
                Console.WriteLine("\nPlayer " + player.DisplayPlayer() + ", choose a column ");
                playersmove = player.GetInput();
                grid.ReplaceGridValue(playersmove, player.icon());
                grid.Display();
                winner = grid.FindWinner(playersmove, player.icon());
                player.UpdatePlayer();
            }
        }
    }
}
