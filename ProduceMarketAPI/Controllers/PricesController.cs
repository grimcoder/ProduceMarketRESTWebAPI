using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;


namespace ProduceMarketAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PricesController : ApiController
    {

        public static PriceClass[] prices;

        static PricesController()
        {
            JsonSerializer serializer = new JsonSerializer();
            string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\prices.json";
            prices = serializer.Deserialize<PriceClass[]>(new JsonTextReader(File.OpenText(path)));
        }

        public PriceClass[] GetAllPrices()
        {
            return prices;
        }

        public PriceClass[] GetPrice(long id)
        {
            return prices.Where(@class => @class.Id == id).ToArray();
        }

        
    }
}
