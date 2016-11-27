using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Home_Appliances.Appliances
{
    [DataContract(Name = "Computers")]
    public abstract class Computers : ElectricalAppliances
    {
        [DataMember]
        public string CPU { get; private set; }
        [DataMember]
        public int HDDVolumeMb { get; private set; }
        [DataMember]
        public int RAMVolumeMb { get; private set; }
        [DataMember]
        public string VideoCardModel { get; private set; }
        [DataMember]
        public string ScreenResolution { get; private set; }
        [DataMember]
        public double DiagonalInches { get; private set; }
        [DataMember]
        public bool Portative { get; private set; }

        public Computers(int id, string producer, string model, string color, int powerW, string cpu, int hddVolumeMb, int ramVolumeMb, string videoCardModel, string screenResolution, double diagonalInches, bool portative)
            : base(id, producer, model, color, powerW)
        {
            this.CPU = cpu;
            this.DiagonalInches = diagonalInches;
            this.HDDVolumeMb = hddVolumeMb;
            this.RAMVolumeMb = ramVolumeMb;
            this.VideoCardModel = videoCardModel;
            this.ScreenResolution = screenResolution;
            this.Portative = portative;
        }

    }
}
