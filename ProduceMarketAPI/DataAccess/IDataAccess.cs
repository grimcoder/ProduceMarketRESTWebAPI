using System.Collections.Generic;
using ProduceMarketAPI.Models;

namespace ProduceMarketAPI.DataAccess
{
    public interface IDataAccess
    {
        List<PriceClass> GetAllPrices();
        PriceClass[] GetPrice(long id);
        void PostNewPrice(PriceClass price);
        void DeletePrice(long id);
        List<PriceChangeClass> GetPriceChanges();
        List<SaleClass> GetAllSales();
        List<SaleClass> GetSale(long id);
        void DeleteSale(long id);
        void PostSale(SaleClass sale);
    }
}