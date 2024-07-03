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
    public class AuditChecklistOthsDA
    {
        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();

        public DataTable FetchCheckListOths(AuditChecklistOthsBO AuditChecklistOths)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_AuditCheckListOthsLoad", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_AuditID", OracleType.Char).Value = AuditChecklistOths.AuditID;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = AuditChecklistOths.Action;
            dAd.SelectCommand.Parameters.Add("V_GRPCODE", OracleType.Int32).Value = AuditChecklistOths.GroupCode;
            dAd.SelectCommand.Parameters.Add("V_ITEMCODE", OracleType.Int32).Value = AuditChecklistOths.ItemCode;
            dAd.SelectCommand.Parameters.Add("V_UserID", OracleType.VarChar).Value = AuditChecklistOths.UserID;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AAS_CHECKLIST_OTHERS");
                return dSet.Tables["AAS_CHECKLIST_OTHERS"];
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

        public Byte UpdtCheckListOths(AuditChecklistOthsBO AuditChecklistOths)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_AuditCheckListOthsUpdate", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_AUDITID", OracleType.Int32).Value = AuditChecklistOths.AuditID;
            dAd.SelectCommand.Parameters.Add("V_GRPCODE", OracleType.Int32).Value = AuditChecklistOths.GroupCode;
            dAd.SelectCommand.Parameters.Add("V_ITEMCODE", OracleType.Int32).Value = AuditChecklistOths.ItemCode;
            dAd.SelectCommand.Parameters.Add("V_QUERY", OracleType.VarChar).Value = AuditChecklistOths.Query;
            dAd.SelectCommand.Parameters.Add("V_APPLICABLE", OracleType.VarChar).Value = AuditChecklistOths.Applicable;
            dAd.SelectCommand.Parameters.Add("V_YNANS", OracleType.VarChar).Value = AuditChecklistOths.YNAns;
            dAd.SelectCommand.Parameters.Add("V_GRADE", OracleType.VarChar).Value = AuditChecklistOths.GradeOption;
            dAd.SelectCommand.Parameters.Add("V_STATUS", OracleType.VarChar).Value = AuditChecklistOths.ChecklistStatus;
            dAd.SelectCommand.Parameters.Add("V_OBERVE", OracleType.VarChar).Value = AuditChecklistOths.Observation;
            dAd.SelectCommand.Parameters.Add("V_UPDT_BY", OracleType.VarChar).Value = AuditChecklistOths.UpdtBy;
            dAd.SelectCommand.Parameters.Add("V_UPDT_DT", OracleType.VarChar).Value = AuditChecklistOths.UpdtDt;
            dAd.SelectCommand.Parameters.Add("V_REPLY", OracleType.VarChar).Value = AuditChecklistOths.Reply;
            dAd.SelectCommand.Parameters.Add("V_ACCEPTDENY", OracleType.VarChar).Value = AuditChecklistOths.AcceptDeny;
            dAd.SelectCommand.Parameters.Add("V_REMARKS", OracleType.VarChar).Value = AuditChecklistOths.Remarks;
            dAd.SelectCommand.Parameters.Add("V_REPLYSTATUS", OracleType.VarChar).Value = AuditChecklistOths.ReplyStatus;
            dAd.SelectCommand.Parameters.Add("V_REPLYUPDTBY", OracleType.VarChar).Value = AuditChecklistOths.ReplyUpdtBy;
            dAd.SelectCommand.Parameters.Add("V_REPLYUPDTDT", OracleType.VarChar).Value = AuditChecklistOths.ReplyUpdtDt;
            dAd.SelectCommand.Parameters.Add("V_DEPT", OracleType.Int32).Value = AuditChecklistOths.Dept;
            dAd.SelectCommand.Parameters.Add("V_ACTION", OracleType.Char).Value = AuditChecklistOths.Action;
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

        public DataTable RptChecklistOthers(AuditChecklistOthsBO AuditChecklistOths)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("RPT_CHECKLISTOTHERS", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_AUDITID", OracleType.Char).Value = AuditChecklistOths.AuditID;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AAS_CHECKLIST_OTHERS");
                return dSet.Tables["AAS_CHECKLIST_OTHERS"];
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
