using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace ProduceMarketAPI.Controllers
{
    public static class Utils
    {
        public static string DataDir
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\data";
            }
        }

        private static  readonly DataAccess.DataAccess dataAccess = new DataAccess.DataAccess();

        public static void SaveToFile()
        {

            try
            {

                JsonSerializer serializer = new JsonSerializer();
                var prices = dataAccess.GetAllPrices();
                var sales = dataAccess.GetAllSales();
                var priceChanges = dataAccess.GetPriceChanges();

                string path = DataDir + "\\Prices.json";
                var writer = new JsonTextWriter(File.CreateText(path));
                serializer.Serialize(writer, prices);
                writer.Close();

                path = DataDir + "\\Sales.json";
                writer = new JsonTextWriter(File.CreateText(path));
                serializer.Serialize(writer, sales);
                writer.Close();

                path = DataDir + "\\priceChanges.json ";
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