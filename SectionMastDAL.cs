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
    public class SectionMastDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
        public DataTable FetchSectionMastLoad(SectionMastBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("SECTIONMASTLOAD", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_MainCode", OracleType.VarChar).Value = objbo.MainCode;
            dAd.SelectCommand.Parameters.Add("v_Seccode", OracleType.VarChar).Value = objbo.SecCode;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AAS_SECTION_MAST");
                return dSet.Tables["AAS_SECTION_MAST"];
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

        public Byte UpdateSectionMast(SectionMastBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("SECTIONMASTUPDATE", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("v_MainCode", OracleType.VarChar).Value = objbo.MainCode;
            dCmd.Parameters.Add("v_SecCode", OracleType.VarChar).Value = objbo.SecCode;
            dCmd.Parameters.Add("v_SecName", OracleType.VarChar).Value = objbo.SecName;
            dCmd.Parameters.Add("v_Status", OracleType.VarChar).Value = objbo.Status;
            dCmd.Parameters.Add("v_UpdtStat", OracleType.VarChar).Value = objbo.UpdtStat;
            dCmd.Parameters.Add("v_UpdtBy", OracleType.VarChar).Value = objbo.UpdtBy;
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
