using System.Runtime.Serialization;
namespace iStock.Model
{
    [DataContract]
    public class PortfolioModel
    {

        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "SymbolName")]
        public string SymbolName { get; set; }

        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "Exchange")]
        public string Exchange { get; set; }

        [DataMember(Name = "PurchaseDate")]
        public DateTimeFormat PurchaseDate { get; set; }

        [DataMember(Name = "PurchasePrice")]
        public double PurchasePrice { get; set; }

        [DataMember(Name = "Quantity")]
        public int Quantity { get; set; }

    }
}
