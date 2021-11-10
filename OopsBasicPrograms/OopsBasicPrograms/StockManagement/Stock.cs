using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OopsBasicPrograms.StockManagement
{
    class Stock
    {
        static string stockFilepath = @"D:\OopsBasicPrograms\OopsBasicPrograms\OopsBasicPrograms\StockManagement\Stock.json";
        static string filepath = @"D:\OopsBasicPrograms\OopsBasicPrograms\OopsBasicPrograms\StockManagement\Transaction.json";
        public List<StockModel> employee;
        public List<StockModel> accountant;
        public List<StockModel> manager;
        StockPortfolio stocks = new StockPortfolio();
        StockModel stockModel = new StockModel();
        List<StockModel> stockModels = new List<StockModel>();
        public void Display(string filepath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    var json = reader.ReadToEnd();
                    var items = JsonConvert.DeserializeObject<List<StockModel>>(json);
                    Console.WriteLine("Name  \t Number of Shares  \t Price");
                    foreach (var item in items)
                    {
                        Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + " {2} "+"\t", item.Name, item.NumberOfShares , item.Price);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DisplayStocks()
        {
            Console.WriteLine("enter any one of stock-[ employee Or accountant Or manager] which you want to display of that stock Management");
            string stock = Console.ReadLine();
            try
            {
                if (stock == "employee")
                {
                    Console.WriteLine("Name\tNumberOfShares\tPrice");
                    foreach (var stocks in employee)
                    {
                        Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}", stocks.Name, stocks.NumberOfShares, stocks.Price);
                    }
                }
                if (stock == "accountant")
                {
                    Console.WriteLine("Name\tNumberOfShares\tPrice");
                    foreach (var stocks in accountant)
                    {
                        Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}", stocks.Name, stocks.NumberOfShares, stocks.Price);
                    }
                }
                if (stock == "manager")
                {
                    Console.WriteLine("Name\tNumberOfShares\tPrice");
                    foreach (var stocks in manager)
                    {
                        Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}", stocks.Name, stocks.NumberOfShares, stocks.Price);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void BuyStocks()
        {
            Console.WriteLine("enter any one of state-[ employee Or accountant Or manager] which you want to buy of that state Stock");
            string state = Console.ReadLine();
            if (state == "employee")
            {
                Console.WriteLine("enter the employeeStock name which you want to buy");
                string name = Console.ReadLine();
                foreach (var stock in employee.ToArray())
                {
                    if (stock.Name == name)
                    {
                        stock.DateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        Console.WriteLine("enter numOfShares you want to buy for employeeStock");
                        int numOfShares = Convert.ToInt32(Console.ReadLine());
                        stock.NumberOfShares -= numOfShares;
                        stockModel = stock;
                        //update the filepathJson file to the specific NumberOfShares
                        try
                        {
                            StreamReader r = new StreamReader(stockFilepath);
                            var json = r.ReadToEnd();
                            var stockData = JsonConvert.DeserializeObject<List<StockModel>>(json);
                            foreach (var data in stockData)
                            {
                                if (data.Name == stock.Name)
                                    data.NumberOfShares += numOfShares;
                            }
                            r.Close();
                            //serialize the string to json
                            string result = JsonConvert.SerializeObject(stockData);
                            File.WriteAllText(stockFilepath, result);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        //serialize the string to json
                        string stockRes = JsonConvert.SerializeObject(stocks);
                        File.WriteAllText(filepath, stockRes);
                        return;
                    }
                }
                //if stock does not exist,create a new stock and update to the stockList
                stockModel.Name = name;
                stockModel.NumberOfShares = 5;
                stockModel.Price = 10;
                stockModel.DateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                Console.WriteLine("enter numOfShares you want to buy for employeeStock");
                int numOfShare = Convert.ToInt32(Console.ReadLine());
                stockModel.NumberOfShares -= numOfShare;
                employee.Add(stockModel);
                stocks.Employee = employee;
                //update the stockfilepath file to the specific NumberOfShares
                try
                {
                    StreamReader r = new StreamReader(stockFilepath);
                    var json = r.ReadToEnd();
                    var stockData = JsonConvert.DeserializeObject<List<StockModel>>(json);
                    stockModel.Name = name;
                    stockModel.NumberOfShares = 5;
                    stockModel.Price = 10;
                    stockModel.DateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    stockData.Add(stockModel);
                    stocks.Employee = employee;
                    r.Close();
                    //serialize the string to json
                    string result = JsonConvert.SerializeObject(stockData);
                    File.WriteAllText(stockFilepath, result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                //serialize the string to json
                string stockResult = JsonConvert.SerializeObject(stocks);
                File.WriteAllText(filepath, stockResult);
                return;
            }
        }
        public void SellStocks()
        {
            Console.WriteLine("enter any one of state-[ employee Or accountant Or manager] which you want to sell of that state Stock");
            string state = Console.ReadLine();
            if (state == "employee")
            {
                Console.WriteLine("enter the employeeStock name which you want to sell");
                string name = Console.ReadLine();
                foreach (var stock in employee)
                {
                    if (stock.Name == name)
                    {
                        stock.DateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        StockModel stockModel = new StockModel();
                        Console.WriteLine("enter numOfShares you want to sell from employeeStock");
                        int numOfShares = Convert.ToInt32(Console.ReadLine());
                        stock.NumberOfShares -= numOfShares;
                        stockModel = stock;
                    }
                }
                stocks.Employee = employee;
                //serialize the string to json
                string output = JsonConvert.SerializeObject(stocks);
                File.WriteAllText(filepath, output);
            }
        }
    }
}
