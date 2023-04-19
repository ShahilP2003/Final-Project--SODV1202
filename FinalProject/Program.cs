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
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Grid grid = new Grid();
            grid.Display();


        }
    }
}
