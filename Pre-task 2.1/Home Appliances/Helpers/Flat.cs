using Home_Appliances.Appliances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Appliances.Helpers
{
    public class Flat
    {
        public Flat()
        {
            flatAppliances = new List<ElectricalAppliances>();
        }

        private List<ElectricalAppliances> flatAppliances;

        public List<ElectricalAppliances> FlatAppliances
        {
            get { return flatAppliances; }
            private set { flatAppliances = value; }
        }

        public void CreateFlatAppliances(string userChoice)
        {
            bool quitCreateFlatAppliances = false;
            do
            {
                switch (userChoice)
                {
                    case "Default":
                        AddAppliance(new Televisor(1, "Sony", "HRMN-100", "Red", 1000, 42, "1280x960", "CLD"));
                        AddAppliance(new MultimediaAcousticSystem(2, "SVEN", "CDO-50", "Black", 20, 5.1));
                        AddAppliance(new Notebook(3, "ASUS", "SX50", "Black", 325, "2x2000GHr", 1000000, 8000, "GeForce NX500", "800x600", 15, true));
                        AddAppliance(new PC(4, "Pentium", "5", "Black", 550, "5x2000GHr", 1000000, 4000, "GeForce sX8000", "1920x1080", 24, false));
                        AddAppliance(new Fridge(5, "Atlant", "SX200", "White", 500, 1.9, 0.6, 0.7, true));
                        AddAppliance(new Washer(6, "LG", "L5", "Silver", 800, 1.2, 1.0, 0.45, 800, 5));
                        AddAppliance(new Ketle(7, "Bosh", "S5", "Silver", 550, 1.2));
                        AddAppliance(new VacuumCleaner(8, "Samsung", "GCRE1800", "Purple", 600, 1800));
                        ReturnAppliances();
                        quitCreateFlatAppliances = true;
                        break;
                    case "TXT":
                        var serializer = new TextSerializer();
                        flatAppliances = serializer.Deserialize();
                        ReturnAppliances();
                        quitCreateFlatAppliances = true;
                        break;
                    case "BIN":
                        BinarySerializer binSerializer = new BinarySerializer();
                        flatAppliances = binSerializer.Deserialize();
                        foreach (var app in flatAppliances)
                        ReturnAppliances();
                        quitCreateFlatAppliances = true;
                        break;
                    default:
                        Console.WriteLine("Wrong command, choose from the following options (Default, TXT, BIN)");
                        userChoice = Console.ReadLine();
                        quitCreateFlatAppliances = false;
                        break;
                }
            } while (quitCreateFlatAppliances == false);

        }

        public void ChangeFlatAppliances(string userChoice)
        {
            bool quitChangeFlatAppliances = false;
            do
            {
                switch (userChoice)
                {
                    case "1":
                        var serializer = new TextSerializer();
                        serializer.Serialize(flatAppliances);
                        quitChangeFlatAppliances = true;
                        break;
                    case "2":
                        var binserializer = new BinarySerializer();
                        binserializer.Serialize(flatAppliances);
                        quitChangeFlatAppliances = true;
                        break;
                    case "3":
                        SwitchOnMenu();
                        ReturnAppliances();
                        quitChangeFlatAppliances = true;
                        break;
                    case "4":
                        SwitchOffMenu();
                        ReturnAppliances();
                        quitChangeFlatAppliances = true;
                        break;
                    case "5":
                        SortByPower();
                        quitChangeFlatAppliances = true;
                        break;
                    case "6":
                        ShowFromRange();
                        ReturnAppliances();
                        quitChangeFlatAppliances = true;
                        break;
                    case "7":
                        DeleteMenu();
                        ReturnAppliances();
                        quitChangeFlatAppliances = true;
                        break;
                    default:
                        Console.WriteLine("Wrong command, choose a number (1-7)");
                        userChoice = Console.ReadLine();
                        quitChangeFlatAppliances = false;
                        break;
                }
            } while (quitChangeFlatAppliances == false);

        }


        private void AddAppliance(ElectricalAppliances appliance)
        {
            flatAppliances.Add(appliance);
        }

        public void ReturnAppliances()
        {
            foreach (var app in flatAppliances)
            {
                app.PrintSummary();
            }
        }

        public void SortByPower()
        {
             var orderByResult = from app in flatAppliances
                                orderby app.PowerW
                                select app;
             foreach (var ap in orderByResult)
             {
                 ap.PrintSummary();
             }
        }

        public List<ElectricalAppliances> ShowFromRange()
        {
            string rangeChoice = null;
            bool quitFirstRangeLoop = false;
            bool quitSecondRangeLoop = false;
            bool nextRangeChoiceLoop = false;
            double userChoiceLowPowerValue;
            double userChoiceHighPowerValue;

            do
            {
                Console.WriteLine("Enter a low value of Power range (only digits are applicable)");
                string userChoiceLowValue = Console.ReadLine();

                if (double.TryParse(userChoiceLowValue, out userChoiceLowPowerValue))
                {
                    Console.WriteLine("Low Power Value is {0}", userChoiceLowPowerValue);
                    quitFirstRangeLoop = true;
                }
                else
                {
                    Console.WriteLine("You entered wrong number. You may back to the main menu by entering Q");
                    rangeChoice = Console.ReadLine();
                    quitFirstRangeLoop = rangeChoice.Equals("Q");
                    nextRangeChoiceLoop = rangeChoice.Equals("Q");

                }

            } while (quitFirstRangeLoop == false);

            if (!nextRangeChoiceLoop)
            {
                do
                {
                    Console.WriteLine("Enter a high value of Power range (only digits are applicable)");
                    string userChoiceHighValue = Console.ReadLine();
                    bool tryParseResultSecond = double.TryParse(userChoiceHighValue, out userChoiceHighPowerValue);

                    if (tryParseResultSecond)
                    {
                        Console.WriteLine("High Power Value is {0}", userChoiceHighPowerValue);
                        quitSecondRangeLoop = true;

                    }
                    else
                    {
                        Console.WriteLine("You entered wrong number. You may back to the main menu by entering Q");
                        rangeChoice = Console.ReadLine();
                        quitSecondRangeLoop = rangeChoice.Equals("Q");
                    }

                } while (quitSecondRangeLoop == false);

                var element = flatAppliances.Where(ap => ap.PowerW < userChoiceHighPowerValue && ap.PowerW > userChoiceLowPowerValue).ToList();

            }
            return flatAppliances;
        }
        public List<ElectricalAppliances> SwitchOnMenu()
        {
            string quitSwitchChoiceOn = null;
            bool quitFromOnLoop = false;
            do
            {
                Console.WriteLine("To switch ON a specific appliance enter appliance ID and press Enter");
                string userChoiceDelete = Console.ReadLine();
                int applianceID;
                bool tryParseResult = int.TryParse(userChoiceDelete, out applianceID);
                if (tryParseResult)
                {
                    if (applianceID != 0 && applianceID <= flatAppliances.Count())
                    {
                        flatAppliances.ElementAt(applianceID - 1).SwitchOn();
                        quitFromOnLoop = true;
                    }
                }
                else
                {
                    Console.WriteLine("You entered wrong ID. You may back to the main menu by entering Q");
                    quitSwitchChoiceOn = Console.ReadLine();
                    quitFromOnLoop = quitSwitchChoiceOn.Equals("Q");
                }
            } while (quitFromOnLoop == false);
            return flatAppliances;
        }

        public List<ElectricalAppliances> SwitchOffMenu()
        {
            string quitSwitchChoiceOff = null;
            bool quitFromOffLoop = false;
            do
            {
                Console.WriteLine("To switch OFF a specific appliance enter appliance ID and press Enter");
                string userChoiceDelete = Console.ReadLine();
                int applianceID;
                bool tryParseResult = int.TryParse(userChoiceDelete, out applianceID);
                if (tryParseResult)
                {
                    if (applianceID != 0 && applianceID <= flatAppliances.Count())
                    {
                        flatAppliances.ElementAt(applianceID - 1).SwitchOff();
                        quitFromOffLoop = true;
                    }
                }
                else
                {
                    Console.WriteLine("You entered wrong ID. You may back to the main menu by entering Q");
                    quitSwitchChoiceOff = Console.ReadLine();
                    quitFromOffLoop = quitSwitchChoiceOff.Equals("Q");
                }
            } while (quitFromOffLoop == false);
            return flatAppliances;
        }

        public List<ElectricalAppliances> DeleteMenu()
        {
            string quitDeletechoice = null;
            bool quitFromDeleteLoop = false;
            do
            {
                Console.WriteLine("To delete specific appliance enter appliance ID and press Enter");
                string userChoiceDelete = Console.ReadLine();
                int applianceID;
                bool tryParseResult = int.TryParse(userChoiceDelete, out applianceID);
                if (tryParseResult)
                {
                    if (applianceID != 0 && applianceID <= flatAppliances.Count())
                    {
                        flatAppliances.RemoveAt(applianceID - 1);
                        for (int i = 1; i < flatAppliances.Count + 1; i++)
                        {
                            Console.WriteLine("ID: {0}", i);
                            flatAppliances[i - 1].PrintSummary();
                            quitFromDeleteLoop = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You entered wrong ID. You may back to the main menu by entering Q");
                    quitDeletechoice = Console.ReadLine();
                    quitFromDeleteLoop = quitDeletechoice.Equals("Q");

                }
            } while (quitFromDeleteLoop == false);
            return flatAppliances;
        }
    }
}
