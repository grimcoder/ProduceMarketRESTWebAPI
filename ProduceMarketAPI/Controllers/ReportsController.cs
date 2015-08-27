using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using ProduceMarketAPI.Models;

namespace ProduceMarketAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReportsController : ApiController
    {
        static  DataAccess.DataAccess dataAccess = new DataAccess.DataAccess();

        [ActionName("Prices")]
        public List<PriceChangeClass> GetPriceChanges()
        {
            return dataAccess.GetPriceChanges();
        }
    }
}
