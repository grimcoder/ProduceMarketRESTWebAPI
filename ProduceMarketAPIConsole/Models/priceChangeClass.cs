using System.Runtime.Serialization;

namespace ProduceMarketAPI.Models
{
    [DataContract]
    public class PriceChangeClass
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