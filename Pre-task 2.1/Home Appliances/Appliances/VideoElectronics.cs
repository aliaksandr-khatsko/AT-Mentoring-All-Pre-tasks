using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Home_Appliances.Appliances
{
    [DataContract(Name = "VideoElectronics")]
    public abstract class VideoElectronics : ElectricalAppliances
    {
        [DataMember]
        public string DataType { get; private set; }

        public VideoElectronics(int id, string producer, string model, string color, int powerW)
            : base(id, producer, model, color, powerW)
        {
            DataType = "Video";
        }
    }
}
