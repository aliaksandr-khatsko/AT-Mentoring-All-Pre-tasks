using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    class CalculatorApp
    {

     
        static void Main(string[] args)
        {
            Boolean calcNeverStop = false;
            do
            {
                Double firstNum = 0;
                Boolean correctNumber1 = false;
                do
                {
                    try
                    {
                        Console.WriteLine("Please, enter first number");
                        String firstNumberStr = Console.ReadLine();
                        firstNum = Double.Parse(firstNumberStr);
                        correctNumber1 = true;
                    }
                    catch (System.FormatException e)
                    {
                        Console.WriteLine("Wrong characters, please try again");
                    }
                } while (correctNumber1 == false);


                String op;
                Boolean correctOperator = false;
                Console.WriteLine("Please, choose an operator (+,-,*,/)");
                op = Console.ReadLine();
                do
                {
                    if (String.Equals(op, "+"))
                    {
                        correctOperator = true;
                    }

                    else if (String.Equals(op, "-"))
                    {
                        correctOperator = true;
                    }

                    else if (String.Equals(op, "/"))
                    {
                        correctOperator = true;
                    }

                    else if (String.Equals(op, "*"))
                    {
                        correctOperator = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong operator, choose an operator (+,-,*,/)");
                        op = Console.ReadLine();
                    }
                } while (correctOperator == false);


                Double secondNum = 0;
                Boolean correctNumber2 = false;
                do
                {
                    try
                    {
                        Console.WriteLine("Please, enter second number");
                        String secondNumberStr = Console.ReadLine();
                        secondNum = Double.Parse(secondNumberStr);
                        correctNumber2 = true;
                    }
                    catch (System.FormatException ex)
                    {
                        Console.WriteLine("Wrong characters, please try again");
                    }

                } while (correctNumber2 == false);



                Double result = 0;
                switch (op)
                {
                    case "+":
                        result = MathOperations.add(firstNum, secondNum);
                        Console.WriteLine("Result = " + result + "  (Press Enter to continue)");
                        break;
                    case "-":
                        result = MathOperations.substract(firstNum, secondNum);
                        Console.WriteLine("Result = " + result + "  (Press Enter to continue)");
                        break;
                    case "*":
                        result = MathOperations.multiply(firstNum, secondNum);
                        Console.WriteLine("Result = " + result + "  (Press Enter to continue)");
                        break;
                    case "/":
                        if (secondNum != 0)
                        {
                            result = MathOperations.divide(firstNum, secondNum);
                            Console.WriteLine("Result = " + result + "  (Press Enter to continue)");
                        }
                        else
                        {
                            Console.WriteLine("Division of {0} by zero is impossible. Please, press Enter and try again", firstNum);
                        }
                        break;
                    default:
                        break;
                }

                
                Console.ReadLine();

            } while (calcNeverStop == false);
            
        }
                  

    }
        

}
