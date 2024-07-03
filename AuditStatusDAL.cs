using System;
using System.Collections.Generic;
using System.Linq;
using BO;
using DA;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;

using System.Text;

namespace DA
{
   public class AuditStatusDAL
    {
       string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
       public AuditStatusDAL()
       {

       }

       //added by Nagarathna
       public DataTable FetchRequirementData(AuditStatusBO objbo)
       {
           OracleConnection conn = new OracleConnection(connStr);
           conn.Open();
           OracleDataAdapter dAd = new OracleDataAdapter("AUDITSTATUSWING", conn);
           dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
           dAd.SelectCommand.Parameters.Add("V_AuditID", OracleType.Int32).Value = objbo.AuditId;
           dAd.SelectCommand.Parameters.Add("v_deptId", OracleType.Int16).Value = objbo.deptid;
           dAd.SelectCommand.Parameters.Add("V_ROLEID", OracleType.Int16).Value = objbo.roleid;
           dAd.SelectCommand.Parameters.Add("V_AUDITSTATUS", OracleType.VarChar).Value = objbo.AuditStatus;
           dAd.SelectCommand.Parameters.Add("V_STAFFNO", OracleType.VarChar).Value = objbo.UpdtdBy;
           dAd.SelectCommand.Parameters.Add("V_Action", OracleType.Char).Value = objbo.Action;
           dAd.SelectCommand.Parameters.Add("V_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
           DataSet dSet = new DataSet();
           try
           {
               dAd.Fill(dSet, "AAS_REQ_COLLECTION");
               return dSet.Tables["AAS_REQ_COLLECTION"];
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

       public DataTable FetchAuditCheckListStatus(AuditStatusBO objbo)
       {
           OracleConnection conn = new OracleConnection(connStr);
           conn.Open();
           OracleDataAdapter dAd = new OracleDataAdapter("AAS_AUDITCHKLIST_STATUS", conn);
           dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
           dAd.SelectCommand.Parameters.Add("V_AuditID", OracleType.Int32).Value = objbo.AuditId;
           dAd.SelectCommand.Parameters.Add("V_GROUPCODE", OracleType.Int32).Value = objbo.GroupCode;
           dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
           dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
           DataSet dSet = new DataSet();
           try
           {
               dAd.Fill(dSet, "AAS_CHECKLIST_MAST");
               return dSet.Tables["AAS_CHECKLIST_MAST"];
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

       public DataTable FetchCheckListData(AuditStatusBO objbo)
       {
           OracleConnection conn = new OracleConnection(connStr);
           conn.Open();
           OracleDataAdapter dAd = new OracleDataAdapter("AAS_CHECKLISTSTATUSWING_DTLS", conn);
           dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
           dAd.SelectCommand.Parameters.Add("V_AuditID", OracleType.Int32).Value = objbo.AuditId;
           dAd.SelectCommand.Parameters.Add("V_GROUPCODE", OracleType.Int32).Value = objbo.GroupCode;
           dAd.SelectCommand.Parameters.Add("V_STATUS", OracleType.Char).Value = objbo.Status;
           dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
           dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
           DataSet dSet = new DataSet();
           try
           {
               dAd.Fill(dSet, "AAS_CHECKLIST_MAST");
               return dSet.Tables["AAS_CHECKLIST_MAST"];
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


        public DataSet postFetchRequirementData(String Action, int Audit_ID,int deptid,int roleid, string AuditStatus, string UpdtdBy)
        {
            DataSet FinalDataSet = new DataSet();
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AUDITSTATUSWING", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_AuditID", OracleType.Int32).Value = Audit_ID;
            dAd.SelectCommand.Parameters.Add("v_deptId", OracleType.Int16).Value = deptid;
            dAd.SelectCommand.Parameters.Add("V_ROLEID", OracleType.Int16).Value = roleid;
            dAd.SelectCommand.Parameters.Add("V_AUDITSTATUS", OracleType.VarChar).Value = AuditStatus;
            dAd.SelectCommand.Parameters.Add("V_STAFFNO", OracleType.VarChar).Value = UpdtdBy;
            dAd.SelectCommand.Parameters.Add("V_Action", OracleType.Char).Value = Action;
            dAd.SelectCommand.Parameters.Add("V_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            //DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(FinalDataSet, "ACCOUNT_MAST");
                return FinalDataSet;
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
