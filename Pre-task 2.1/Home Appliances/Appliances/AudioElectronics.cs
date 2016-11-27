using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Home_Appliances.Appliances
{
    [DataContract(Name = "AudioElectronics")]
    public abstract class AudioElectronics : ElectricalAppliances
    {
        [DataMember]
        public string DataType { get; private set; }

        public AudioElectronics(int id, string producer, string model, string color, int powerW)
            : base(id, producer, model, color, powerW)
        {
            DataType = "Audio";
        }
    }
}
