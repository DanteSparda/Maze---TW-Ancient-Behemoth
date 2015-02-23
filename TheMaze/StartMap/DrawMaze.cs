using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartMap
{
    public class DrawMaze
    {
        private int playerRow = 14;
        private int playerCol = 28;
        private int startRow;
        private int startCol;
        private int endRow;
        private int endCol;
        public int[,] mazeArray = new int[60, 60];

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
        public void PLayerFigure()
        {
            mazeArray[playerRow, playerCol] = 1337;
        }

        public void createDoors()
        {
            mazeArray[18, 42] = 0;
            mazeArray[18, 43] = 0;
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
    }
}