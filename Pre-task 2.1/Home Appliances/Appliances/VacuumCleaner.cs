using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Home_Appliances.Appliances
{
    [DataContract(Name = "VacuumCleaner")]
    public class VacuumCleaner : CleaningAppliances
    {
        [DataMember]
        public int SuctionPowerW { get; private set; }

        public VacuumCleaner(int id, string producer, string model, string color, int powerW, int suctionPowerW)
            : base(id, producer, model, color, powerW)
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
            Console.WriteLine("ID: {0}", ID);
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
