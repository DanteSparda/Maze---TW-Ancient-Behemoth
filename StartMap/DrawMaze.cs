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

        private int visionxRight = 3;
        private int visionxLeft = 2;
        private int visionYUp = 1;
        private int visionYDown = 2;


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
        }

        public void CreateDoors()
        {
            mazeArray[7, 0] = 3;
            mazeArray[7, 1] = 0;

            //secon key testing
            //mazeArray[7, 3] = 11;
            mazeArray[17, 29] = 1;
            mazeArray[25, 8] = 1;
            mazeArray[25, 9] = 1;
            mazeArray[18, 27] = 0;
            mazeArray[23, 30] = 1;
            mazeArray[23, 29] = 1;
            mazeArray[24, 35] = 0;
            mazeArray[24, 34] = 0;
            mazeArray[24, 38] = 1;
            mazeArray[25, 25] = 1;
            mazeArray[25, 24] = 1;
            mazeArray[25, 40] = 1;
            mazeArray[25, 41] = 1;
            mazeArray[26, 38] = 0;
            mazeArray[26, 39] = 0;
            mazeArray[18, 28] = 0;
            mazeArray[21, 39] = 1;
            mazeArray[23, 39] = 1;
            mazeArray[23, 40] = 1;
            mazeArray[22, 37] = 0;
            mazeArray[3, 16] = 1;
            mazeArray[3, 17] = 1;
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
            mazeArray[20, 25] = 0;
            mazeArray[22, 38] = 0;

            //key
            mazeArray[14, 27] = 11;

            //exit
            mazeArray[28, 45] = 10;

            mazeArray[4, 38] = 0;
            mazeArray[4, 39] = 0;
            mazeArray[4, 15] = 0;
            mazeArray[4, 14] = 0;
            mazeArray[6, 25] = 0;
            mazeArray[6, 26] = 0;
            mazeArray[11, 16] = 0;
            mazeArray[24, 16] = 0;
            mazeArray[24, 15] = 0;
            mazeArray[11, 17] = 0;
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
            mazeArray[19, 23] = 1;
            mazeArray[19, 22] = 1;
            mazeArray[21, 23] = 1;
            mazeArray[21, 22] = 1;
            mazeArray[20, 52] = 1;
            mazeArray[20, 53] = 1;
            mazeArray[17, 50] = 0;
            mazeArray[17, 51] = 0;
            mazeArray[7, 17] = 1;
            mazeArray[7, 16] = 1;
            mazeArray[5, 21] = 1;
            mazeArray[5, 20] = 1;
        }

        public void CreateDoorsAfterKey()
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

        public void DeleteMaze()
        {
            for (int i = 0; i < getHeight(); i++)
            {
                for (int j = 0; j < getLength(); j++)
                {
                    mazeArray[j, i] = 0;
                }
            }
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
                    else if (mazeArray[row, col] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("@");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    else if (mazeArray[row, col] == 11)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("╛");
                        Console.ForegroundColor = ConsoleColor.Gray;
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
        public void DrawingMazeLevelTwo(int x, int y)
        {
            for (int row = x - visionYUp; row < x + visionYDown; row++)
            {
                for (int col = y - visionxLeft; col < y + visionxRight; col++)
                {
                    Console.SetCursorPosition(col, row);

                    if (mazeArray[row, col] == 1)
                    {
                        Console.Write("▓");
                    }
                    else if (mazeArray[row, col] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("@");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    else if (mazeArray[row, col] == 11)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("╛");
                        Console.ForegroundColor = ConsoleColor.Gray;
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
