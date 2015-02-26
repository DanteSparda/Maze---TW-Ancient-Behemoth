using System;
using System.Media;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace StartMap
{
    class Maze
    {
        static Stopwatch timer = new Stopwatch();
        static DrawMaze maze = new DrawMaze();
        static bool win = false;
        //the Maze Hero
        public static Coordinate Hero { get; set; }



        private static void doMusic()
        {
            using (SoundPlayer player = new SoundPlayer("../../Spooky Music Instrumental - Twilight Hollow.wav"))
            {
                // Use PlaySync to load and then play the sound.
                // ... The program will pause until the sound is complete.
                player.PlaySync();
            }
        }


        static void Main()
        {


            ThreadStart threadDelegate = new ThreadStart(doMusic);
            Thread newThread = new Thread(threadDelegate);
            newThread.Start();
            timer.Start();

            Console.Title = "MazeRunner";
            Console.SetWindowSize(56, 30);
            maze.FillingMaze();
            maze.DrawingMaze();
            InitialGame();
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveHero(0, -1); break;

                    case ConsoleKey.RightArrow:
                        MoveHero(1, 0); break;

                    case ConsoleKey.DownArrow:
                        MoveHero(0, 1); break;

                    case ConsoleKey.LeftArrow:
                        MoveHero(-1, 0); break;
                }
                if (win == true)
                {
                    timer.Stop();
                    HighscoreSaving(timer);
                    Console.Clear();
                    Console.WriteLine("\t      __                    _       ");
                    Console.WriteLine("\t   \\ \\   / /                   (_)      ");
                    Console.WriteLine("\t    \\ \\_/ /__  _   _  __      ___ _ __  ");
                    Console.WriteLine("\t     \\   / _ \\| | | | \\ \\ /\\ / / | '_ \\ ");
                    Console.WriteLine("\t      | | (_) | |_| |  \\ V  V /| | | | |");
                    Console.WriteLine("\t      |_|\\___/ \\__,_|   \\_/\\_/ |_|_| |_|");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Well done friend!");
                    Console.WriteLine("Your score is {0}:{1}:{2}", timer.Elapsed.Minutes, timer.Elapsed.Seconds, timer.Elapsed.Milliseconds);
                    Console.WriteLine();
                    HighscorePrint();

                    Console.ReadLine();
                    return;

                }
            }
        }
        //Hero intitialisation
        static void InitialGame()
        {
            Hero = new Coordinate()
            {
                X = 28,
                Y = 14
            };
            MoveHero(28, 14);
        }
        //draw the hero
        static void MoveHero(int x, int y)
        {
            Coordinate newHero = new Coordinate()
            {
                X = Hero.X + x,
                Y = Hero.Y + y
            };

            if (CanMove(newHero))
            {
                RemoveHero();
                Console.SetCursorPosition(newHero.X, newHero.Y);
                Console.Write("@");
                Hero = newHero;



            }
        }
        //we may place restirctions on the console drawing here
        static bool CanMove(Coordinate c)
        {
            if (c.X < 0 || c.X >= Console.WindowWidth)
                return false;
            if (c.Y < 0 || c.Y >= Console.WindowHeight)
                return false;

            if (maze.mazeArray[c.Y, c.X] == 1)
            {
                return false;
            }
            if (maze.mazeArray[c.Y, c.X] == 10)
            {
                win = true;
            }
            return true;
        }

        //removes the old hero as it moves
        static void RemoveHero()
        {
            Console.SetCursorPosition(Hero.X, Hero.Y);
            Console.Write(" ");
        }
        //saving the highscore
        static void HighscoreSaving(Stopwatch clock)
        {
            List<string> highscores = new List<string>();
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
        //printing the highscore
        static void HighscorePrint()
        {
            string[] result = File.ReadAllLines("..\\..\\..\\Highscores.txt");
            Console.WriteLine();
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
        }
    }

    class Coordinate
    {
        public int X { get; set; } //Left
        public int Y { get; set; } //Top
    }
}
