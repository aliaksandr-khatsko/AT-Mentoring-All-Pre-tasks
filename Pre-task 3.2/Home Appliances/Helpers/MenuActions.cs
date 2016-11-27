using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Appliances.Helpers
{
    public class MenuActions
        {
            public void MainMenu()
            {
                Console.WriteLine("***Home Appliances System***");
                Console.WriteLine("To upload default appliances please enter Default and press Enter");
                Console.WriteLine("To upload Home Appliances from txt file please enter TXT and press Enter");
                Console.WriteLine("To upload Home Appliances from data file please enter BIN and press Enter");
            }

            public void FunctionsMenu()
            {
                Console.WriteLine("1: Save appliances to TXT file");
                Console.WriteLine("2: Save appliances to BIN file");
                Console.WriteLine("3: Switch On an appliance");
                Console.WriteLine("4: Switch Off an appliance");
                Console.WriteLine("5: Sort appliances by Power");
                Console.WriteLine("6: Range appliances by Power");
                Console.WriteLine("7: Delete an appliance");
            }
    }
}
