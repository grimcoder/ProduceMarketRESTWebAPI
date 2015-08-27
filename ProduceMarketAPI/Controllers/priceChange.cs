using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProduceMarketAPI.Controllers
{
    [DataContract]
    public class priceChange
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public double priceWas { get; set; }
        [DataMember]
        public string ItemName { get; set; } 
        [DataMember]
        public string Action { get; set; } 


    }
}