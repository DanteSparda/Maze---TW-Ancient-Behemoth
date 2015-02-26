using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace StartMap
{
    class Program
    {
        static void mazeGraphics(int[,] maze, int length, int height)
        {
            for (int row = 0; row < length; row++)
            {

                for (int col = 0; col < height; col++)
                {

                    if (maze[row, col] == 1)
                    {
                        Console.Write("▓");
                    }
                    else if (maze[row, col] == 1337)
                    {
                        Console.Write("@");
                    }



                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            DrawMaze maze = new DrawMaze();
            timer.Start();
            int counter = 0;
            //VAJNO !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //Timera raboti (ima thred.sleep koeto spira igrata za 5 sekundi za tova stava na vseki 5 sekundi timera (ako go nqma mnogo miga(nz kak da go opravq)
            //Moje timera da ne se izpisva po vreme na igrata a samo posle (ideq e, no kato cqlo obnovqvaneto na maze-a stava 4esto i tova preebava neshtata (nz kak da 
            //se opravi atm)
            //Vtoro razmerite na array-a tqbva da se namalqt zashtoto otdolu ima super mnogo nenujno prostranstvo koeto preebava neshtata
            //Treto Highscore-a raboti, moje da go testvate - puskate igrata 4akate da izleze ot do/while i posle otvarqte Highscores.txt i tam shte go ima zapisan
            //rezultata.

             do
              {
                  Console.WriteLine("{0:D2}:{1:D2}:{2:D2}", timer.Elapsed.Minutes, timer.Elapsed.Seconds, timer.Elapsed.Milliseconds);
            maze.FillingMaze();
            maze.PLayerFigure();
            mazeGraphics(maze.mazeArray, maze.getLength(), maze.getHeight());
            Thread.Sleep(5000);
            Console.Clear();
            counter++;
              } while (counter!=10);
            timer.Stop(); //<-- spirame timera
             HighscoreSaving(timer); //<-- tova zapisva score-a vuv txt file. Ako iskate da go testvate http://pastebin.com/AGFzN0fn
            // Tochno do .sln file trqbva da slojite fail-a Highscores.txt, v nego trqbva da ima 10 - 00:00:000 (bez kavi4ki bez nishto prosto da sa 10 i da sa na 
            // po edin red vsqko
            //Moje da se napravi da izpisva ako highscore-a e na purvo mqsto ili ako vuobshte vleze, no tova shte e kum kraq (za da mojem da rabotim s neshtata ot
            // maze-a (sire4 timer-a, koito v momenta ne e mnogo implementiran)



            /*Tova cqloto koeto e po-nagore trqbva da e v 1 do while
             * sled kato izleze ot nego shte zapazvame 
             * 
             * */

        }
        static void HighscoreSaving(Stopwatch clock)
        {
            List<string> highscores = new List<string>();
            //Stopwatch clock = new Stopwatch();
            //clock.Start();
            //Console.ReadLine();
            //clock.Stop();
            var builder = new StringBuilder();
            builder.AppendFormat("{0:D2}:{1:D2}:{2:D2}", clock.Elapsed.Minutes, clock.Elapsed.Seconds, clock.Elapsed.Milliseconds);
            Console.WriteLine(builder);
            var highscoreReader = new StreamReader("..\\..\\..\\Highscores.txt");
            using (highscoreReader)
            {
                for (int i = 0; i < 10; i++)
                {
                    string currentLine = highscoreReader.ReadLine();
                    highscores.Add(currentLine);
                }

            }
            string currentResult = builder.ToString();
            highscores.Add(currentResult);
            highscores.Sort();
            highscores.Reverse();
            highscores.RemoveAt(10);
            var highscoreWriter = new StreamWriter("..\\..\\..\\Highscores.txt");
            using (highscoreWriter)
            {
                foreach (var scores in highscores)
                {
                    highscoreWriter.WriteLine("{0:00:00}", scores);
                }
            }
        }

    }
}