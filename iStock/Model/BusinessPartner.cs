using System.Runtime.Serialization;


namespace iStock.Model
{
    [DataContract]
    public class BusinessPartner
    {
        [DataMember(Name = "Personid")]
        public int Personid { get; set; }

        [DataMember(Name = "LastName")]
        public string LastName { get; set; }

        [DataMember(Name = "FirstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "ForeignName")]
        public string ForeignName { get; set; }     
    
        [DataMember(Name = "DateOfBirth")]
        public string DateOfBirth { get; set; }

        [DataMember(Name = "Gneder")]
        public string Gneder { get; set; }

        [DataMember(Name = "Email")]
        public string Email { get; set; }

        [DataMember(Name = "Website")]
        public string Website { get; set; }

        [DataMember(Name = "HomePhone")]
        public string HomePhone { get; set; }

        [DataMember(Name = "Fax")]
        public string Fax { get; set; }

        [DataMember(Name = "OfficePhone")]
        public string OfficePhone { get; set; }

        [DataMember(Name = "Mobile")]
        public string Mobile { get; set; }

        [DataMember(Name = "Currency")]
        public string Currency { get; set; }

        [DataMember(Name = "Address1")]
        public string Address1 { get; set; }

        [DataMember(Name = "Address2")]
        public string Address2 { get; set; }

        [DataMember(Name = "City")]
        public string City { get; set; }

        [DataMember(Name = "State")]
        public string State { get; set; }

        [DataMember(Name = "Zip")]
        public string Zip { get; set; }

        [DataMember(Name = "Country")]
        public string Country { get; set; }

        [DataMember(Name = "IsActive")]
        public bool IsActive { get; set; }

        

    }
}
