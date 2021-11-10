using OopsBasicPrograms.JsonInventoryModel;
using System;

namespace OopsBasicPrograms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Oops Basic Programs");
            Console.WriteLine("Choose 1.JSONInventoryDataManagement");
            int options = Convert.ToInt32(Console.ReadLine());
            switch (options)
            {
                case 1:
                    InventoryManagementMain inventoryMain = new InventoryManagementMain();
                    inventoryMain.DisplayData(@"D:\OopsBasicPrograms\OopsBasicPrograms\OopsBasicPrograms\JsonInventoryModel\Inventory.json");
                    break;
                default:
                    Console.WriteLine("Choose valid option");
                    break;
            }
            Console.ReadLine();
        }
    }
}
