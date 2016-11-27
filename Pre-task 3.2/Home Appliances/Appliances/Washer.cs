using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Home_Appliances.Appliances
{
    [DataContract(Name = "Washer")]
    public class Washer : LargeAppliances
    {
        [DataMember]
        public int SpinSpeedRPM { get; private set; }
        [DataMember]
        public double VolumeLiters { get; private set; }

        public Washer(int id, string producer, string model, string color, int powerW, double heigh, double width, double depth, int spinSpeedRPM, double volumeLiters)
            : base(id, producer, model, color, powerW, heigh, width, depth)
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
            Console.WriteLine("ID: {0}", ID);
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
}
