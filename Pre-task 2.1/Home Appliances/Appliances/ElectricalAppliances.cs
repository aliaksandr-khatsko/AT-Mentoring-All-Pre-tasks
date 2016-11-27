using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Home_Appliances.Appliances
{
    [DataContract(Name = "ElectricalAppliances")]
    public abstract class ElectricalAppliances
    {
        public int ID { get; set; }

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

        public ElectricalAppliances(int id, string producer, string model, string color, int powerW)
        {
            this.ID = id;
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
}
