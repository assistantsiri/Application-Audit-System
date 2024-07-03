using BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace DA
{
   public class WingMastDAL
    {

        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
        public DataTable FetchWingMastLoad(WingMastBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("WINGMASTLOAD", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_MainCode", OracleType.VarChar).Value = objbo.MainCode;
            dAd.SelectCommand.Parameters.Add("v_SubCode", OracleType.VarChar).Value = objbo.WingCode;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AAS_GEN_MASTER");
                return dSet.Tables["AAS_GEN_MASTER"];
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

        public Byte UpdateWingMast(WingMastBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("WINGMASTUPDATE", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("v_MainCode", OracleType.Number).Value = objbo.MainCode;
            dCmd.Parameters.Add("v_Subcode", OracleType.VarChar).Value = objbo.WingCode;
            dCmd.Parameters.Add("v_Des", OracleType.VarChar).Value = objbo.WingName;
            dCmd.Parameters.Add("v_Action", OracleType.VarChar).Value = objbo.Action;
            dCmd.Parameters.Add("v_Result", OracleType.Byte).Direction = ParameterDirection.Output;
            try
            {
                dCmd.ExecuteNonQuery();
                return Convert.ToByte(dCmd.Parameters["v_Result"].Value);
            }
            catch
            {
                throw;
            }
            finally
            {
                dCmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
