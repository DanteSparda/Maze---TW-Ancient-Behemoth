using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartMap
{
    public class DrawMaze
    {
      //  private int playerRow = 14;
      //  private int playerCol = 28;
        private int startRow;
        private int startCol;
        private int endRow;
        private int endCol;
        public int[,] mazeArray = new int[29, 56];

        public void FillingMaze()
        {
            startRow = 0;
            startCol = 0;
            endRow = 28;
            endCol = 55;
            int counter = 0;
            while (true)
            {

                if (counter % 2 == 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int row = startRow; row <= endRow; row++)
                        {
                            mazeArray[row, startCol] = 1;
                        }
                        startCol++;

                        if (i == 1)
                        {

                            for (int k = 0; k < 2; k++)
                            {
                                for (int row = startRow + 1; row < endRow - 1; row++)
                                {
                                    mazeArray[row, startCol] = 0;
                                }
                                if (k == 0)
                                {
                                    startCol++;
                                }
                            }
                        }

                    }

                    for (int col = startCol - 1; col <= endCol; col++)
                    {
                        mazeArray[startRow, col] = 1;
                    }
                    startRow++;


                    for (int i = 0; i < 2; i++)
                    {
                        for (int row = startRow; row <= endRow; row++)
                        {
                            mazeArray[row, endCol] = 1;
                        }
                        endCol--;
                    }

                    for (int row = startRow + 1; row < endRow - 1; row++)
                    {
                        mazeArray[row, endCol - 1] = 0;
                    }
                    endCol--;

                    for (int col = startCol - 1; col <= endCol + 1; col++)
                    {
                        mazeArray[endRow, col] = 1;
                    }
                    endRow--;
                }
                else
                {
                    startRow++;
                    startCol++;
                    endRow--;
                    endCol--;
                }
                if (counter == 12)
                {
                    break;
                }
                counter++;
            }
            createDoors();
        }

        // The player's figure
        //public void PLayerFigure()
        //{
        //    mazeArray[playerRow, playerCol] = 1337;
        //}

        public void createDoors()
        {
            mazeArray[11, 4] = 0;
            mazeArray[11, 5] = 0;
            mazeArray[21, 4] = 0;
            mazeArray[21, 5] = 0;
            mazeArray[15, 12] = 0;
            mazeArray[15, 13] = 0;
            mazeArray[13, 20] = 0;
            mazeArray[13, 21] = 0;
            mazeArray[10, 38] = 0;
            mazeArray[10, 39] = 0;
            mazeArray[13, 46] = 0;
            mazeArray[13, 47] = 0;
            mazeArray[16, 27] = 0;
            mazeArray[16, 28] = 0;
            mazeArray[20, 24] = 0;
            mazeArray[22, 38] = 0;
            mazeArray[26, 25] = 0;
            mazeArray[28, 45] = 10;
            mazeArray[4, 38] = 0;
            mazeArray[4, 15] = 0;
            mazeArray[6, 25] = 0;
            mazeArray[18, 42] = 0;
            mazeArray[18, 43] = 0;
            mazeArray[9, 3] = 1;
            mazeArray[9, 2] = 1;
            mazeArray[10, 49] = 1;
            mazeArray[10, 48] = 1;
            mazeArray[17, 7] = 1;
            mazeArray[17, 6] = 1;
            mazeArray[15, 23] = 1;
            mazeArray[15, 22] = 1;
            mazeArray[19, 33] = 1;
            mazeArray[19, 32] = 1;
            mazeArray[21, 17] = 1;
            mazeArray[21, 18] = 1;
            mazeArray[14, 40] = 1;
            mazeArray[14, 41] = 1;
            mazeArray[25, 32] = 1;
            mazeArray[25, 31] = 1;
            mazeArray[27, 10] = 1;
            mazeArray[27, 11] = 1;
            mazeArray[20, 52] = 1;
            mazeArray[20, 53] = 1;
            mazeArray[17, 50] = 0;
            mazeArray[17, 51] = 0;
            mazeArray[7, 17] = 1;
            mazeArray[7, 18] = 1;
            mazeArray[5, 21] = 1;
            mazeArray[5, 20] = 1;
        }
        public int getLength()
        {
            return mazeArray.GetLength(0);
        }
        public int getHeight()
        {
            return mazeArray.GetLength(1);
        }
        public int GetStartCol()
        {
            return startCol;
        }
        public int GetLastCol()
        {
            return endCol;
        }
        public void DrawingMaze()
        {
            for (int row = 0; row < getLength(); row++)
            {
                for (int col = 0; col < getHeight(); col++)
                {

                    if (mazeArray[row, col] == 1)
                    {
                        Console.Write("▓");
                    }
                    else if (mazeArray[row, col] == 1337)
                    {
                        Console.Write("@");
                    }
                    else if (mazeArray[row, col] == 10)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("▓");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
