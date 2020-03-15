using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace iStock.Model
{
    [DataContract]
    public class Search
    {
        [DataMember(Name = "Personid")]
        public int Personid { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

    }
}
