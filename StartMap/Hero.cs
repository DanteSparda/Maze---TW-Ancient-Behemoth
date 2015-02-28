using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class Hero
    {
        static public int X { get; set; } //Left
        static public int Y { get; set; } //Top



        public static void RemoveHero()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }


    }
}
