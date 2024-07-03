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
    public class AuditCheckListDtlsDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();    

        public DataTable FetchCheckListMast(AuditCheckListDtlsBO AuditCheckListDtls)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_AuditCheckListLoad", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_AuditID", OracleType.Int32).Value = AuditCheckListDtls.AuditID;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = AuditCheckListDtls.Action;
            dAd.SelectCommand.Parameters.Add("V_GRPCODE", OracleType.Int32).Value = AuditCheckListDtls.GroupCode;
            dAd.SelectCommand.Parameters.Add("V_ITEMCODE", OracleType.Int32).Value = AuditCheckListDtls.ItemCode;
            dAd.SelectCommand.Parameters.Add("V_UserID", OracleType.VarChar).Value = AuditCheckListDtls.UserID;
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
    
        public Byte UpdtCheckListDtls(AuditCheckListDtlsBO AuditCheckListDtls)
        {    
            OracleConnection conn = new OracleConnection(connStr);    
            conn.Open();    
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_AuditCheckListUpdate", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_AUDITID", OracleType.Int32).Value = AuditCheckListDtls.AuditID;
            dAd.SelectCommand.Parameters.Add("V_GRPCODE", OracleType.Int32).Value = AuditCheckListDtls.GroupCode;
            dAd.SelectCommand.Parameters.Add("V_ITEMCODE", OracleType.Int32).Value = AuditCheckListDtls.ItemCode;
            dAd.SelectCommand.Parameters.Add("V_APPLICABLE", OracleType.VarChar).Value = AuditCheckListDtls.Applicable;
            dAd.SelectCommand.Parameters.Add("V_YNANS", OracleType.VarChar).Value = AuditCheckListDtls.YNAns;
            dAd.SelectCommand.Parameters.Add("V_GRADE", OracleType.VarChar).Value = AuditCheckListDtls.GradeOption;
            dAd.SelectCommand.Parameters.Add("V_STATUS", OracleType.VarChar).Value = AuditCheckListDtls.ChecklistStatus;
            dAd.SelectCommand.Parameters.Add("V_OBERVE", OracleType.VarChar).Value = AuditCheckListDtls.Observation;
            dAd.SelectCommand.Parameters.Add("V_UPDT_BY", OracleType.VarChar).Value = AuditCheckListDtls.UpdtBy;
            dAd.SelectCommand.Parameters.Add("V_UPDT_DT", OracleType.VarChar).Value = AuditCheckListDtls.UpdtDt;
            dAd.SelectCommand.Parameters.Add("V_REPLY", OracleType.VarChar).Value = AuditCheckListDtls.Reply;
            dAd.SelectCommand.Parameters.Add("V_ACCEPTDENY", OracleType.VarChar).Value = AuditCheckListDtls.AcceptDeny;
            dAd.SelectCommand.Parameters.Add("V_REMARKS", OracleType.VarChar).Value = AuditCheckListDtls.Remarks;
            dAd.SelectCommand.Parameters.Add("V_REPLYSTATUS", OracleType.VarChar).Value = AuditCheckListDtls.ReplyStatus;
            dAd.SelectCommand.Parameters.Add("V_REPLYUPDTBY", OracleType.VarChar).Value = AuditCheckListDtls.ReplyUpdtBy;
            dAd.SelectCommand.Parameters.Add("V_REPLYUPDTDT", OracleType.VarChar).Value = AuditCheckListDtls.ReplyUpdtDt;
            dAd.SelectCommand.Parameters.Add("V_DEPT", OracleType.Int32).Value = AuditCheckListDtls.Dept;
            dAd.SelectCommand.Parameters.Add("V_ACTION", OracleType.Char).Value = AuditCheckListDtls.Action;
            dAd.SelectCommand.Parameters.Add("V_OBS_STATUS", OracleType.Number).Value = AuditCheckListDtls.ObsStatus;
            dAd.SelectCommand.Parameters.Add("V_RESULT", OracleType.Byte).Direction = ParameterDirection.Output;
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

        //CHECKLIST NEW AS PER NEW REQUIREMENT//
        public DataTable FetchCheckListDtls(AuditCheckListDtlsBO AuditCheckListDtls)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_AuditCheckListLoad_New", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_AuditID", OracleType.Int32).Value = AuditCheckListDtls.AuditID;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = AuditCheckListDtls.Action;
            dAd.SelectCommand.Parameters.Add("V_GRPCODE", OracleType.Int32).Value = AuditCheckListDtls.GroupCode;
            dAd.SelectCommand.Parameters.Add("V_ITEMCODE", OracleType.Int32).Value = AuditCheckListDtls.ItemCode;
            dAd.SelectCommand.Parameters.Add("V_UserID", OracleType.VarChar).Value = AuditCheckListDtls.UserID;
            dAd.SelectCommand.Parameters.Add("V_Section", OracleType.Int32).Value = AuditCheckListDtls.SectionID;
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

        public String UpdtCheckListDtls_New(AuditCheckListDtlsBO AuditCheckListDtls)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("AAS_AuditCheckListUpdate_New", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("V_AUDITID", OracleType.Int32).Value = AuditCheckListDtls.AuditID;
            dCmd.Parameters.Add("V_GRPCODE", OracleType.Int32).Value = AuditCheckListDtls.GroupCode;
            dCmd.Parameters.Add("V_ITEMCODE", OracleType.Int32).Value = AuditCheckListDtls.ItemCode;
            dCmd.Parameters.Add("V_APPLICABLE", OracleType.VarChar).Value = AuditCheckListDtls.Applicable;
            dCmd.Parameters.Add("V_YNANS", OracleType.VarChar).Value = AuditCheckListDtls.YNAns;
            dCmd.Parameters.Add("V_GRADE", OracleType.VarChar).Value = AuditCheckListDtls.GradeOption;
            dCmd.Parameters.Add("V_STATUS", OracleType.VarChar).Value = AuditCheckListDtls.ChecklistStatus;
            dCmd.Parameters.Add("V_OBERVE", OracleType.VarChar).Value = AuditCheckListDtls.Observation;
            dCmd.Parameters.Add("V_UPDT_BY", OracleType.VarChar).Value = AuditCheckListDtls.UpdtBy;
            dCmd.Parameters.Add("V_UPDT_DT", OracleType.VarChar).Value = AuditCheckListDtls.UpdtDt;
            dCmd.Parameters.Add("V_REPLY", OracleType.VarChar).Value = AuditCheckListDtls.Reply;
            dCmd.Parameters.Add("V_ACCEPTDENY", OracleType.VarChar).Value = AuditCheckListDtls.AcceptDeny;
            dCmd.Parameters.Add("V_REMARKS", OracleType.VarChar).Value = AuditCheckListDtls.Remarks;
            dCmd.Parameters.Add("V_REPLYSTATUS", OracleType.VarChar).Value = AuditCheckListDtls.ReplyStatus;
            dCmd.Parameters.Add("V_REPLYUPDTBY", OracleType.VarChar).Value = AuditCheckListDtls.ReplyUpdtBy;
            dCmd.Parameters.Add("V_REPLYUPDTDT", OracleType.VarChar).Value = AuditCheckListDtls.ReplyUpdtDt;
            dCmd.Parameters.Add("V_DEPT", OracleType.Int32).Value = AuditCheckListDtls.Dept;
            dCmd.Parameters.Add("V_ACTION", OracleType.Char).Value = AuditCheckListDtls.Action;
            dCmd.Parameters.Add("V_OBS_STATUS", OracleType.Number).Value = AuditCheckListDtls.ObsStatus;
            dCmd.Parameters.Add("V_RESULT", OracleType.VarChar, 500).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dCmd.ExecuteNonQuery();
                return Convert.ToString(dCmd.Parameters["V_RESULT"].Value);
            }
            catch
            {
                throw;
            }
            finally
            {
                dCmd.Dispose();
                dSet.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
