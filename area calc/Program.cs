using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace area_calc
{
    internal class Program
    {
        static void writemenu(string[] list, int index)
        { Console.Clear();
            Console.WriteLine("=========\n Area Calculator \n==========");
            for(int i  = 0; i < list.Length; i++)
            {
                
                if (i == index)
                {
                    Console.WriteLine("\x1b[48;2;0;175;0m" + list[i] + "\x1b[0m");
                }
                else
                {
                    Console.WriteLine(list[i]);
                }
            }
        }
        static double areacalc(int index, float val1, float val2, float val3)
        {
            if (index == 0 || index == 5) // circle and square only require 1 variable
            {
                val2 = 0; val3 = 0;
                if (index == 0) { return val1 * Math.PI * val1; }
                else { return val1 * val1; }
            }
            else if (index == 1 || index == 2 || index == 4 || index == 6)//rectangle, triangle, parallelogram, ellipse
            { val3 = 0; if (index == 1 || index == 4) { return val1 * val2; }
                else if (index == 2) { return val1 * val2 * 0.5; }
                else if (index == 6) { return val1 * val2 * Math.PI; }
                else { return 0.0; }
            }
            else if(index == 3) { return val3 * (val1 + val2) * 0.5; }
            else { return 0.0; }
        }
        static void Main(string[] args)
        {
            string[] list = {"1. Circle", "2. Rectangle",
                "3. Triangle", "4. Trapezoid",
                "5. Paralellogram", "6. Sqaure", "7. Ellipse", "X. Exit"};
            bool menu = true; int index = 0;
            writemenu(list, index);
            while (menu)
            {
                ConsoleKeyInfo read= Console.ReadKey();
                if (read.Key == ConsoleKey.UpArrow && index > 0)
                {
                    index--; writemenu(list, index);
                }
                if (read.Key == ConsoleKey.DownArrow && index < list.Length -1)
                {
                    index++; writemenu(list, index);
                }
                if(read.Key == ConsoleKey.Enter && index != 7)
                {
                    menu = false;
                }
            }
            float[] values = new float [3];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter val" + (i+1) + " (values outside of formula for shapes will be ignored)");
                values[i] = float.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Area of {list[index]}: " + areacalc(index, values[0], values[1], values[2]) + "units");
        }
    }
}
