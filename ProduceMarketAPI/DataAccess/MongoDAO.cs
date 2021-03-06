﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProduceMarketAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;


namespace ProduceMarketAPI.DataAccess
{
    public class MongoDAO : IDataAccess
    {

        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public MongoDAO()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("ProduceMarket");
        }


        public  List<PriceClass> GetAllPrices()
        {
            var collection = _database.GetCollection<BsonDocument>("prices");
            var filter = new BsonDocument();
            var count = 0;
            var result = collection.Find(filter).ToListAsync();

            return null;
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