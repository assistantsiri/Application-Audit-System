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
  public  class AuditCheckListDtlsDAL_Post
    {
        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
        public DataTable FetchCheckListMast_Post(AuditCheckListDtlsBO_Post BO)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_AuditCheckListLoad_Post", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_AuditID", OracleType.Int32).Value = BO.AuditID;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = BO.Action;
            dAd.SelectCommand.Parameters.Add("V_GRPCODE", OracleType.Int32).Value = BO.GroupCode;
            dAd.SelectCommand.Parameters.Add("V_ITEMCODE", OracleType.Int32).Value = BO.ItemCode;
            dAd.SelectCommand.Parameters.Add("V_UserID", OracleType.VarChar).Value = BO.UserID;
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

        public Byte UpdtCheckListDtls_Post(AuditCheckListDtlsBO_Post BO)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_AuditCheckListUpdate_Post", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_AUDITID", OracleType.Int32).Value = BO.AuditID;
            dAd.SelectCommand.Parameters.Add("V_GRPCODE", OracleType.Int32).Value = BO.GroupCode;
            dAd.SelectCommand.Parameters.Add("V_ITEMCODE", OracleType.Int32).Value = BO.ItemCode;
            dAd.SelectCommand.Parameters.Add("V_APPLICABLE", OracleType.VarChar).Value = BO.Applicable;
            dAd.SelectCommand.Parameters.Add("V_YNANS", OracleType.VarChar).Value = BO.YNAns;
            dAd.SelectCommand.Parameters.Add("V_GRADE", OracleType.VarChar).Value = BO.GradeOption;
            dAd.SelectCommand.Parameters.Add("V_STATUS", OracleType.VarChar).Value = BO.ChecklistStatus;
            dAd.SelectCommand.Parameters.Add("V_OBERVE", OracleType.VarChar).Value = BO.Observation;
            dAd.SelectCommand.Parameters.Add("V_UPDT_BY", OracleType.VarChar).Value = BO.UpdtBy;
            dAd.SelectCommand.Parameters.Add("V_UPDT_DT", OracleType.VarChar).Value = BO.UpdtDt;
            dAd.SelectCommand.Parameters.Add("V_REPLY", OracleType.VarChar).Value = BO.Reply;
            dAd.SelectCommand.Parameters.Add("V_ACCEPTDENY", OracleType.VarChar).Value = BO.AcceptDeny;
            dAd.SelectCommand.Parameters.Add("V_REMARKS", OracleType.VarChar).Value = BO.Remarks;
            dAd.SelectCommand.Parameters.Add("V_REPLYSTATUS", OracleType.VarChar).Value = BO.ReplyStatus;
            dAd.SelectCommand.Parameters.Add("V_REPLYUPDTBY", OracleType.VarChar).Value = BO.ReplyUpdtBy;
            dAd.SelectCommand.Parameters.Add("V_REPLYUPDTDT", OracleType.VarChar).Value = BO.ReplyUpdtDt;
            dAd.SelectCommand.Parameters.Add("V_DEPT", OracleType.Int32).Value = BO.Dept;    //
            dAd.SelectCommand.Parameters.Add("V_ACTION", OracleType.Char).Value = BO.Action;
            dAd.SelectCommand.Parameters.Add("V_OBS_STATUS", OracleType.Number).Value = BO.ObsStatus;
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

        public DataTable FetchReplyStatus(AuditCheckListDtlsBO_Post objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("select ACD_POST_REPLY_STATUS_C from AAS_CHECKLIST_DTLS_POST t where acd_aasauditid ="+ objBO.AuditID + "  and acd_itemcode = " + objBO.ItemCode + "", con);
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
        //CHECKLIST NEW AS PER NEW REQUIREMENT FOR POST//
        public DataTable FetchCheckListDtls_POST(AuditCheckListDtlsBO_Post BO)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_AUDITCHkLOAD_Post_TEST", conn);  // AAS_AUDITCHkLOAD_NEW_Post
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_AUDITID", OracleType.Int32).Value = BO.AuditID;
            dAd.SelectCommand.Parameters.Add("V_ACTION", OracleType.Char).Value = BO.Action;
            dAd.SelectCommand.Parameters.Add("V_GRPCODE", OracleType.Int32).Value = BO.GroupCode;
            dAd.SelectCommand.Parameters.Add("V_ITEMCODE", OracleType.Int32).Value = BO.ItemCode;
            dAd.SelectCommand.Parameters.Add("V_USERID", OracleType.VarChar).Value = BO.UpdtBy;
            dAd.SelectCommand.Parameters.Add("V_SECTION", OracleType.Int32).Value = BO.SectionID;
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
        public String UpdtCheckListDtls_New_Post(AuditCheckListDtlsBO_Post BO)
          {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("AAS_AuditChktUpdate_New_Post", conn);
            dCmd.CommandType = CommandType.StoredProcedure; 
            dCmd.Parameters.Add("V_AUDITID", OracleType.Int32).Value = BO.AuditID;   //
            dCmd.Parameters.Add("V_GRPCODE", OracleType.Int32).Value = BO.GroupCode;  //
            dCmd.Parameters.Add("V_ITEMCODE", OracleType.Int32).Value = BO.ItemCode;   //
            dCmd.Parameters.Add("V_APPLICABLE", OracleType.VarChar).Value = BO.Applicable;  //
            dCmd.Parameters.Add("V_YNANS", OracleType.VarChar).Value = BO.YNAns;    //
            dCmd.Parameters.Add("V_GRADE", OracleType.VarChar).Value = BO.GradeOption;   //
            dCmd.Parameters.Add("V_STATUS", OracleType.VarChar).Value = BO.ChecklistStatus;   //
            dCmd.Parameters.Add("V_OBERVE", OracleType.VarChar).Value = BO.Observation;    //
            dCmd.Parameters.Add("V_UPDT_BY", OracleType.VarChar).Value = BO.UpdtBy;  //
            dCmd.Parameters.Add("V_UPDT_DT", OracleType.VarChar).Value = BO.UpdtDt;  //
            dCmd.Parameters.Add("V_REPLY", OracleType.VarChar).Value = BO.Reply;    //
            dCmd.Parameters.Add("V_ACCEPTDENY", OracleType.VarChar).Value = BO.AcceptDeny;    //
            dCmd.Parameters.Add("V_REMARKS", OracleType.VarChar).Value = BO.Remarks;
            // dCmd.Parameters.Add("V_REPLYSTATUS", OracleType.VarChar).Value = BO.ReplyStatus;
            //dCmd.Parameters.Add("V_REPLYUPDTBY", OracleType.VarChar).Value = BO.ReplyUpdtBy;
            //dCmd.Parameters.Add("V_REPLYUPDTDT", OracleType.VarChar).Value = BO.ReplyUpdtDt;
            dCmd.Parameters.Add("V_DEPT", OracleType.Int32).Value = BO.Dept;     //   
            dCmd.Parameters.Add("V_ACTION", OracleType.Char).Value = BO.Action;   //
            dCmd.Parameters.Add("V_OBS_STATUS", OracleType.Number).Value = BO.ObsStatus;    //NOT THERE
            dCmd.Parameters.Add("V_ACD_POST_OBSERVATION", OracleType.VarChar).Value = BO.POSTOBSERVATION;   //
            dCmd.Parameters.Add("V_ACD_POST_OBSERVATION_BY", OracleType.VarChar).Value = BO.Post_Obs_Updt_By;   //v cs   //
            dCmd.Parameters.Add("V_ACD_POST_OBSER_UPDATE", OracleType.VarChar).Value = BO.ObsUpdtDt_Post;   // v database    //
            dCmd.Parameters.Add("V_ACD_Post_Applicable", OracleType.VarChar).Value = BO.ACD_Post_Applicable;        //
            dCmd.Parameters.Add("V_ACD_POST_OBS_REPLY", OracleType.VarChar).Value = BO.POSTOBSREPLY;   //
            dCmd.Parameters.Add("V_POST_REPLYSTATUS", OracleType.VarChar).Value = BO.Post_ReplyStatus;      //
            dCmd.Parameters.Add("V_ACD_POST_REPLY_UPDT_DT", OracleType.VarChar).Value = BO.ReplyUpdtDt_Post;  //v cs   //
            dCmd.Parameters.Add("V_ACD_POST_REPLY_UPDT_BY", OracleType.VarChar).Value = BO.ReplyUpdtBy_Post;   //
            dCmd.Parameters.Add("V_Post_GRADE", OracleType.VarChar).Value = BO.Post_GradeOption;   //
            dCmd.Parameters.Add("V_POST_ACCEPTDENY", OracleType.VarChar).Value = BO.Post_AcceptDeny;   //
            dCmd.Parameters.Add("V_POST_AD_REMARKS", OracleType.VarChar).Value = BO.POST_Remarks;      //
            dCmd.Parameters.Add("V_POST_Wing_ACCEPTDENY", OracleType.VarChar).Value = BO.Post_Wing_AcceptDeny;   //
            dCmd.Parameters.Add("V_POST_Wing_AD_REMARKS", OracleType.VarChar).Value = BO.POST_Wing_Remarks;    //
            dCmd.Parameters.Add("V_ACD_POST_REPLY_STATUS_UPDT_C", OracleType.VarChar).Value = BO.Post_Reply_Status_Updt_Dt;     //
            dCmd.Parameters.Add("V_ACD_POST_REPLY_STATUS_UPDTBY_C", OracleType.VarChar).Value = BO.Post_Reply_Status_Updt_By;  //
            dCmd.Parameters.Add("V_ACD_POST_WING_AD_UPDT_BY", OracleType.VarChar).Value = BO.Post_Wing_Updt_By;     //
            dCmd.Parameters.Add("V_ACD_POST_WING_AD_UPDT_DT", OracleType.VarChar).Value = BO.Post_Wing_Updt_DT;     //
            dCmd.Parameters.Add("V_ACD_POST_AD_UPDT_BY", OracleType.VarChar).Value = BO.Post_AD_Updt_By;     //
            dCmd.Parameters.Add("V_ACD_POST_AD_UPDT_DT", OracleType.VarChar).Value = BO.Post_AD_Update_Dt;     //
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
        public DataSet ChecklistData(AuditCheckListDtlsBO_Post BO)
        {
            OracleConnection con = new OracleConnection(connStr);
            DataSet ds = new DataSet();
            try
            {
                OracleCommand cmd = new OracleCommand("Post_Checklist_Excel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("V_AuditId", OracleType.Number).Value = BO.AuditID;
                cmd.Parameters.Add("V_Action", OracleType.VarChar).Value = BO.Action;
                cmd.Parameters.Add("Trgcur", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds;
        }
    }
}
