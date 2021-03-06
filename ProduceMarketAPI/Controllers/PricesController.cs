﻿using System.Collections.Generic;
using System.Net.Mime;
using System.Web.Http;
using System.Web.Http.Cors;
using ProduceMarketAPI.Models;

namespace ProduceMarketAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PricesController : ApiController
    {

        public PricesController()
        {
            
        }
        private readonly DataAccess.IDataAccess dataAccess = Utils.ResolveDataAccess();

        public List<PriceClass> GetAllPrices()
        {
            return dataAccess.GetAllPrices();
        }

        public PriceClass[] GetPrice(long id)
        {
            return dataAccess.GetPrice(id);
        }

        public void PostNewPrice(PriceClass price)
        {
            dataAccess.PostNewPrice(price);
        }

        public void DeletePrice(long id)
        {
            dataAccess.DeletePrice(id);
        }
    }
}