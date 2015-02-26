using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Drawing
    {
        static void Main()
        {
            string[,] theMaze = new string[43, 43];
            //Leave the first circle of the maze empty so it can be the exit area(theMaze[0,0],theMaze[0,1]....theMaze[42,41]theMaze[42,42]
           
                for (int col = 1; col < theMaze.GetLength(0)-1; col++)
                {
                    theMaze[1,col] = "#";
                }
                for (int col = 1; col < theMaze.GetLength(0) ; col++)
                {
                    theMaze[42,col] = "#";
                }
                for (int row = 1; row < theMaze.GetLength(0)-1; row++)
                {
                    theMaze[row, 1] = "#";
                }
                for (int row = 1; row < theMaze.GetLength(0) - 1; row++)
                {
                    theMaze[row, 42] = "#";
                }
                for (int row = 1; row < theMaze.GetLength(0)-1; row++)
                {
                    for (int col = 1; col < theMaze.GetLength(0); col++)
                    {
                        if (theMaze[row,col]!="#")
                        {
                            theMaze[row, col] = " ";
                        }
                    }
                }
                for (int row = 1; row < theMaze.GetLength(0); row++)
                {
                    theMaze[row, 0] = " ";
                }
                for (int row = 0; row < theMaze.GetLength(0); row++)
                {
                    for (int col = 0; col < theMaze.GetLength(0); col++)
                    {
                        Console.Write(theMaze[row,col]);
                    }
                    Console.WriteLine();
                }
            
        }
    }

