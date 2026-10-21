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
        static float ReadFloat(string prompt)
        {
            float result;
            Console.Write(prompt);
            while (!float.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Invalid input. Please enter a valid number: ");
            }
            return result;
        }
        static void Main(string[] args)
        {
            string[] list = {"Circle", "Rectangle",
                "Triangle", "Trapezoid",
                "Paralellogram", "Sqaure", "Ellipse", "X. Exit"};
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
            float val1 = 0, val2 = 0, val3 = 0;
            if (index == 0)
            {
                val1 = ReadFloat("Enter radius: ");
            }
            else if (index == 5)
            {
                val1 = ReadFloat("Enter side length: ");
            }
            else if (index == 3)
            {
                val1 = ReadFloat("Enter base a: ");
                val2 = ReadFloat("Enter base b: ");
                val3 = ReadFloat("Enter height: ");
            }
            else
            {
                val1 = ReadFloat("Enter first dimension: ");
                val2 = ReadFloat("Enter second dimension: ");
            }
            Console.WriteLine($"Area of {list[index]}: " + areacalc(index, val1, val2, val3) + " units");
        }
    }
}
