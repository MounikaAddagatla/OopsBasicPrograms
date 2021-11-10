using OopsBasicPrograms.JsonInventoryModel;
using System;

namespace OopsBasicPrograms
{
    class Program
    {
      
        
        static void Main(string[] args)
        {
            Console.WriteLine("Oops Basic Programs");
            InventoryManagementMain inventoryMain = new InventoryManagementMain();
            Console.WriteLine("Choose 1.JSONInventoryDataManagement ReadData \n2 InventoryManager \n3 StockManagement \n4 Stock Commercialdata" );
            int options = Convert.ToInt32(Console.ReadLine());
            switch (options)
            {
                case 1:
                    inventoryMain.ReadData(@"D:\OopsBasicPrograms\OopsBasicPrograms\OopsBasicPrograms\JsonInventoryModel\Inventory.json");
                    break;
                case 2:
                    inventoryMain.ReadData(@"D:\OopsBasicPrograms\OopsBasicPrograms\OopsBasicPrograms\JsonInventoryModel\Inventory.json");
                    Console.WriteLine("Enter Rice or Wheat or Pulses ");
                    inventoryMain.Display(Console.ReadLine());
                    break;
                case 3:
                    StockManagement.Stock stock = new StockManagement.Stock();
                    stock.Display(@"D:\OopsBasicPrograms\OopsBasicPrograms\OopsBasicPrograms\StockManagement\Stock.json");
                    break;
                case 4:
                    StockManagement.Stock stockNew = new StockManagement.Stock();
                    stockNew.BuyStocks();
                    stockNew.SellStocks();
                    break;
                default:
                    Console.WriteLine("Choose valid option");
                    break;
            }
            Console.ReadLine();
        }
    }
}
