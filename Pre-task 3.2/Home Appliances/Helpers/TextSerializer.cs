using Home_Appliances.Appliances;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Home_Appliances.Helpers
{
    public class TextSerializer
    {
        private const string SourcesDirectory = "/Sources/";
        private const string FileName = "ElectricalAppliances.txt";
        public void Serialize(List<ElectricalAppliances> electricalAppliances)
        {
            Type[] knownTypes = new Type[] { typeof(Televisor), typeof(MultimediaAcousticSystem), typeof(Notebook), typeof(PC), typeof(Fridge), typeof(Washer), typeof(Ketle), typeof(VacuumCleaner) };

            DataContractSerializer ser = new DataContractSerializer(typeof(List<ElectricalAppliances>), knownTypes);
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory + SourcesDirectory;
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            using (FileStream fs = new FileStream(directoryPath + FileName, FileMode.OpenOrCreate))
            {
                
                ser.WriteObject(fs, electricalAppliances);
            }

            Console.WriteLine("Appliances Saved");
            Console.ReadLine();
        }

        public List<ElectricalAppliances> Deserialize()
        {
            Type[] knownTypes = new Type[] { typeof(Televisor), typeof(MultimediaAcousticSystem), typeof(Notebook), typeof(PC), typeof(Fridge), typeof(Washer), typeof(Ketle), typeof(VacuumCleaner) };
            DataContractSerializer dsr = new DataContractSerializer(typeof(List<ElectricalAppliances>), knownTypes);

            List<ElectricalAppliances> electricalAppliences;
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory + SourcesDirectory;
            using (FileStream fs = new FileStream(directoryPath + FileName, FileMode.Open))
            {
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                electricalAppliences = (List<ElectricalAppliances>)dsr.ReadObject(reader);
                for (int i = 0; i < electricalAppliences.Count; i++)
                {
                    electricalAppliences[i].ID = i + 1;
                }
            }

            return electricalAppliences;
        }

    }
}
