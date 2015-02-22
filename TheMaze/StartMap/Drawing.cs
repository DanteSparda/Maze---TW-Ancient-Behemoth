using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Drawing
{
    private static int endCol = 40;
    private static int endRow = 40;
    private static string mazeChar = "/";
   
    
    public void DrawingMaze()
    {
        string[,] theMaze = new string[43, 43]; // 43,43
        //Leave the first circle of the maze empty so it can be the exit area(theMaze[0,0],theMaze[0,1]....theMaze[42,41]theMaze[42,42]
        ExitRow(theMaze);
       
            AlgorithmRow(theMaze, 3, 40, endCol);
            endCol -= 2;
        
        
            AlgorithmCol(theMaze, 3, 40, endRow);
            endRow-=2;


            theMaze[3, 1] = " ";

        for (int row = 0; row < theMaze.GetLength(0); row++)
        {
            for (int col = 0; col < theMaze.GetLength(0); col++)
            {
                Console.Write(theMaze[row, col]);
            }
            Console.WriteLine();
        }




    }
    static void ExitRow(string[,] theMaze)
    {
        for (int col = 1; col <= theMaze.GetLength(0) - 1; col++)
        {
            theMaze[1, col] = mazeChar;
        }
        for (int col = 1; col <= theMaze.GetLength(0)-1; col++)
        {
            theMaze[42, col] = mazeChar;
        }
        for (int row = 1; row <= theMaze.GetLength(0) - 1; row++)
        {
            theMaze[row, 1] = mazeChar;
        }
        for (int row = 1; row <= theMaze.GetLength(0) - 1; row++)
        {
            theMaze[row, 42] = mazeChar;
        }
        for (int row = 1; row <= theMaze.GetLength(0) - 1; row++)
        {
            for (int col = 1; col < theMaze.GetLength(0); col++)
            {
                if (theMaze[row, col] != mazeChar)
                {
                    theMaze[row, col] = " ";
                }
            }
        }
        for (int row = 1; row < theMaze.GetLength(0); row++)
        {
            theMaze[row, 0] = " ";
        }
    }
    static void AlgorithmRow(string[,] Maze, int Row, int startCol, int endCol)
    {
        for (int i = startCol; i < endCol; i++)
        {
            Maze[Row, i] = mazeChar;
        }
    }
    static void AlgorithmCol(string[,] Maze,int Col, int startRow, int endRow)
    {
        for (int i = startRow; i < endRow; i++)
        {
            Maze[i, Col] = mazeChar;
        }
    }
}

