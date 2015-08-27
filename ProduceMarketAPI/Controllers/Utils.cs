using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProduceMarketAPI.Models;

namespace ProduceMarketAPI.Controllers
{
    public static class Utils
    {
        public static void SaveToFile()
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();

                var prices = PricesController.Prices;
                var sales = SalesController.Sales;
                var priceChanges = ReportsController.PriceChanges;

                string path = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\Prices.json";
                var writer = new JsonTextWriter(File.CreateText(path));
                serializer.Serialize(writer, PricesController.Prices);
                writer.Close();

                path = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\Sales.json";
                writer = new JsonTextWriter(File.CreateText(path));
                serializer.Serialize(writer, SalesController.Sales);
                writer.Close();

                path = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\priceChanges.json ";
                writer = new JsonTextWriter(File.CreateText(path));
                serializer.Serialize(writer, ReportsController.PriceChanges);
                writer.Close();

            }
            catch (Exception iException)
            {
                int x = 10;
                throw;
            }
        }
    }
}