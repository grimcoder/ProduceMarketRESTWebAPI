using System.Runtime.Serialization;

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
}