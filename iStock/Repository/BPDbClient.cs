using iStock.Model;
using iStock.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iStock.Translators;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace iStock.Repository
{
    public class BPDbClient
    {
        public List<BusinessPartner> GetBPList(string connString)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<BusinessPartner>>(connString,
                "procBPList", r => r.TranslateAsBPList());
        }
        public List<Search> searchBP(string connString, string name)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
           new SqlParameter("@Name", name)
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<Search>>(connString,
                "getBPFromName", r => r.TranslateAsBPSearch(), sqlParams);
        }
        public BusinessPartner GetBPDetails(string connString, int Id)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
          {
           new SqlParameter("@Id", Id)
          };

            return SqlHelper.ExtecuteProcedureReturnData<BusinessPartner>(connString,
                "procBusinessPartner", r => r.TranslateAsBP(), sqlParams);
        }

        public string UpdateBP(BusinessPartner model, string connString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                new SqlParameter("@Id",model.Personid),
                new SqlParameter("@LastName",model.LastName),
                new SqlParameter("@FirstName",model.FirstName),
                new SqlParameter("@ForeignName",model.ForeignName),
                new SqlParameter("@DateOfBirth",model.DateOfBirth),
                new SqlParameter("@Gneder",model.Gneder),
                new SqlParameter("@Email",model.Email),
                new SqlParameter("@Website",model.Website),
                new SqlParameter("@HomePhone",model.HomePhone),
                new SqlParameter("@OfficePhone",model.OfficePhone),
                new SqlParameter("@Mobile",model.Mobile),
                new SqlParameter("@Fax",model.Fax),
                new SqlParameter("@Currency",model.Currency),
                new SqlParameter("@Address1",model.Address1),
                new SqlParameter("@Address2",model.Address2),
                new SqlParameter("@City",model.City),
                new SqlParameter("@State",model.State),
                new SqlParameter("@Zip",model.Zip),
                new SqlParameter("@Country",model.Country),
                new SqlParameter("@IsActive",model.IsActive)
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "procUpdateBP", param);
            return (string)outParam.Value;
        }

        //public string DeleteBP(int id, string connString)
        //{
        //    var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
        //    {
        //        Direction = ParameterDirection.Output
        //    };
        //    SqlParameter[] param = {
        //        new SqlParameter("@Id",id),
        //        outParam
        //    };
        //    SqlHelper.ExecuteProcedureReturnString(connString, "DeleteUser", param);
        //    return (string)outParam.Value;
        //}
    }
}
