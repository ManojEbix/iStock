using iStock.Model;
using iStock.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using iStock.Translators;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace iStock.Repository
{
    public class StockDbClient
    {
        public List<Dictionary<string, object>> GetStocks(string connString)
        {
            return SqlHelper.ExtecuteProcedureReturnJson<List<Dictionary<string, object>>>(connString,
                "GetSeries", r => r.SerializeT());
        }
    }
}
