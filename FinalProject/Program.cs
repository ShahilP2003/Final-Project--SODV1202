using System;

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

    }

    

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Connect 4!");

            Grid grid = new Grid();
            grid.Display();
            Console.WriteLine();
            grid.ReplaceGridValue(3, 1);
            grid.Display();
            Console.WriteLine() ;
            grid.ReplaceGridValue(3, 2);
            grid.Display();

        }
    }
}
