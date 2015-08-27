using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using ProduceMarketAPI.Models;

namespace ProduceMarketAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReportsController : ApiController
    {

        private readonly DataAccess.IDataAccess dataAccess = Utils.ResolveDataAccess();

        [ActionName("Prices")]
        public List<PriceChangeClass> GetPriceChanges()
        {
            return dataAccess.GetPriceChanges();
        }
    }
}
