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
    public class RiskPerceptionDtlsDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();

        public DataTable FetchAppDtls(RiskPerceptionDtlsBO RiskPerceptionDtls)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_RiskPerceptionLoad", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_Dept", OracleType.Int16).Value = RiskPerceptionDtls.Dept;
            dAd.SelectCommand.Parameters.Add("v_Role", OracleType.Int16).Value = RiskPerceptionDtls.Role;
            dAd.SelectCommand.Parameters.Add("v_AuditId", OracleType.Int32).Value = RiskPerceptionDtls.AuditID;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = RiskPerceptionDtls.Action;
            dAd.SelectCommand.Parameters.Add("v_UserID", OracleType.VarChar).Value = RiskPerceptionDtls.UserId;
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

        public Byte InsertMarksDetails(RiskPerceptionDtlsBO RiskPerceptionDtls)
        {
            OracleConnection conn = new OracleConnection(connStr);    
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_RiskPerceptionUpdate", conn);    
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_Dept", OracleType.Int16).Value = RiskPerceptionDtls.Dept;
            dAd.SelectCommand.Parameters.Add("v_AuditId", OracleType.Int32).Value = RiskPerceptionDtls.AuditID;
            dAd.SelectCommand.Parameters.Add("v_ReqId", OracleType.Int32).Value = RiskPerceptionDtls.ReqCollectID;
            dAd.SelectCommand.Parameters.Add("v_ParamCode", OracleType.Int16).Value = RiskPerceptionDtls.ParamCode;
            dAd.SelectCommand.Parameters.Add("v_SlNo", OracleType.Int16).Value = RiskPerceptionDtls.SlNo;
            dAd.SelectCommand.Parameters.Add("v_AuditeeMarks", OracleType.Double).Value = RiskPerceptionDtls.AuditeeMarks;
            dAd.SelectCommand.Parameters.Add("v_AuditorMarks", OracleType.Double).Value = RiskPerceptionDtls.AuditorMarks;
            dAd.SelectCommand.Parameters.Add("v_Status", OracleType.Char).Value = RiskPerceptionDtls.Status;
            dAd.SelectCommand.Parameters.Add("v_UpdtStatAuditee", OracleType.VarChar).Value = RiskPerceptionDtls.UpdtStatAuditee;
            dAd.SelectCommand.Parameters.Add("v_UpdtStatAuditor", OracleType.VarChar).Value = RiskPerceptionDtls.UpdtStatAuditor;
            dAd.SelectCommand.Parameters.Add("v_UpdtByAuditee", OracleType.VarChar).Value = RiskPerceptionDtls.UpdtByAuditee;
            dAd.SelectCommand.Parameters.Add("v_UpdtDtAuditee", OracleType.VarChar).Value = RiskPerceptionDtls.UpdtDtAuditee;
            dAd.SelectCommand.Parameters.Add("v_UpdtByAuditor", OracleType.VarChar).Value = RiskPerceptionDtls.UpdtByAuditor;
            dAd.SelectCommand.Parameters.Add("v_UpdtDtAuditor", OracleType.VarChar).Value = RiskPerceptionDtls.UpdtDtAuditor;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = RiskPerceptionDtls.Action;
            dAd.SelectCommand.Parameters.Add("v_Result", OracleType.Byte).Direction = ParameterDirection.Output;    
            DataSet dSet = new DataSet();    
            try
            {
                dAd.SelectCommand.ExecuteNonQuery();
                return Convert.ToByte(dAd.SelectCommand.Parameters["v_Result"].Value);    
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
