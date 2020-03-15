using System.Runtime.Serialization;
namespace iStock.Model
{
    [DataContract]
    public class StocklistModel
    {

        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "Exchange")]
        public string Exchange { get; set; }

    }
}
