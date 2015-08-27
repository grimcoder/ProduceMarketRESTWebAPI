using System.Runtime.Serialization;

namespace ProduceMarketAPI.Models
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
}