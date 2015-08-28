using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using ProduceMarketAPI.Models;

namespace ProduceMarketAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SalesController : ApiController
    {
        private static DataAccess.DataAccess dataAccess = new DataAccess.DataAccess();

        public List<SaleClass> GetAllPrices()
        {
            return dataAccess.GetAllSales();
        }

        public List<SaleClass> GetPrice(long id)
        {
            return dataAccess.GetSale(id);
        }

        public void DeleteSale(long id)
        {
            dataAccess.DeleteSale(id);
        }

        public void PostSale(SaleClass sale)
        {
            dataAccess.PostSale(sale);            
        }

    }
}
