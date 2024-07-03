using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using BO;

namespace DA
{
    public class RiskPerceptionMastDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();

        public DataTable FetchAppDtls(RiskPerceptionMastBO RiskPerceptionMast)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_RiskPerceptionLoad", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = RiskPerceptionMast.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AAS_PLAN_AUDIT");
                return dSet.Tables["AAS_PLAN_AUDIT"];
            }
            catch
            {
                throw;
            }
            finally
            {
                dSet.Dispose();
                dAd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
