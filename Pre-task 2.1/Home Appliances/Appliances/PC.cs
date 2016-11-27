using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Home_Appliances.Appliances
{
    [DataContract(Name = "PC")]
    public class PC : Computers
    {
        public PC(int id, string producer, string model, string color, int powerW, string cpu, int hddVolumeMb, int ramVolumeMb, string videoCardModel, string screenResolution, double diagonalInches, bool portative)
            : base(id, producer, model, color, powerW, cpu, hddVolumeMb, ramVolumeMb, videoCardModel, screenResolution, diagonalInches, false)
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
            Console.WriteLine("ID: {0}", ID);
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
}
