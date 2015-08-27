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
    public class ReportsController : ApiController
    {
        private static List<PriceChangeClass> _priceChanges;

        public static List<PriceChangeClass> PriceChanges
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

        [ActionName("Prices")]
        public List<PriceChangeClass> GetPriceChanges()
        {
            return PriceChanges;
        }

    }
}
