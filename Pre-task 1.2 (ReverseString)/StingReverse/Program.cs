using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StingReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter you sentence");
            string stringLine = Console.ReadLine();
            char[] stringArray = stringLine.ToCharArray();
            Array.Reverse(stringArray);
            Console.Write("You sentence is reversed: ");
            Console.WriteLine(stringArray);
            Console.ReadLine();
        }
    };
}
