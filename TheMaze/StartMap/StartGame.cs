using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartMap
{
    class Program
    {
        static void Main(string[] args)
        {
            //Molq vsi4ki da commitnat 1 komentar za da znaem, 4e sme svurzani
            //Testing from Vladi
            //testing sync  Mihail
            // test Rado
            // test Svetli
            //Test Iliana 23
            //Opravih taimera za vratata i za igrata (a e ve4niq taimer koit oshte e za highscore, b e timera za vratite. Namirat se v GameClock)
            
            //Drawing map = new Drawing();
            //map.DrawingMaze();

            DrawMaze maze = new DrawMaze();
            maze.FillingMaze();
            int counter = 0;
            for (int i = 0; i < maze.getLength(); i++)
            {
               
                for (int j = 0; j < maze.getHeight(); j++)
                {   
                   
                    if (maze.mazeArray[i,j] == 1)
                    {
                        Console.Write("▓");
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
