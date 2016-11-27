using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using Home_Appliances.Helpers;
using Home_Appliances.Appliances;

namespace Home_Appliances
{
    class Program
    {
        static void Main(string[] args)
        {
            var flatAppliances = new Flat();
            var mainMenu = new MenuActions();
            bool appliactionNeverStop = false;
            mainMenu.MainMenu();
            string userChoiceMainMenu = Console.ReadLine();
            flatAppliances.CreateFlatAppliances(userChoiceMainMenu);
            do
            {
                mainMenu.FunctionsMenu();
                string userChoiceFunctionsMenu = Console.ReadLine();
                flatAppliances.ChangeFlatAppliances(userChoiceFunctionsMenu);

            } while (appliactionNeverStop == false);
        }
     }
 }
