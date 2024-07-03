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
    public class RelieveAuditDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();

        public RelieveAuditDAL()
        {
        }
        public DataTable AuditorRelieveLoad(RelieveAuditBO RelieveAudit)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AuditorRelieveLoad", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_StaffNo", OracleType.VarChar).Value = RelieveAudit.StaffNo;
            dAd.SelectCommand.Parameters.Add("v_ReqID", OracleType.Int32).Value = RelieveAudit.ReqId;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.VarChar).Value = RelieveAudit.Action;
            dAd.SelectCommand.Parameters.Add("v_AuditId", OracleType.Int32).Value = RelieveAudit.AuditID;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AAS_REQ_COLLECTIONTable");
                return dSet.Tables["AAS_REQ_COLLECTIONTable"];
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

        public Byte AuditorRelieveUpdate(RelieveAuditBO RelieveAudit)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dAd = new OracleCommand("AuditorRelieveUpdate", conn);
            dAd.CommandType = CommandType.StoredProcedure;
            dAd.Parameters.Add("v_StaffNo", OracleType.VarChar).Value = RelieveAudit.StaffNo;
            dAd.Parameters.Add("v_ReqID", OracleType.Int32).Value = RelieveAudit.ReqId;
            dAd.Parameters.Add("v_RelieveDt", OracleType.VarChar).Value = RelieveAudit.ReqDate;
            dAd.Parameters.Add("v_UpDtBy", OracleType.VarChar).Value = RelieveAudit.UpdtdBy;
            dAd.Parameters.Add("v_UpDt", OracleType.VarChar).Value = RelieveAudit.UpdtdDt;
            dAd.Parameters.Add("v_Action", OracleType.Char).Value = RelieveAudit.Action;
            dAd.Parameters.Add("v_AuditID", OracleType.Int32).Value = RelieveAudit.AuditID;
            dAd.Parameters.Add("v_Result", OracleType.Byte).Direction = ParameterDirection.Output;
            try
            {
                dAd.ExecuteNonQuery();
                return Convert.ToByte(dAd.Parameters["v_Result"].Value);
            }
            catch
            {
                throw;
            }
            finally
            {
                dAd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
