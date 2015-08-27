using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProduceMarketAPI.Controllers;
using ProduceMarketAPI.Models;

namespace ProduceMarketAPI.DataAccess
{
    public class DataAccess : IDataAccess
    {

        private static List<PriceClass> _prices;

        private static List<PriceClass> Prices
        {
            get
            {
                if (_prices == null)
                {
                    try
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        string path = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\Prices.json";
                        var reader = new JsonTextReader(File.OpenText(path));
                        _prices = serializer.Deserialize<PriceClass[]>(reader).ToList();
                        reader.Close();
                    }
                    catch (Exception exception)
                    {

                        throw;
                    }
                }

                return _prices;
            }

            set { _prices = value; }
        }

        public List<PriceClass> GetAllPrices()
        {
            return Prices;
        }

        public PriceClass[] GetPrice(long id)
        {
            return Prices.Where(@class => @class.Id == id).ToArray();
        }

        public void PostNewPrice(PriceClass price)
        {

            if (price.Id == 0)
            {
                var newId = Prices.Select(@class => @class.Id).Max() + 1;
                price.Id = newId;
                Prices.Add(price);

                var newPriceChange = new PriceChangeClass
                {
                    Action = "New",
                    Id = price.Id,
                    ItemName = price.ItemName,
                    Price = price.Price,
                    priceWas = 0
                };
                PriceChanges.Add(newPriceChange);
            }

            else
            {
                var oldPrice = Prices.FirstOrDefault(@class => @class.Id == price.Id);
                Prices.Remove(oldPrice);
                Prices.Add(price);

                var newPriceChange = new PriceChangeClass
                {
                    Action = "Edit",
                    Id = price.Id,
                    ItemName = price.ItemName,
                    Price = price.Price,
                    priceWas = oldPrice.Price
                };
                PriceChanges.Add(newPriceChange);
            }
            Utils.SaveToFile();
        }

        public  void DeletePrice(long id)
        {
            var oldPrice = Prices.FirstOrDefault(@class => @class.Id == id);
            Prices.Remove(oldPrice);

            var newPriceChange = new PriceChangeClass
            {
                Action = "Delete",
                Id = oldPrice.Id,
                ItemName = oldPrice.ItemName,
                Price = 0,
                priceWas = oldPrice.Price
            };
            PriceChanges.Add(newPriceChange);
            Utils.SaveToFile();
        }

        private static List<PriceChangeClass> _priceChanges;

        private static List<PriceChangeClass> PriceChanges
        {
            get
            {
                if (_priceChanges == null)
                {
                    try
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        string path = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\priceChanges.json";
                        var reader = new JsonTextReader(File.OpenText(path));
                        _priceChanges = serializer.Deserialize<PriceChangeClass[]>(reader).ToList();
                        reader.Close();
                    }
                    catch (Exception exception)
                    {
                        throw;
                    }
                }
                return _priceChanges;
            }
        }

        public  List<PriceChangeClass> GetPriceChanges()
        {
            return PriceChanges;
        }

        private static List<SaleClass> _sales;

        private static  List<SaleClass> Sales
        {
            get
            {
                if (_sales == null)
                {
                    try
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        string path = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\Sales.json";
                        var reader = new JsonTextReader(File.OpenText(path));
                        _sales = serializer.Deserialize<SaleClass[]>(reader).ToList();
                        reader.Close();
                    }
                    catch (Exception exception)
                    {
                        throw;
                    }

                }
                return _sales;
            }
            set
            {
                _sales = value;
            }
        }

        public  List<SaleClass> GetAllSales()
        {
            return Sales;
        }

        public  List<SaleClass> GetSale(long id)
        {
            return Sales.Where(@class => @class.Id == id).ToList();
        }

        public  void DeleteSale(long id)
        {
            var oldSale = Sales.FirstOrDefault(@class => @class.Id == id);
            Sales.Remove(oldSale);
            Utils.SaveToFile();
        }

        public  void PostSale(SaleClass sale)
        {
            if (sale.Id == 0)
            {
                long newId = Sales.Select(@class => @class.Id).Max() + 1;
                sale.Id = newId;
                Sales.Add(sale);
            }
            else
            {
                Sales = Sales.Where(@class => @class.Id != sale.Id).ToList();
                Sales.Add(sale);
            }
            Utils.SaveToFile();
        }
    
    }
}