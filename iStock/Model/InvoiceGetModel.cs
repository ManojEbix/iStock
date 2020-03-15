using System.Runtime.Serialization;

namespace iStock.Model
{
    [DataContract]
    public class InvoiceGetModel
    {
        [DataMember(Name = "FromDate")]
        public DateTimeFormat FromDate { get; set; }

        [DataMember(Name = "ToDate")]
        public DateTimeFormat ToDate { get; set; }

    }
}
