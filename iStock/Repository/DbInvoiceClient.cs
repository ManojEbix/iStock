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
    public class DbInvoiceClient
    {
        public List<Dictionary<string, object>> GetInvoice(string connString)
        {
            //SqlParameter[] sqlParams = new SqlParameter[]
            //{
            //    new SqlParameter("@Name", model.FromDate),
            //    new SqlParameter("@LastName",model.ToDate)
            //};
            return SqlHelper.ExtecuteProcedureReturnData<List<Dictionary<string, object>>>(connString,
                "getInvoice", r => r.SerializeT());
        }
    }
}
