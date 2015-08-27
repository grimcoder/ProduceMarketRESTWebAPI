using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using ProduceMarketAPI.Models;


namespace ProduceMarketAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PricesController : ApiController
    {
        private static List<PriceClass> _prices;

        public static List<PriceClass> Prices
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
                ReportsController.PriceChanges.Add(newPriceChange);
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
                ReportsController.PriceChanges.Add(newPriceChange);
            }
            Utils.SaveToFile();
        }

        public void DeletePrice(long id)
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
            ReportsController.PriceChanges.Add(newPriceChange);
            Utils.SaveToFile();
        }



    }
}
