using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Home_Appliances.Appliances
{
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

        public LargeAppliances(int id, string producer, string model, string color, int powerW, double heigh, double width, double depth)
            : base(id, producer, model, color, powerW)
        {
            ApplianceSize = "Large";
            this.Heigh = heigh;
            this.Width = width;
            this.Depth = depth;
        }
    }
}
