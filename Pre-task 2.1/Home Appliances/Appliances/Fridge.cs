using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Home_Appliances.Appliances
{
    [DataContract(Name = "Fridge")]
    public class Fridge : LargeAppliances
    {
        [DataMember]
        public bool Frezer { get; private set; }

        public Fridge(int id, string producer, string model, string color, int powerW, double heigh, double width, double depth, bool freezer)
            : base(id, producer, model, color, powerW, heigh, width, depth)
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

            Console.WriteLine("ID: {0}", ID);
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
}
