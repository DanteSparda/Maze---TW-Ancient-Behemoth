﻿using System;
using System.Media;
using System.Threading;

namespace StartMap
{
    class Maze
    {

        static DrawMaze maze = new DrawMaze();
        static bool win = false;
        static bool musicLevelTwo = false;
        static bool mapAfterGettingKey = false;
        //the Maze Hero
        public static Coordinate Hero { get; set; }

        private static void doMusicLevelTwo()
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


        static void Main()
        {
            SoundPlayer player = new SoundPlayer("../../Spooky Music Instrumental - Twilight Hollow.wav");
            player.Play();

            Console.Title = "MazeRunner";
            Console.SetWindowSize(56, 30);
            maze.FillingMaze();
            maze.CreateDoors();
            maze.DrawingMaze();
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
                    Console.Clear();
                    Console.WriteLine("\t   _  _      _                           ");
                    Console.WriteLine("\t   \\ \\   / /                   (_)      ");
                    Console.WriteLine("\t    \\ \\_/ /__  _   _  __      ___ _ __  ");
                    Console.WriteLine("\t     \\   / _ \\| | | | \\ \\ /\\ / / | '_ \\ ");
                    Console.WriteLine("\t      | | (_) | |_| |  \\ V  V /| | | | |");
                    Console.WriteLine("\t      |_|\\___/ \\__,_|   \\_/\\_/ |_|_| |_|");
                    Console.WriteLine();
                    Console.WriteLine();
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
                win = true;
            }
            if (maze.mazeArray[c.Y, c.X] == 11)
            {
                Console.Clear();
                mapAfterGettingKey = true;
                musicLevelTwo = true;
                maze.DeleteMaze();
                maze.FillingMaze();
                maze.DrawingMaze();
                System.Threading.Thread.Sleep(550);
                Console.Clear();
                maze.CreateDoors();
                maze.DrawingMazeLevelTwo(c.Y, c.X);
                maze.mazeArray[c.Y, c.X] = 0;
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
    }

    class Coordinate
    {
        public int X { get; set; } //Left
        public int Y { get; set; } //Top
    }
}