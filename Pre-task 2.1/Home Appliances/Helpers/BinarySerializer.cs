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
    public class BinarySerializer
    {
        private const string SourcesDirectory = "/Sources/";
        private const string FileName = "ElectricalAppliances.dat";
        public void Serialize(List<ElectricalAppliances> applianceses)
        {
            Type[] knownTypes = new Type[] { typeof(Televisor), typeof(MultimediaAcousticSystem), typeof(Notebook), typeof(PC), typeof(Fridge), typeof(Washer), typeof(Ketle), typeof(VacuumCleaner) };
            var serializer = new DataContractSerializer(typeof(List<ElectricalAppliances>), knownTypes);
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory + SourcesDirectory;
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            using (FileStream fs = new FileStream(directoryPath + FileName, FileMode.Create))
            {
                using (var writer = XmlDictionaryWriter.CreateBinaryWriter(fs))
                {
                    serializer.WriteObject(writer, applianceses);
                }
            }
            Console.WriteLine("Appliances Saved");
            Console.ReadLine();

        }

        public List<ElectricalAppliances> Deserialize()
        {
            Type[] knownTypes = new Type[] { typeof(Televisor), typeof(MultimediaAcousticSystem), typeof(Notebook), typeof(PC), typeof(Fridge), typeof(Washer), typeof(Ketle), typeof(VacuumCleaner) };
            DataContractSerializer dsr = new DataContractSerializer(typeof(List<ElectricalAppliances>), knownTypes);
            var serializer = new DataContractSerializer(typeof(List<ElectricalAppliances>), knownTypes);
            List<ElectricalAppliances> electricalApp;
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory + SourcesDirectory;
            using (FileStream fs = new FileStream(directoryPath + FileName, FileMode.Open))
            {
                using (var reader = XmlDictionaryReader.CreateBinaryReader(fs, XmlDictionaryReaderQuotas.Max))
                {
                    electricalApp = (List<ElectricalAppliances>)serializer.ReadObject(reader);
                    for (int i = 0; i < electricalApp.Count; i++)
                    {
                        electricalApp[i].ID = i + 1;
                    }
                }

                return electricalApp;
            }
            Console.WriteLine("Appliances Uploaded");
            Console.ReadLine();

        }
    }
}
