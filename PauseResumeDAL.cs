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
   public class PauseResumeDAL
    {
       string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
       public Byte SaveUpdateAuditStatus(PauseResumeBO objbo)
       {
           OracleConnection conn = new OracleConnection(connStr);
           conn.Open();
           OracleCommand dCmd = new OracleCommand("AAS_AUDITSTAGE_UPDATE", conn);
           dCmd.CommandType = CommandType.StoredProcedure;
           dCmd.Parameters.Add("V_ARC_REQ_COLLECTID", OracleType.Int32).Value = objbo.CollectID;
            dCmd.Parameters.Add("V_ARC_AASAUDIT_ID", OracleType.Int32).Value = objbo.AuditID;
            dCmd.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
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
       public DataTable FetchApplicationName(PauseResumeBO objBO)
       {
           OracleConnection con = new OracleConnection(connStr);
           con.Open();
           OracleCommand cmd = new OracleCommand("SELECT ARC_APPLICATION_NAME,ARC_REQ_COLLECTID FROM AAS_REQ_COLLECTION Where ARC_AASAUDIT_ID = " + objBO.AuditID + " ", con);
           cmd.CommandType = CommandType.Text;
           OracleDataAdapter da = new OracleDataAdapter(cmd);
           DataSet ds = new DataSet();
           try
           {
               da.Fill(ds, "AAS_REQ_COLLECTION");
               return ds.Tables["AAS_REQ_COLLECTION"];
           }
           catch
           {
               throw;
           }
           finally
           {
               ds.Dispose();
               da.Dispose();
               cmd.Dispose();
               con.Close();
               con.Dispose();
           }
       }

       public DataTable FetchApplicationAudit(PauseResumeBO objBO)
       {
           OracleConnection con = new OracleConnection(connStr);
           con.Open();
           OracleCommand cmd = new OracleCommand("SELECT APA_AASAUDITID, APA_REQ_COLLECTID,TO_CHAR(APA_REVIEW_FROM, 'DD-MM-YYYY') AS APA_REVIEW_FROM,TO_CHAR(APA_REVIEW_TO, 'DD-MM-YYYY') AS APA_REVIEW_TO,TO_CHAR(APA_FROM_DATE, 'DD-MM-YYYY') AS APA_FROM_DATE,TO_CHAR(APA_TO_DATE, 'DD-MM-YYYY') AS APA_TO_DATE ,APA_MANDAYS,APA_AUDIT_STAGE,APA_STATUS,APA_GRADATION,APA_UPDT_STAT,APA_UPDT_BY,APA_UPDT_DT FROM AAS_PLAN_AUDIT WHERE APA_REQ_COLLECTID = " + objBO.CollectID + "", con);
           cmd.CommandType = CommandType.Text;
           OracleDataAdapter da = new OracleDataAdapter(cmd);
           DataSet ds = new DataSet();
           try
           {
               da.Fill(ds, "AAS_PLAN_AUDIT");
               return ds.Tables["AAS_PLAN_AUDIT"];
           }
           catch
           {
               throw;
           }
           finally
           {
               ds.Dispose();
               da.Dispose();
               cmd.Dispose();
               con.Close();
               con.Dispose();
           }
       }
       public DataTable FetchPalnAudit(PauseResumeBO objBO)
       {
           OracleConnection con = new OracleConnection(connStr);
           con.Open();
           OracleCommand cmd = new OracleCommand("select APA_AUDIT_STAGE   from aas_plan_audit where APA_AASAUDITID= " + objBO.AuditID , con);
           cmd.CommandType = CommandType.Text;
           OracleDataAdapter da = new OracleDataAdapter(cmd);
           DataSet ds = new DataSet();
           try
           {
               da.Fill(ds, "AAS_PLAN_AUDIT");
               return ds.Tables["AAS_PLAN_AUDIT"];
           }
           catch
           {
               throw;
           }
           finally
           {
               ds.Dispose();
               da.Dispose();
               cmd.Dispose();
               con.Close();
               con.Dispose();
           }
       }

    }
}
