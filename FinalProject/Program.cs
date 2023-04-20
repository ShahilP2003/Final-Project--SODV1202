using System;
using System.Data.Common;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.WindowsRuntime;

namespace FinalProject
{

    /*
     probelms:
        players 
            - the player must be able to manipulate the table (2d array) 
                (after choosing one of 7 rows they place a token at the bottom of the collumn)
            - make the program to switch players after they make a move in the grid
        Grid
            - making a 2d array and display it as our game board
            - (major issue) make a logic to figure if its a connect 4
                one for vertical, horizontal and diaganol
     
     */

    public class players
    {
        int currentPlayer;
        public players(int  player)
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
            Console.WriteLine("Enter the Column Number You Want to Place a Peice in: \n Options: 1, 2, 3, 4, 5, 6, 7");
            int input = int.Parse(Console.ReadLine());
            input--;
            return input;
        }
    }
    public class Grid 
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
            for (int row = 5; row >= 0; row--)
            {
                if (grid[row, col] == 0)
                {
                    grid[row, col] = value;
                    break;
                }
            }
        }

        public string CheckWinVertical(int col, int value)
        {
            bool win = false;
            for (int i = 0; i < 6; i++)
            {
                if (grid[i, col] == value && grid[i - 1, col] == value && grid[i - 2, col] == value && grid[i - 3, col] == value)
                {
                    win = true;
                    break;
                }
                else if (grid[i, col] == value && grid[i + 1, col] == value && grid[i + 2, col] == value && grid[i + 3, col] == value)
                {
                    win = true;
                    break;
                }
            }


            if (win == true)
            {
                return "Congrats Player " + value;
            }
            else
            {
                return "e";
            }
        }

        public string CheckWinHorizontal(int col, int value)
        {
            bool win = false;
            for (int i = 0; i < 6; i++)
            {
                if (grid[i, col] == value && grid[i, col - 1] == value && grid[i, col - 2] == value && grid[i, col - 3] == value)
                {
                    win = true;
                    break;
                }
                else if (grid[i, col] == value && grid[i, col + 1] == value && grid[i, col + 2] == value && grid[i, col + 3] == value)
                {
                    win = true;
                    break;
                }
            }

            if (win == true)
            {
                return "Congrats Player " + value;
            }
            else
            {
                return "e";
            }
        }

        public string CheckWinDiagonal( int row, int col, int value)
        {
            int count = 0;

            // Check diagonal from bottom-left to top-right
            for (int i = -3; i <= 3; i++)
            {
                if (row + i < 0 || row + i >= 6 || col + i < 0 || col + i >= 7)
                {
                    continue;
                }

                if (grid[row + i, col + i] == value)
                {
                    count++;
                    if (count == 4)
                    {
                        return "Congrats Player " + value;
                    }
                }
                else
                {
                    count = 0;
                }
            }

            count = 0;

            // Check diagonal from top-left to bottom-right
            for (int i = -3; i <= 3; i++)
            {
                if (row - i < 0 || row - i >= 6 || col + i < 0 || col + i >= 7)
                {
                    continue;
                }

                if (grid[row - i, col + i] == value)
                {
                    count++;
                    if (count == 4)
                    {
                        return "Congrats Player " + value;
                    }
                }
                else
                {
                    count = 0;
                }
            }

            return "e";
        }


    }

    public  abstract class WinnersFormula
    {

    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Connect 4!");
            Console.WriteLine("Rules \n" + "Player 1 = 1\n" + "Player 2 = 2\n" + "if one of the player connect 4 tokens in a line They win" );
                
            Grid grid = new Grid();
            grid.Display();

            players player = new players(1);
            
            int Winner = 0;

            while (Winner == 0)
            {
                try
                {
                Console.WriteLine("\nPlayer " + player.DisplayPlayer() + ", choose a column ");
                grid.ReplaceGridValue(player.GetInput(), player.icon());
                Console.WriteLine();
                grid.Display();
                player.UpdatePlayer();

                }
                catch (Exception) 
                { 
                    Console.WriteLine("\n" +
                        "Error pls input either 1, 2, 3, 4, 5, 6, or 7"); 
                }
               

            }
                
            

            

            


        }
    }
}