using System;
using System.Threading;



class MAze
{
    static int HeroX;
    static int HeroY;

    static int[] horizontalDirections;  //keeps te postions of the Hero base on the index provided by currentDirectionX
    static int[] verticalDirections;
    static int currentDirectionX;       //returns 0 or 1; if 1 the Hero will move right, if 0 Hero moves left
    static int currentDirectionY;

    static void Main()
    {
        Settings();
        Engine();
    }
    static void Settings()
    {
        Console.Title = "Maze";                     //prints the word "Maze" on the Console
        Console.SetWindowSize(59, 39);
        Console.SetBufferSize(60, 40);
        Console.CursorVisible = false;
        HeroX = Console.WindowWidth / 2;            //sets the default position of the Hero
        HeroY = Console.WindowHeight / 2;           //sets the default position of the Hero
        horizontalDirections =new int[2] {-1, 1 };
        verticalDirections = new int[2] {-1, 1 };
        currentDirectionX = 0;
        currentDirectionY = 0;

    }
    static void MoveHero()     //calculates the next position of the Hero
    {
        Console.SetCursorPosition(HeroX, HeroY);   //before the new coordinates
        Console.Write(' ');
        HeroX += horizontalDirections[currentDirectionX];
        HeroY += verticalDirections[currentDirectionY];
        Console.SetCursorPosition(HeroX, HeroY);   //after the new coordinates
        Console.Write('@');
    }

    static void Engine()    //calcualtes the entire movement and logic in the game
    {
        while (true)
        {
            CollisionWithWall();
            MoveHero();
            Thread.Sleep(50);
        }
    }

    static void CollisionWithWall()
    {
        if (HeroX <= 0)
        {
            ChangeXDirection();
        }
        if (HeroX >= Console.WindowWidth - 5)
        {
            ChangeXDirection();
        }
        if (HeroY <= 0)
        {
            ChangeYDirection();
        }
        if (HeroX >=  Console.WindowHeight - 5)
        {
            ChangeYDirection();
        }

    }

    static void ChangeXDirection()  //method for changing the position of X coordinate
    {
        if (currentDirectionX == 0)
        {
            currentDirectionX = 1;
        }
        else
        {
            currentDirectionX = 0;
        }
    }

    static void ChangeYDirection() //method for changing the position of Y coordinate
    {
        if (currentDirectionY == 0)
        {
            currentDirectionY = 1;
        }
        else
        {
            currentDirectionY = 0;
        }
    }
}

