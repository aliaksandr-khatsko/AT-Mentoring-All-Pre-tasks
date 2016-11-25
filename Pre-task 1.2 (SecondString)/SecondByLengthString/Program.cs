using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondByLengthString
{
    class Program
    {
        static void Main(string[] args)


        {

            message("first");
            string firstLine = Console.ReadLine();
            message("second");
            string secondLine = Console.ReadLine();
            message("third");
            string thirdLine = Console.ReadLine();
            message("forth");
            string forthLine = Console.ReadLine();
            message("fifth");
            string fifthLine = Console.ReadLine();
            string[] stringArray = { firstLine, secondLine, thirdLine, forthLine, fifthLine };

            Array.Sort(stringArray);

            Console.WriteLine("The following sentance is the second by length: " + stringArray[stringArray.Length - 2]);

            Console.ReadLine();

        }


        public static void message(string stringNumber)

        {
            Console.WriteLine("Enter your {0} sentance", stringNumber);
        }


    }
}
