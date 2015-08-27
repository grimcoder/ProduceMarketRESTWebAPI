using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using ProduceMarketAPI.Models;

namespace ProduceMarketAPI.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SalesController : ApiController
    {
        private static List<SaleClass> _sales;

        public static List<SaleClass> Sales
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



        public List<SaleClass> GetAllPrices()
        {
            return Sales;   
        }

        public List<SaleClass> GetPrice(long id)
        {
            return Sales.Where(@class => @class.Id == id).ToList();
        }

        public void DeleteSale(long id)
        {
            var oldSale = Sales.FirstOrDefault(@class => @class.Id == id);
            Sales.Remove(oldSale);
        }


        public void PostSale(SaleClass sale)
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
            
        }


    }
}
