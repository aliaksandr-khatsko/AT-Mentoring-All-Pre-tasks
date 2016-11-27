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

            string[] stringArray = new string[5];
            Console.WriteLine("Enter 5 sentences");
            for (int i = 0; i < stringArray.Length; i++)
            {
                Console.Write("{0}st sentence: ", i + 1);
                stringArray[i] = Console.ReadLine();
            }

            string temp;
            for (int i = 0; i < stringArray.Length - 1; i++)
            {
                for (int j = i + 1; j < stringArray.Length; j++)
                {
                    if (stringArray[i].Length > stringArray[j].Length)
                    {
                        temp = stringArray[i];
                        stringArray[i] = stringArray[j];
                        stringArray[j] = temp;
                    }
                }
            }

            Console.WriteLine("Second by legth sentece: {0}", stringArray[3]);
            Console.ReadLine();

        }
    }
}
