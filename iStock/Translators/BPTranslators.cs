using iStock.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using iStock.Utility;
using Json.Net;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace iStock.Translators
{
    public static class BPTranslators
    {
        public static BusinessPartner TranslateAsBP(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new BusinessPartner();
            if (reader.IsColumnExists("Personid"))
                item.Personid = SqlHelper.GetNullableInt32(reader, "Personid");
            if (reader.IsColumnExists("LastName"))
                item.LastName = SqlHelper.GetNullableString(reader, "LastName");
            if (reader.IsColumnExists("FirstName"))
                item.FirstName = SqlHelper.GetNullableString(reader, "FirstName");
            if (reader.IsColumnExists("ForeignName"))
                item.ForeignName = SqlHelper.GetNullableString(reader, "ForeignName");
            //if (reader.IsColumnExists("DateOfBirth"))
                //item.DateOfBirth = reader.GE("DateOfBirth");

            if (reader.IsColumnExists("Gneder"))
                item.Gneder = SqlHelper.GetNullableString(reader, "Gneder");
            if (reader.IsColumnExists("Email"))
                item.Email = SqlHelper.GetNullableString(reader, "Email");
            if (reader.IsColumnExists("Website"))
                item.Website = SqlHelper.GetNullableString(reader, "Website");
            if (reader.IsColumnExists("HomePhone"))
                item.HomePhone = SqlHelper.GetNullableString(reader, "HomePhone");
            if (reader.IsColumnExists("OfficePhone"))
                item.OfficePhone = SqlHelper.GetNullableString(reader, "OfficePhone");
            if (reader.IsColumnExists("Mobile"))
                item.Mobile = SqlHelper.GetNullableString(reader, "Mobile");
            if (reader.IsColumnExists("Fax"))
                item.Fax = SqlHelper.GetNullableString(reader, "Fax");
            if (reader.IsColumnExists("Currency"))
                item.Currency = SqlHelper.GetNullableString(reader, "Currency");
            if (reader.IsColumnExists("Address1"))
                item.Address1 = SqlHelper.GetNullableString(reader, "Address1");
            if (reader.IsColumnExists("Address2"))
                item.Address2 = SqlHelper.GetNullableString(reader, "Address2");
            if (reader.IsColumnExists("City"))
                item.City = SqlHelper.GetNullableString(reader, "City");
            if (reader.IsColumnExists("State"))
                item.State = SqlHelper.GetNullableString(reader, "State");
            if (reader.IsColumnExists("Zip"))
                item.Zip = SqlHelper.GetNullableString(reader, "Zip");
            if (reader.IsColumnExists("Country"))
                item.Country = SqlHelper.GetNullableString(reader, "Country");
            if (reader.IsColumnExists("IsActive"))
                item.IsActive = SqlHelper.GetBoolean(reader, "IsActive");
            
            return item;
        }

        public static Search TranslateAsSearch(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new Search();
            if (reader.IsColumnExists("Personid"))
                item.Personid = SqlHelper.GetNullableInt32(reader, "Personid");
            if (reader.IsColumnExists("Name"))
                item.Name = SqlHelper.GetNullableString(reader, "Name");
            return item;
        }
        public static List<BusinessPartner> TranslateAsBPList(this SqlDataReader reader)
        {
            var list = new List<BusinessPartner>();
            while (reader.Read())
            {
                list.Add(TranslateAsBP(reader, true));
            }
            return list;
        }
        public static List<Search> TranslateAsBPSearch(this SqlDataReader reader)
        {
            var list = new List<Search>();
            while (reader.Read())
            {
                list.Add(TranslateAsSearch(reader, true));
            }
            return list;
        }

        

    }
}
