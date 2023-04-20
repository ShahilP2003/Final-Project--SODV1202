﻿using System;
using System.Data.Common;
using System.Numerics;
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
        public players(int player)
        {
            currentPlayer = player;
        }

        public int icon() { return currentPlayer; }
        
        public int UpdatePlayer()
        {
            if(currentPlayer == 1) 
            {
                return currentPlayer++;
            }
            else if(currentPlayer == 2)
            {
                return currentPlayer--;
            }
            else { return currentPlayer = 1;}
            
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
            for (int row = 5 ; row >= 0; row--) 
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
                else if(grid[i, col] == value && grid[i + 1, col] == value && grid[i + 2, col] == value && grid[i + 3, col] == value)
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

        /*public string CheckWinHorizontal(int col, int value)
        {
            bool win = false;
            for (int i = 0; i < 6; i++)
            {
                if (grid[i,col]== value && grid[i, col + 1] == value && grid[i, col + 2] == value && grid[i, col + 3] == value)
                {
                    win = true;
                    break;
                }
                else if (grid[i, col] == value && grid[i, col - 1] == value && grid[i, col - 2] == value && grid[i, col - 3] == value)
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
        */

    }

    

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Connect 4!");

            Grid grid = new Grid();
            grid.Display();

            players player = new players(1);

            Console.WriteLine("\nPlayer " + player.DisplayPlayer() + ", choose a column ");
            grid.ReplaceGridValue(3, player.icon());
            grid.Display();
            player.UpdatePlayer();

            Console.WriteLine("\nPlayer " + player.DisplayPlayer() + ", choose a column ");
            grid.ReplaceGridValue(2, player.icon());
            grid.Display();
            player.UpdatePlayer();

            Console.WriteLine("\nPlayer " + player.DisplayPlayer() + ", choose a column ");
            grid.ReplaceGridValue(4, player.icon());
            grid.Display();
            player.UpdatePlayer();

            Console.WriteLine("\nPlayer " + player.DisplayPlayer() + ", choose a column ");
            grid.ReplaceGridValue(2, player.icon());
            grid.Display();
            player.UpdatePlayer();

            Console.WriteLine("\nPlayer " + player.DisplayPlayer() + ", choose a column ");
            grid.ReplaceGridValue(5, player.icon());
            grid.Display();
            player.UpdatePlayer();

            Console.WriteLine("\nPlayer " + player.DisplayPlayer() + ", choose a column ");
            grid.ReplaceGridValue(2, player.icon());
            grid.Display();
            player.UpdatePlayer();

            Console.WriteLine("\nPlayer " + player.DisplayPlayer() + ", choose a column ");
            grid.ReplaceGridValue(6, player.icon());
            grid.Display();
            grid.CheckWinHorizontal(6, player.icon());
            player.UpdatePlayer();

        }
    }
}