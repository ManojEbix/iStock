using iStock.Model;
using iStock.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iStock.Translators;
using System.Data.SqlClient;
using System.Data;

namespace iStock.Repository
{
    public class SeriesDbClient
    {
        public List<SeriesModel> GetAllSeries(string connString)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<SeriesModel>>(connString,
                "GetSeries", r => r.Serialize());
        }

        public string SaveUser(SeriesModel model, string connString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                new SqlParameter("@Id",model.Id),
                new SqlParameter("@Name",model.Name),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "SaveUser", param);
            return (string)outParam.Value;
        }

        public string DeleteUser(int id, string connString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                new SqlParameter("@Id",id),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "DeleteUser", param);
            return (string)outParam.Value;
        }
    }
}
