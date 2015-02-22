using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartMap
{
    public class DrawMaze
    {
        private int startRow;
        private int startCol;
        private int endRow;
        private int endCol;
        public int[,] mazeArray = new int[31, 71];

        public void FillingMaze()
        {
            startRow = 0;
            startCol = 0;
            endRow = 30;
            endCol = 70;
            int counter = 0;
            while (true)
            {

                if (counter % 2 == 0)
                {
                    for (int row = startRow; row <= endRow; row++)
                    {
                        mazeArray[row, startCol] = 1;
                    }
                    startCol++;

                    for (int col = startCol; col <= endCol; col++)
                    {
                        mazeArray[startRow, col] = 1;
                    }
                    startRow++;

                    for (int row = startRow; row <= endRow; row++)
                    {
                        mazeArray[row, endCol] = 1;
                    }
                    endCol--;

                    for (int col = startCol; col <= endCol; col++)
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
                    endCol--; ;
                }
                if (startCol == 20)
                {
                    break;
                }
                counter++;
            }
            createDoors();
        }

        public void createDoors()
        {
            mazeArray[18, 42] = 0;
        }
        public int getLength()
        {
            return mazeArray.GetLength(0);
        }
        public int getHeight()
        {
            return mazeArray.GetLength(1);
        }

    }

    


