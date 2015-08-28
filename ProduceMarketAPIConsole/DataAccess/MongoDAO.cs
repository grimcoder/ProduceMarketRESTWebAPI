using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProduceMarketAPI.Models;

namespace ProduceMarketAPI.DataAccess
{
    public class MongoDAO : IDataAccess
    {
        public List<PriceClass> GetAllPrices()
        {
            throw new NotImplementedException();
        }

        public PriceClass[] GetPrice(long id)
        {
            throw new NotImplementedException();
        }

        public void PostNewPrice(PriceClass price)
        {
            throw new NotImplementedException();
        }

        public void DeletePrice(long id)
        {
            throw new NotImplementedException();
        }

        public List<PriceChangeClass> GetPriceChanges()
        {
            throw new NotImplementedException();
        }

        public List<SaleClass> GetAllSales()
        {
            throw new NotImplementedException();
        }

        public List<SaleClass> GetSale(long id)
        {
            throw new NotImplementedException();
        }

        public void DeleteSale(long id)
        {
            throw new NotImplementedException();
        }

        public void PostSale(SaleClass sale)
        {
            throw new NotImplementedException();
        }
    }
}