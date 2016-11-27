using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Home_Appliances.Appliances
{
    [DataContract(Name = "CookingAppliances")]
    public abstract class CookingAppliances : ElectricalAppliances
    {

        [DataMember]
        public string ApplianceType { get; private set; }

        public CookingAppliances(int id, string producer, string model, string color, int powerW)
            : base(id, producer, model, color, powerW)
        {
            ApplianceType = "Cooking";
        }
    }
}
