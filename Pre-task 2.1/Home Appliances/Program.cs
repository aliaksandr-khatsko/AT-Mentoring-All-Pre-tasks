using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace Home_Appliances
{
    class Program
    {
        static void Main(string[] args)
        {

            Televisor televisor = new Televisor("Sony", "HRMN-100", "Red", 1000, 42, "1280x960", "CLD");
            MultimediaAcousticSystem audioSystem = new MultimediaAcousticSystem("SVEN", "CDO-50", "Black", 20, 5.1);
            Notebook notebook = new Notebook("ASUS", "SX50", "Black", 325, "2x2000GHr", 1000000, 8000, "GeForce NX500", "800x600", 15, true);
            PC pc = new PC("Pentium", "5", "Black", 550, "5x2000GHr", 1000000, 4000, "GeForce sX8000", "1920x1080", 24, false);
            Fridge fridge = new Fridge("Atlant", "SX200", "White", 500, 1.9, 0.6, 0.7, true);
            Washer washer = new Washer("LG", "L5", "Silver", 800, 1.2, 1.0, 0.45, 800, 5);
            Ketle ketle = new Ketle("Bosh", "S5", "Silver", 550, 1.2);
            VacuumCleaner vacuumCleaner = new VacuumCleaner("Samsung", "GCRE1800", "Purple", 600, 1800);


            List<ElectricalAppliances> appliences = new List<ElectricalAppliances>();
            var serializer = new XmlSerializer();
            BinarySerializer binSerializer = new BinarySerializer();

            appliences.Add(audioSystem);
            appliences.Add(televisor);
            appliences.Add(notebook);
            appliences.Add(pc);
            appliences.Add(washer);

            bool appliactionNeverStop = false;

            do
            {
                Console.WriteLine("Home Appliances System is ready to use");
                Console.WriteLine();
                Console.WriteLine("To see a list of Home Appliances please enter LIST and press Enter");
                Console.WriteLine();
                Console.WriteLine("To upload Home Appliances from xml file please enter XML and press Enter");
                Console.WriteLine();
                Console.WriteLine("To upload Home Appliances from data file please enter DATA and press Enter");
                Console.WriteLine();
                Console.WriteLine("To save Home Appliances to xml file please enter SAVEXML and press Enter");
                Console.WriteLine();
                Console.WriteLine("To save Home Appliances to data file please enter SAVEDATA and press Enter");
                Console.WriteLine();
                Console.WriteLine("To delete an appliance enter D and press Enter");
                Console.WriteLine();
                Console.WriteLine("To Switch On an appliance enter ON and press Enter");
                Console.WriteLine();
                Console.WriteLine("To Switch Off an appliance enter OFF and press Enter");
                Console.WriteLine();
                Console.WriteLine("To Sort an appliance by Power enter SORT and press Enter");
                Console.WriteLine();
                Console.WriteLine("To see a list of appliance from specific range of power RANGE and press Enter");
                Console.WriteLine();

                bool correctCommand = false;
                string userChoiceFirstMenu = Console.ReadLine();
                do
                {
                    if (String.Equals(userChoiceFirstMenu, "LIST"))
                    {
                        correctCommand = true;
                    }

                    else if (String.Equals(userChoiceFirstMenu, "XML"))
                    {
                        correctCommand = true;
                    }

                    else if (String.Equals(userChoiceFirstMenu, "DATA"))
                    {
                        correctCommand = true;
                    }

                    else if (String.Equals(userChoiceFirstMenu, "SAVEXML"))
                    {
                        correctCommand = true;
                    }
                    else if (String.Equals(userChoiceFirstMenu, "SAVEDATA"))
                    {
                        correctCommand = true;
                    }
                    else if (String.Equals(userChoiceFirstMenu, "D"))
                    {
                        correctCommand = true;
                    }

                    else if (String.Equals(userChoiceFirstMenu, "ON"))
                    {
                        correctCommand = true;
                    }

                    else if (String.Equals(userChoiceFirstMenu, "OFF"))
                    {
                        correctCommand = true;
                    }

                    else if (String.Equals(userChoiceFirstMenu, "SORT"))
                    {
                        correctCommand = true;
                    }
                    else if (String.Equals(userChoiceFirstMenu, "RANGE"))
                    {
                        correctCommand = true;
                    }

                    else
                    {
                        Console.WriteLine("Wrong command, choose from the following options (LIST, XML, DATA, SAVEXML, SAVEDATA, D, ON, OFF, SORT, RANGE)");

                        userChoiceFirstMenu = Console.ReadLine();
                    }
                } while (correctCommand == false);

                switch (userChoiceFirstMenu)
                {
                    case "LIST":
                        for (int i = 1; i < appliences.Count + 1; i++)
                        {
                            Console.WriteLine("ID: {0}", i);
                            appliences[i - 1].PrintSummary();
                        }
                        break;
                    case "XML":
                        appliences = serializer.Deserialize();
                        break;
                    case "DATA":
                        appliences = binSerializer.Deserialize();
                        break;
                    case "SAVEXML":
                        serializer.Serialize(appliences);
                        break;
                    case "SAVEDATA":
                        binSerializer.Serialize(appliences);
                        break;
                    case "D":
                        for (int i = 1; i < appliences.Count + 1; i++)
                        {
                            Console.WriteLine("ID: {0}", i);
                            appliences[i - 1].PrintSummary();
                        }
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
                                if (applianceID != 0 && applianceID <= appliences.Count())
                                {
                                    appliences.RemoveAt(applianceID - 1);
                                    for (int i = 1; i < appliences.Count + 1; i++)
                                    {
                                        Console.WriteLine("ID: {0}", i);
                                        appliences[i - 1].PrintSummary();
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
                        break;
                    case "ON":
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
                                if (applianceID != 0 && applianceID <= appliences.Count())
                                {
                                    appliences.ElementAt(applianceID - 1).SwitchOn();
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
                        break;
                    case "OFF":
                        string switchChoiceOff = null;
                        bool quitFromOffLoop = false;
                        do
                        {
                            Console.WriteLine("To switch OFF a specific appliance enter appliance ID and press Enter");
                            string userChoiceDelete = Console.ReadLine();
                            int applianceID;
                            bool tryParseResult = int.TryParse(userChoiceDelete, out applianceID);
                            if (tryParseResult)
                            {
                                if (applianceID != 0 && applianceID <= appliences.Count())
                                {
                                    appliences.ElementAt(applianceID - 1).SwitchOff();
                                    quitFromOffLoop = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("You entered wrong ID. You may back to the main menu by entering Q");
                                switchChoiceOff = Console.ReadLine();
                                quitFromOffLoop = switchChoiceOff.Equals("Q");
                            }
                        } while (quitFromOffLoop == false);
                        break;
                    case "SORT":
                        appliences.OrderBy(ap => ap.PowerW);
                        for (int i = 1; i < appliences.Count + 1; i++)
                        {
                            Console.WriteLine("ID: {0}", i);
                            appliences[i - 1].PrintSummary();
                        }
                        break;
                    case "RANGE":
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

                            var element = appliences.Where(ap => ap.PowerW < userChoiceHighPowerValue && ap.PowerW > userChoiceLowPowerValue).ToList();
                            foreach (var obj in element)
                            {
                                obj.PrintSummary();
                            }
                        }

                    break;
                    default:
                        break;
                }
            } while (appliactionNeverStop == false);

        }

    }
    
    public class BinarySerializer
    {
        public void Serialize(List<ElectricalAppliances> applianceses)
        {
            Type[] knownTypes = new Type[] { typeof(Televisor), typeof(MultimediaAcousticSystem), typeof(Notebook), typeof(PC), typeof(Fridge), typeof(Washer), typeof(Ketle), typeof(VacuumCleaner) };
            var serializer = new DataContractSerializer(typeof(List<ElectricalAppliances>), knownTypes);


            using (FileStream fs = new FileStream("DataFile.dat", FileMode.Create))
            {
                using (var writer = XmlDictionaryWriter.CreateBinaryWriter(fs))
                {
                    serializer.WriteObject(writer, applianceses);
                }
            }
            Console.WriteLine("Appliances Saved");
            Console.ReadLine();

        }

        public List<ElectricalAppliances> Deserialize()
        {
            Type[] knownTypes = new Type[] { typeof(Televisor), typeof(MultimediaAcousticSystem), typeof(Notebook), typeof(PC), typeof(Fridge), typeof(Washer), typeof(Ketle), typeof(VacuumCleaner) };
            DataContractSerializer dsr = new DataContractSerializer(typeof(List<ElectricalAppliances>), knownTypes);
            var serializer = new DataContractSerializer(typeof(List<ElectricalAppliances>), knownTypes);
            List<ElectricalAppliances> electricalApp;
            using (FileStream fs = new FileStream("DataFile.dat", FileMode.Open))
            {
                using (var reader = XmlDictionaryReader.CreateBinaryReader(fs, XmlDictionaryReaderQuotas.Max))
                {
                    electricalApp = (List<ElectricalAppliances>)serializer.ReadObject(reader);
                }

                return electricalApp;
            }
            Console.WriteLine("Appliances Uploaded");
            Console.ReadLine();

        }
    }

    public class XmlSerializer
    {
        public void Serialize(List<ElectricalAppliances> electricalAppliances)
        {
            Type[] knownTypes = new Type[] { typeof(Televisor), typeof(MultimediaAcousticSystem), typeof(Notebook), typeof(PC), typeof(Fridge), typeof(Washer), typeof(Ketle), typeof(VacuumCleaner) };

            DataContractSerializer ser = new DataContractSerializer(typeof(List<ElectricalAppliances>), knownTypes);

            using (FileStream fs = new FileStream("ElectricalAppliances.xml", FileMode.OpenOrCreate))
            {
                ser.WriteObject(fs, electricalAppliances);
            }

            Console.WriteLine("Appliances Saved");
            Console.ReadLine();
        }

        public List<ElectricalAppliances> Deserialize()
        {
            Type[] knownTypes = new Type[] { typeof(Televisor), typeof(MultimediaAcousticSystem), typeof(Notebook), typeof(PC), typeof(Fridge), typeof(Washer), typeof(Ketle), typeof(VacuumCleaner) };
            DataContractSerializer dsr = new DataContractSerializer(typeof(List<ElectricalAppliances>), knownTypes);

            List<ElectricalAppliances> electricalAppliences;

            using (FileStream fs = new FileStream("ElectricalAppliances.xml", FileMode.Open))
            {
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                electricalAppliences = (List<ElectricalAppliances>)dsr.ReadObject(reader);
            }

            return electricalAppliences;
        }

    }

    [DataContract(Name = "ElectricalAppliances")]
    public abstract class ElectricalAppliances
    {
        [DataMember]
        public string Producer { get; private set; }

        [DataMember]
        public string Model { get; private set; }

        [DataMember]
        public string Color { get; private set; }

        [DataMember]
        public int PowerW { get; private set; }

        [DataMember]
        public bool SwitchStatus { get; private set; }

        public ElectricalAppliances(string producer, string model, string color, int powerW)
        {
            this.Producer = producer;
            this.Model = model;
            this.Color = color;
            this.PowerW = powerW;
            this.SwitchStatus = false;
        }

        abstract public void PrintSummary();

        public void SwitchOn()
        {
            this.SwitchStatus = true;
        }

        public void SwitchOff()
        {
            this.SwitchStatus = false;
        }
    }

    [DataContract(Name = "VideoElectronics")]
    public abstract class VideoElectronics : ElectricalAppliances
    {
        [DataMember]
        public string DataType { get; private set; }

        public VideoElectronics(string producer, string model, string color, int powerW)
            : base(producer, model, color, powerW)
        {
            DataType = "Video";
        }
    }

    [DataContract(Name = "AudioElectronics")]
    public abstract class AudioElectronics : ElectricalAppliances
    {
        [DataMember]
        public string DataType { get; private set; }

        public AudioElectronics(string producer, string model, string color, int powerW)
            : base(producer, model, color, powerW)
        {
            DataType = "Audio";
        }
    }

    [DataContract(Name = "Televisor")]
    public class Televisor : VideoElectronics
    {
        [DataMember]
        public double DiagonalInches { get; private set; }
        [DataMember]
        public string ScreenResolution { get; private set; }
        [DataMember]
        public string ScreenTechnology { get; private set; }



        public Televisor(string producer, string model, string color, int powerW, double diagonalInches, string screenResolution, string screenTechnology)
            : base(producer, model, color, powerW)
        {
            this.DiagonalInches = diagonalInches;
            this.ScreenResolution = screenResolution;
            this.ScreenTechnology = screenTechnology;
        }

        public override void PrintSummary()
        {
            string dispalaySwitchStatus = "No";

            if (SwitchStatus == true)
            {
                dispalaySwitchStatus = "Yes";
            }

            Console.WriteLine("Class: {0}", this.GetType().Name);
            Console.WriteLine("In work: {0}", dispalaySwitchStatus);
            Console.WriteLine("producer: {0}", Producer);
            Console.WriteLine("model: {0}", Model);
            Console.WriteLine("color: {0}", Color);
            Console.WriteLine("Power Consumption (W): {0}", PowerW);
            Console.WriteLine("diagonalInches: {0}", DiagonalInches);
            Console.WriteLine("screenResolution: {0}", ScreenResolution);
            Console.WriteLine("screenTechnology: {0}", ScreenTechnology);
            Console.WriteLine();
        }
    }

    [DataContract(Name = "MultimediaAcousticsSystem")]
    public class MultimediaAcousticSystem : AudioElectronics
    {
        [DataMember]
        public double AudioSystemType;

        public MultimediaAcousticSystem(string producer, string model, string color, int powerW, double audioSystemType)
            : base(producer, model, color, powerW)
        {
            this.AudioSystemType = audioSystemType;
        }

        public override void PrintSummary()
        {
            string dispalaySwitchStatus = "No";

            if (SwitchStatus == true)
            {
                dispalaySwitchStatus = "Yes";
            }

            Console.WriteLine("Class: {0}", this.GetType().Name);
            Console.WriteLine("In work: {0}", dispalaySwitchStatus);
            Console.WriteLine("Producer: {0}", Producer);
            Console.WriteLine("Model: {0}", Model);
            Console.WriteLine("Color: {0}", Color);
            Console.WriteLine("Power Consumption (W): {0}", PowerW);
            Console.WriteLine("AudioSystemType: {0}", AudioSystemType);
            Console.WriteLine();
        }
    }

    [DataContract(Name = "Computers")]
    public abstract class Computers : ElectricalAppliances
    {
        [DataMember]
        public string CPU { get; private set; }
        [DataMember]
        public int HDDVolumeMb { get; private set; }
        [DataMember]
        public int RAMVolumeMb { get; private set; }
        [DataMember]
        public string VideoCardModel { get; private set; }
        [DataMember]
        public string ScreenResolution { get; private set; }
        [DataMember]
        public double DiagonalInches { get; private set; }
        [DataMember]
        public bool Portative { get; private set; }

        public Computers(string producer, string model, string color, int powerW, string cpu, int hddVolumeMb, int ramVolumeMb, string videoCardModel, string screenResolution, double diagonalInches, bool portative)
            : base(producer, model, color, powerW)
        {
            this.CPU = cpu;
            this.DiagonalInches = diagonalInches;
            this.HDDVolumeMb = hddVolumeMb;
            this.RAMVolumeMb = ramVolumeMb;
            this.VideoCardModel = videoCardModel;
            this.ScreenResolution = screenResolution;
            this.Portative = portative;
        }

    }

    [DataContract(Name = "Notebook")]
    public class Notebook : Computers
    {
        public Notebook(string producer, string model, string color, int powerW, string cpu, int hddVolumeMb, int ramVolumeMb, string videoCardModel, string screenResolution, double diagonalInches, bool portative)
            : base(producer, model, color, powerW, cpu, hddVolumeMb, ramVolumeMb, videoCardModel, screenResolution, diagonalInches, true)
        {

        }

        public override void PrintSummary()
        {
            string dispalaySwitchStatus = "No";

            if (SwitchStatus == true)
            {
                dispalaySwitchStatus = "Yes";
            }

            string displayPortativeValue = "No";

            if (Portative == true)
            {
                displayPortativeValue = "Yes";
            }

            Console.WriteLine("Class: {0}", this.GetType().Name);
            Console.WriteLine("In work: {0}", dispalaySwitchStatus);
            Console.WriteLine("Portative: {0}", displayPortativeValue);
            Console.WriteLine("Producer: {0}", Producer);
            Console.WriteLine("Model: {0}", Model);
            Console.WriteLine("Color: {0}", Color);
            Console.WriteLine("Power Consumption (W): {0}", PowerW);
            Console.WriteLine("CPU: {0}", CPU);
            Console.WriteLine("HHD Volume (Mb): {0}", HDDVolumeMb);
            Console.WriteLine("RAM Volume (Mb): {0}", RAMVolumeMb);
            Console.WriteLine("Video Card: {0}", VideoCardModel);
            Console.WriteLine("Screen Resolution: {0}", ScreenResolution);
            Console.WriteLine("Diagonal (Inches): {0}", DiagonalInches);
            Console.WriteLine();
        }
    }


    [DataContract(Name = "PC")]
    public class PC : Computers
    {
        public PC(string producer, string model, string color, int powerW, string cpu, int hddVolumeMb, int ramVolumeMb, string videoCardModel, string screenResolution, double diagonalInches, bool portative)
            : base(producer, model, color, powerW, cpu, hddVolumeMb, ramVolumeMb, videoCardModel, screenResolution, diagonalInches, false)
        {

        }

        public override void PrintSummary()
        {
            string dispalaySwitchStatus = "No";

            if (SwitchStatus == true)
            {
                dispalaySwitchStatus = "Yes";
            }

            string displayPortativeValue = "Yes";

            if (Portative == false)
            {
                displayPortativeValue = "No";
            }

            Console.WriteLine("Class: {0}", this.GetType().Name);
            Console.WriteLine("In work: {0}", dispalaySwitchStatus);
            Console.WriteLine("Portative: {0}", displayPortativeValue);
            Console.WriteLine("Producer: {0}", Producer);
            Console.WriteLine("Model: {0}", Model);
            Console.WriteLine("Color: {0}", Color);
            Console.WriteLine("Power Consumption (W): {0}", PowerW);
            Console.WriteLine("CPU: {0}", CPU);
            Console.WriteLine("HHD Volume (Mb): {0}", HDDVolumeMb);
            Console.WriteLine("RAM Volume (Mb): {0}", RAMVolumeMb);
            Console.WriteLine("Video Card: {0}", VideoCardModel);
            Console.WriteLine("Screen Resolution: {0}", ScreenResolution);
            Console.WriteLine("Diagonal (Inches): {0}", DiagonalInches);
            Console.WriteLine();
        }
    }

    [DataContract(Name = "LargeAppliances")]
    public abstract class LargeAppliances : ElectricalAppliances
    {
        [DataMember]
        public string ApplianceSize { get; private set; }
        [DataMember]
        public double Heigh { get; private set; }
        [DataMember]
        public double Width { get; private set; }
        [DataMember]
        public double Depth { get; private set; }

        public LargeAppliances(string producer, string model, string color, int powerW, double heigh, double width, double depth)
            : base(producer, model, color, powerW)
        {
            ApplianceSize = "Large";
            this.Heigh = heigh;
            this.Width = width;
            this.Depth = depth;
        }
    }

    [DataContract(Name = "Fridge")]
    public class Fridge : LargeAppliances
    {
        [DataMember]
        public bool Frezer { get; private set; }

        public Fridge(string producer, string model, string color, int powerW, double heigh, double width, double depth, bool freezer)
            : base(producer, model, color, powerW, heigh, width, depth)
        {
            this.Frezer = freezer;
        }

        public override void PrintSummary()
        {
            string dispalaySwitchStatus = "No";

            if (SwitchStatus == true)
            {
                dispalaySwitchStatus = "Yes";
            }

            string FreezerPresence = "No";
            if (Frezer == true)
            {
                FreezerPresence = "Yes";
            }

            Console.WriteLine("Class: {0}", this.GetType().Name);
            Console.WriteLine("In work: {0}", dispalaySwitchStatus);
            Console.WriteLine("Producer: {0}", Producer);
            Console.WriteLine("Model: {0}", Model);
            Console.WriteLine("Color: {0}", Color);
            Console.WriteLine("Power Consumption (W): {0}", PowerW);
            Console.WriteLine("Freezer: {0}", FreezerPresence);
            Console.WriteLine("Heigh: {0}", Heigh);
            Console.WriteLine("Width: {0}", Width);
            Console.WriteLine("Depth: {0}", Depth);
            Console.WriteLine();
        }

    }

    [DataContract(Name = "Washer")]
    public class Washer : LargeAppliances
    {
        [DataMember]
        public int SpinSpeedRPM { get; private set; }
        [DataMember]
        public double VolumeLiters { get; private set; }

        public Washer(string producer, string model, string color, int powerW, double heigh, double width, double depth, int spinSpeedRPM, double volumeLiters)
            : base(producer, model, color, powerW, heigh, width, depth)
        {
            this.SpinSpeedRPM = spinSpeedRPM;
            this.VolumeLiters = volumeLiters;
        }

        public override void PrintSummary()
        {
            string dispalaySwitchStatus = "No";

            if (SwitchStatus == true)
            {
                dispalaySwitchStatus = "Yes";
            }

            Console.WriteLine("Class: {0}", this.GetType().Name);
            Console.WriteLine("In work: {0}", dispalaySwitchStatus);
            Console.WriteLine("Producer: {0}", Producer);
            Console.WriteLine("Model: {0}", Model);
            Console.WriteLine("Color: {0}", Color);
            Console.WriteLine("Power Consumption (W): {0}", PowerW);
            Console.WriteLine("Pin Speed (RPM): {0}", SpinSpeedRPM);
            Console.WriteLine("Volume (L): {0}", VolumeLiters);
            Console.WriteLine("Heigh: {0}", Heigh);
            Console.WriteLine("Width: {0}", Width);
            Console.WriteLine("Depth: {0}", Depth);
            Console.WriteLine();
        }

    }

    [DataContract(Name = "CookingAppliances")]
    public abstract class CookingAppliances : ElectricalAppliances
    {

        [DataMember]
        public string ApplianceType { get; private set; }

        public CookingAppliances(string producer, string model, string color, int powerW)
            : base(producer, model, color, powerW)
        {
            ApplianceType = "Cooking";
        }
    }

    [DataContract(Name = "Ketle")]
    public class Ketle : CookingAppliances
    {
        [DataMember]
        public double VolumeLiters { get; private set; }

        public Ketle(string producer, string model, string color, int powerW, double volumeLiters)
            : base(producer, model, color, powerW)
        {
            this.VolumeLiters = volumeLiters;
        }

        public override void PrintSummary()
        {
            string dispalaySwitchStatus = "No";

            if (SwitchStatus == true)
            {
                dispalaySwitchStatus = "Yes";
            }

            Console.WriteLine("Class: {0}", this.GetType().Name);
            Console.WriteLine("In work: {0}", dispalaySwitchStatus);
            Console.WriteLine("Producer: {0}", Producer);
            Console.WriteLine("Model: {0}", Model);
            Console.WriteLine("Color: {0}", Color);
            Console.WriteLine("Power Consumption (W): {0}", PowerW);
            Console.WriteLine("Volume (L): {0}", VolumeLiters);
            Console.WriteLine();
        }

    }

    [DataContract(Name = "CleaningAppliances")]
    public abstract class CleaningAppliances : ElectricalAppliances
    {
        [DataMember]
        public string ApplianceType { get; private set; }

        public CleaningAppliances(string producer, string model, string color, int powerW)
            : base(producer, model, color, powerW)
        {
            ApplianceType = "Cleaning";
        }
    }

    [DataContract(Name = "VacuumCleaner")]
    public class VacuumCleaner : CleaningAppliances
    {
        [DataMember]
        public int SuctionPowerW { get; private set; }

        public VacuumCleaner(string producer, string model, string color, int powerW, int suctionPowerW)
            : base(producer, model, color, powerW)
        {
            this.SuctionPowerW = suctionPowerW;
        }

        public override void PrintSummary()
        {
            string dispalaySwitchStatus = "No";

            if (SwitchStatus == true)
            {
                dispalaySwitchStatus = "Yes";
            }

            Console.WriteLine("Class: {0}", this.GetType().Name);
            Console.WriteLine("In work: {0}", dispalaySwitchStatus);
            Console.WriteLine("Producer: {0}", Producer);
            Console.WriteLine("Model: {0}", Model);
            Console.WriteLine("Color: {0}", Color);
            Console.WriteLine("Power Consumption (W): {0}", PowerW);
            Console.WriteLine("Suction Power (W): {0}", SuctionPowerW);
            Console.WriteLine();
        }

    }

}
