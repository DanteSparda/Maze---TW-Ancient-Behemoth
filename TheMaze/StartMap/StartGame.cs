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

            Console.WriteLine("{0}", "Testing from Stan");
            //testing sync  Mihail
            // test Rado
            // test Svetli
            //Test Iliana 23
            //test Victor
            //test 2 Victor
            // Svetoslav
            //Opravih taimera za vratata i za igrata (a e ve4niq taimer koit oshte e za highscore, b e timera za vratite. Namirat se v GameClock)
            GameClock a = new GameClock();
            GameClock b = new GameClock();
            a.GameClockDisplay();
            b.GameTimerDisplay();

        }
    }
}
