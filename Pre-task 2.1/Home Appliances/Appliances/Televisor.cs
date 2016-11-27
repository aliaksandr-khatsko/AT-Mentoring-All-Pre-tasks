using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Home_Appliances.Appliances
{
    [DataContract(Name = "Televisor")]
    public class Televisor : VideoElectronics
    {
        [DataMember]
        public double DiagonalInches { get; private set; }
        [DataMember]
        public string ScreenResolution { get; private set; }
        [DataMember]
        public string ScreenTechnology { get; private set; }



        public Televisor(int id, string producer, string model, string color, int powerW, double diagonalInches, string screenResolution, string screenTechnology)
            : base(id, producer, model, color, powerW)
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
            Console.WriteLine("ID: {0}", ID);
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
}
