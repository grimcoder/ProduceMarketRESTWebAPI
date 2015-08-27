﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;


namespace ProduceMarketAPI.Controllers
{
    [DataContract]
    public class PriceClass 
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]        
        public double Price { get; set; }
        [DataMember]        
        public string ItemName { get; set; } 
    }


    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PricesController : ApiController
    {

        public static PriceClass[] prices =
        {
            new PriceClass{Id = 7, ItemName = "Cabbage", Price = 4.5}, 
            new PriceClass{Id = 8, ItemName = "Tomatos", Price = 3}, 
            new PriceClass{Id = 9, ItemName = "Arguila", Price = 3.5}, 
            new PriceClass{Id =10, ItemName = "Eggplant", Price = 2.4}, 
            new PriceClass{Id = 6, ItemName = "Beet", Price = 4.5}

        };

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
    }
}
