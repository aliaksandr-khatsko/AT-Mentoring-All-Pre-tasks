using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Home_Appliances.Appliances
{
    [DataContract(Name = "Ketle")]
    public class Ketle : CookingAppliances
    {
        [DataMember]
        public double VolumeLiters { get; private set; }

        public Ketle(int id, string producer, string model, string color, int powerW, double volumeLiters)
            : base(id, producer, model, color, powerW)
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
            Console.WriteLine("ID: {0}", ID);
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
}
