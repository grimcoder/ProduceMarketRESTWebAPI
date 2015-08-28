using System;
using System.Runtime.Serialization;
using ProduceMarketAPI.Controllers;

namespace ProduceMarketAPI.Models
{
        [DataContract]
    public class SaleClass
    {
            [DataMember]
        public DateTime Date;
            [DataMember]
        public long Id;
            [DataMember]
            public SaleDetailClass[] SaleDetails;
    }
}