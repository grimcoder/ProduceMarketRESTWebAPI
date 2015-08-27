using System;
using System.IO;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;

namespace ProduceMarketAPI.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SalesController : ApiController
    {

        public static SaleClass[] sales;

        static SalesController()
        {
            JsonSerializer serializer = new JsonSerializer();
            string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\sales.json";
            sales = serializer.Deserialize<SaleClass[]>(new JsonTextReader(File.OpenText(path)));
        }

        public SaleClass[] GetAllPrices()
        {
            return sales;   
        }

        public SaleClass[] GetPrice(long id)
        {
            return sales.Where(@class => @class.Id == id).ToArray();
        }

    }
}
