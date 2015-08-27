using System.Runtime.Serialization;

namespace ProduceMarketAPI.Models
{
    [DataContract]
    public class SaleDetailClass
    {
        [DataMember]
        public string ItemName;
        [DataMember]
        public double Price;
        [DataMember]
        public double Units;
    }
}