using System;
using System.IO;
using Newtonsoft.Json;

namespace ProduceMarketAPI.Controllers
{
    public static class Utils
    {
        private static  readonly DataAccess.DataAccess dataAccess = new DataAccess.DataAccess();
        public static void SaveToFile()
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();

                var prices = dataAccess.GetAllPrices();
                var sales = dataAccess.GetAllSales();
                var priceChanges = dataAccess.GetPriceChanges();

                string path = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\Prices.json";
                var writer = new JsonTextWriter(File.CreateText(path));
                serializer.Serialize(writer, prices);
                writer.Close();

                path = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\Sales.json";
                writer = new JsonTextWriter(File.CreateText(path));
                serializer.Serialize(writer, sales);
                writer.Close();

                path = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\priceChanges.json ";
                writer = new JsonTextWriter(File.CreateText(path));
                serializer.Serialize(writer, priceChanges);
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