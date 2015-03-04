namespace StartMap
{
    ﻿using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Media;
    using System.Text;
    using System.Threading;
    using System.Linq;

    class Maze
    {
        static Stopwatch timer = new Stopwatch();
        static DrawMaze maze = new DrawMaze();
        static bool win = false;
        static bool unlock = false;
        static bool musicLevelTwo = false;
        static string globalCurrentResult;

        static bool mapAfterGettingKey = false;
        //the Maze Hero
        public static Coordinate Hero { get; set; }

        private static void doMusicLevelTwo()
        {
            try
            {
                while (true)
                {
                    using (SoundPlayer player = new SoundPlayer("../../Nox Arcana - Night of the Wolf.wav"))
                    {
                        // Use PlaySync to load and then play the sound.
                        // ... The program will pause until the sound is complete.
                        player.PlaySync();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        static void Main()
        {
            if (!File.Exists("..\\..\\..\\Highscores.txt"))
            {
                using (File.Create("..\\..\\..\\Highscores.txt")) ;
            }
            var player = new SoundPlayer();
            try
            {
                player.SoundLocation = "../../Spooky Music Instrumental - Twilight Hollow.wav";
                player.Play();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            //name of the game split by words as we need to know exactly how many words there are in the Title for marketing reasons
            var name = new List<string> { "Maze", "Runner" };
            //we need to keep track of the letters in words of the console title for some reasons
            var LettersInWords = new List<int>();
            for (int i = 0; i < name.Count; i++)
            {
                LettersInWords.Add(name[i].Count());
            }
            Console.Title = string.Join("", name);

            Console.CursorVisible = false;

            Console.SetWindowSize(56, 30);
            maze.FillingMaze();
            maze.CreateDoors();
            maze.DrawingMaze();
            timer.Start();
            InitialGame();
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                if (musicLevelTwo)
                {
                    musicLevelTwo = false;
                    player.Stop();
                    ThreadStart threadDelegate = new ThreadStart(doMusicLevelTwo);
                    Thread newThread = new Thread(threadDelegate);
                    newThread.Start();
                }

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

                    try
                    {
                        HighscoreSaving(timer);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                        //   Console.WriteLine("File for saving score not found!");
                    }
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("\t  \\ \\   / /                   (_)      ");
                    Console.WriteLine("\t   \\ \\_/ /__  _   _  __      ___ _ __  ");
                    Console.WriteLine("\t    \\   / _ \\| | | | \\ \\ /\\ / / | '_ \\ ");
                    Console.WriteLine("\t     | | (_) | |_| |  \\ V  V /| | | | |");
                    Console.WriteLine("\t     |_|\\___/ \\__,_|   \\_/\\_/ |_|_| |_|");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(String.Format("{0," + (Console.WindowWidth / 2 + 7) + "}", "Well done friend!"));
                    string score = String.Format("Your score is {0}:{1}:{2}", timer.Elapsed.Minutes, timer.Elapsed.Seconds, timer.Elapsed.Milliseconds);
                    Console.WriteLine(String.Format("{0," + ( Console.WindowWidth / 2 + 9 ) + "}", score));
                    Console.WriteLine();

                    try
                    {
                        HighscorePrint();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                        // Console.WriteLine("High score file not found!\n{0}", ex.Message);
                    }

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
                X = 0,
                Y = 7
            };
            MoveHero(0, 7);
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.Gray;
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
                if (unlock)
                {
                    win = true;
                    return true;
                }

                return false;
            }
            if (!mapAfterGettingKey)
            {
                if (maze.mazeArray[c.Y, c.X] == 11)
                {
                    Console.Clear();
                    mapAfterGettingKey = true;
                    musicLevelTwo = true;
                    unlock = true;
                    maze.DeleteMaze();
                    maze.FillingMaze();
                    maze.DrawingMaze();
                    System.Threading.Thread.Sleep(550);
                    Console.Clear();
                    maze.CreateDoorsAfterKey();
                    maze.DrawingMazeLevelTwo(c.Y, c.X);
                    maze.mazeArray[c.Y, c.X] = 0;
                }
            }

            if (mapAfterGettingKey)
            {
                Console.Clear();
                maze.DrawingMazeLevelTwo(c.Y, c.X);
            }
            return true;
        }

        //removes the old hero as it moves
        static void RemoveHero()
        {
            Console.SetCursorPosition(Hero.X, Hero.Y);
            Console.Write(" ");
        }
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
            globalCurrentResult = currentResult;
            highscores.Add(currentResult);
            highscores.Sort();
            var lineCount = File.ReadAllLines("..\\..\\..\\Highscores.txt").Length;
            if ((new FileInfo("..\\..\\..\\Highscores.txt").Length) == 0)
            {
                highscores.Reverse();
            }
            else if (File.ReadLines("..\\..\\..\\Highscores.txt").Last() == "")
            {
                highscores.Reverse();
            }
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
            bool isGreen = false;
            string nullResult = "00:00:000";
            int placeCounter = 0;
            Array.Sort(result);
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                if (i == Array.IndexOf(result, globalCurrentResult))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    isGreen = true;
                }

                if (result[i] != nullResult && result[i] != String.Empty)
                {
                    placeCounter++;
                    int setCursorWidth = (Console.WindowWidth / 2) - 4;
                    string finalResult = String.Format("{0}. {1}", placeCounter, result[i]);
                    Console.WriteLine("\t\t     " + finalResult);
                }

                if (isGreen)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}