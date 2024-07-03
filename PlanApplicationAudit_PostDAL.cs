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
   public class PlanApplicationAudit_PostDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();



        public DataSet FetchCommenceAudit(PlanApplicationAuditBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("COMMENCEAUDITLOAD", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AAS_PLAN_AUDIT");
                return dSet;
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

        public DataSet FetchPlanApplicationAuditPOST(string collectionid, string Action,string AuditID)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("PLANAPPLICATIONAUDITLOAD_POST", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = Action;
            dAd.SelectCommand.Parameters.Add("v_COLLECTID", OracleType.Char).Value = collectionid;
            dAd.SelectCommand.Parameters.Add("v_AuditID", OracleType.Char).Value = AuditID;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AAS_PLAN_AUDIT");
                return dSet;
            }
            catch (Exception EX)
            {
                throw EX;
            }
            finally
            {
                dSet.Dispose();
                dAd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

        public DataSet FetchApplicationAuditPOST(string auditid,string reqid)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_AuditStatus_POST", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = "AUDITS";
            dAd.SelectCommand.Parameters.Add("V_AuditID", OracleType.Int32).Value = auditid;
            dAd.SelectCommand.Parameters.Add("V_CollectionID", OracleType.Int32).Value = reqid;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AAS_PLAN_AUDIT");
                return dSet;
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
            //OracleConnection con = new OracleConnection(connStr);
            //con.Open();
            //OracleCommand cmd = new OracleCommand("SELECT APA_AASAUDITID, APA_REQ_COLLECTID,TO_CHAR(APA_REVIEW_FROM, 'DD-MM-YYYY') AS APA_REVIEW_FROM,TO_CHAR(APA_REVIEW_TO, 'DD-MM-YYYY') AS APA_REVIEW_TO,TO_CHAR(APA_FROM_DATE, 'DD-MM-YYYY') AS APA_FROM_DATE,TO_CHAR(APA_TO_DATE, 'DD-MM-YYYY') AS APA_TO_DATE ,APA_MANDAYS,APA_AUDIT_STAGE,APA_STATUS,APA_GRADATION,APA_UPDT_STAT,APA_UPDT_BY,APA_UPDT_DT FROM AAS_PLAN_AUDIT_POST WHERE APA_REQ_COLLECTID = " + auditid + " AND APA_AASAUDITID IS NOT NULL AND APA_STATUS='A'", con);
            //cmd.CommandType = CommandType.Text;
            //OracleDataAdapter da = new OracleDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //try
            //{
            //    da.Fill(ds, "AAS_PLAN_AUDIT");
            //     return ds;
            //}
            //catch
            //{
            //    throw;
            //}
            //finally
            //{
            //    ds.Dispose();
            //    da.Dispose();
            //    cmd.Dispose();
            //    con.Close();
            //    con.Dispose();
            //}
        }

        public string UpdatePlanApplicationAuditPOST(string requid, string posfrmdt1, string Posttodt2, string PstMdays,string Status,string UpdtStat,string AuditStage,string Action,string UpdtBy,string Audit_ID)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("PLANAPPLICATIONAUDIUPDATE_POST", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
           
            dCmd.Parameters.Add("v_ReqCollectID", OracleType.Number).Value = requid;
            //dCmd.Parameters.Add("v_ReviewFrom", OracleType.VarChar).Value = objbo.ReviewFrom;
            //dCmd.Parameters.Add("v_ReviewTo", OracleType.VarChar).Value = objbo.ReviewTo;
            dCmd.Parameters.Add("v_FromDate", OracleType.VarChar).Value = posfrmdt1;
            dCmd.Parameters.Add("v_ToDate", OracleType.VarChar).Value = Posttodt2;
            dCmd.Parameters.Add("v_Mandays", OracleType.VarChar).Value = PstMdays;
            dCmd.Parameters.Add("v_AuditStage", OracleType.VarChar).Value = AuditStage;
            dCmd.Parameters.Add("v_Status", OracleType.VarChar).Value = Status;
            dCmd.Parameters.Add("v_Gradation", OracleType.VarChar).Value = "";
            dCmd.Parameters.Add("v_UpdtStat", OracleType.VarChar).Value = UpdtStat;
            dCmd.Parameters.Add("v_UpdtBy", OracleType.VarChar).Value = UpdtBy;
            dCmd.Parameters.Add("v_AuditID", OracleType.Number).Value = Audit_ID;
            dCmd.Parameters.Add("v_Action", OracleType.VarChar).Value = Action;
            dCmd.Parameters.Add("v_Result", OracleType.Number).Direction = ParameterDirection.Output;
            try
            {
                dCmd.ExecuteNonQuery();
                return Convert.ToString(dCmd.Parameters["v_Result"].Value);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                dCmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }


        public DataSet FetchRequirementId_Post(string collectionid, string Audit_ID)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();

            OracleCommand cmd = new OracleCommand("SELECT DISTINCT a.APA_AASAUDITID,B.ARC_REQ_COLLECTID,A.APA_REQ_COLLECTID || '-' || B.ARC_APPLICATION_NAME AS ARC_APPLICATION_NAME,B.ARC_DEVELOPER_SECTON,B.ARC_USER_SECTION FROM AAS_PLAN_AUDIT_POST A,AAS_REQ_COLLECTION B WHERE B.ARC_REQ_COLLECTID ='" + collectionid + "' AND APA_STATUS='A' and b.arc_aasaudit_id='" + Audit_ID + "'   and a.apa_req_collectid=b.arc_req_collectid and a.apa_aasauditid=b.arc_aasaudit_id ORDER BY apa_aasauditid", con);
            //OracleCommand cmd = new OracleCommand("select arc_req_collectid  from aas_req_collection where arc_updt_stat='A'", con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {

                da.Fill(ds);
                return ds;
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



        public DataSet FetchAuditID(string reuirementid)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT AAT_AASAUDITID FROM AAS_AUDIT_TEAM_POST WHERE AAT_REQCOLLECTID='" + reuirementid + "'  AND AAT_STATUS = 'A' AND AAT_UPDT_STAT='A'", con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "AAS_AUDIT_TEAM");
                return ds;
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

        

        public DataSet FetchFormATeamPost(FormAATeamBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AUDITTEAMLOAD", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_ReqID", OracleType.Number).Value = objbo.ReqCollectID;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet);
                return dSet;
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

        public DataTable FetchApplicationAudit(PlanApplicationAuditBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT APA_AASAUDITID, APA_REQ_COLLECTID,TO_CHAR(APA_REVIEW_FROM, 'DD-MM-YYYY') AS APA_REVIEW_FROM,TO_CHAR(APA_REVIEW_TO, 'DD-MM-YYYY') AS APA_REVIEW_TO,TO_CHAR(APA_FROM_DATE, 'DD-MM-YYYY') AS APA_FROM_DATE,TO_CHAR(APA_TO_DATE, 'DD-MM-YYYY') AS APA_TO_DATE ,APA_MANDAYS,APA_AUDIT_STAGE,APA_STATUS,APA_GRADATION,APA_UPDT_STAT,APA_UPDT_BY,APA_UPDT_DT FROM AAS_PLAN_AUDIT WHERE APA_REQ_COLLECTID = " + objBO.CollectID + " and APA_AASAUDITID is  null", con);
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
        public DataTable FetchApplicationAudit1(PlanApplicationAuditBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT APA_AASAUDITID, APA_REQ_COLLECTID,TO_CHAR(APA_REVIEW_FROM, 'DD-MM-YYYY') AS APA_REVIEW_FROM,TO_CHAR(APA_REVIEW_TO, 'DD-MM-YYYY') AS APA_REVIEW_TO,TO_CHAR(APA_FROM_DATE, 'DD-MM-YYYY') AS APA_FROM_DATE,TO_CHAR(APA_TO_DATE, 'DD-MM-YYYY') AS APA_TO_DATE ,APA_MANDAYS,APA_AUDIT_STAGE,APA_STATUS,APA_GRADATION,APA_UPDT_STAT,APA_UPDT_BY,APA_UPDT_DT FROM AAS_PLAN_AUDIT_POST WHERE APA_REQ_COLLECTID = " + objBO.CollectID + " and APA_AASAUDITID is not null", con);
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

        public DataTable FetchApplicationAuditVerify(PlanApplicationAuditBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT APA_AASAUDITID, APA_REQ_COLLECTID,TO_CHAR(APA_REVIEW_FROM, 'DD-MM-YYYY') AS APA_REVIEW_FROM,TO_CHAR(APA_REVIEW_TO, 'DD-MM-YYYY') AS APA_REVIEW_TO,TO_CHAR(APA_FROM_DATE, 'DD-MM-YYYY') AS APA_FROM_DATE,TO_CHAR(APA_TO_DATE, 'DD-MM-YYYY') AS APA_TO_DATE ,APA_MANDAYS,APA_AUDIT_STAGE,APA_STATUS,APA_GRADATION,APA_UPDT_STAT,APA_UPDT_BY,APA_UPDT_DT FROM AAS_PLAN_AUDIT WHERE APA_REQ_COLLECTID = " + objBO.CollectID + " and APA_UPDT_STAT='P'", con);
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

        public DataTable FetchAuditNo(PlanApplicationAuditBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT AAM_AUDITID from aas_auditid_mast", con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "aas_auditid_mast");
                return ds.Tables["aas_auditid_mast"];
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

        public DataTable FetchApplicationAuditPOST1(PlanApplicationAuditBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT APA_AASAUDITID, APA_REQ_COLLECTID,TO_CHAR(APA_REVIEW_FROM, 'DD-MM-YYYY') AS APA_REVIEW_FROM,TO_CHAR(APA_REVIEW_TO, 'DD-MM-YYYY') AS APA_REVIEW_TO,TO_CHAR(APA_FROM_DATE, 'DD-MM-YYYY') AS APA_FROM_DATE,TO_CHAR(APA_TO_DATE, 'DD-MM-YYYY') AS APA_TO_DATE ,APA_MANDAYS,APA_AUDIT_STAGE,APA_STATUS,APA_GRADATION,APA_UPDT_STAT,APA_UPDT_BY,APA_UPDT_DT FROM AAS_PLAN_AUDIT_POST WHERE APA_REQ_COLLECTID = " + objBO.CollectID + " AND APA_AASAUDITID IS NOT NULL AND APA_STATUS='A'", con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "AAS_PLAN_AUDIT");
                return ds.Tables["aas_auditid_mast"]; ;
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

        public DataSet FetchStaffNum(FormAATeamBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            //OracleCommand cmd = new OracleCommand("SELECT AUM_STAFF_NO,(AUM_STAFF_NO || '-' || AUM_STAFF_NAME) AS AUM_STAFF_NAME  FROM AAS_USER_MAST WHERE AUM_STATUS = 'A' AND AUM_DESIGNATION <> 1 AND AUM_ROLE <> 1 AND AUM_DEPT = 1 AND ( AUM_AUDIT_STAT <> 'I' OR AUM_AUDIT_STAT IS NULL) ORDER BY AUM_STAFF_NO", con);
            OracleCommand cmd = new OracleCommand("SELECT AUM_STAFF_NO,(AUM_STAFF_NO || '-' || AUM_STAFF_NAME) AS AUM_STAFF_NAME  FROM AAS_USER_MAST WHERE AUM_STATUS = 'A' AND AUM_DESIGNATION <> 1 AND AUM_ROLE <> 1 AND AUM_DEPT = 1 ORDER BY AUM_STAFF_NO", con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "AAS_USER_MAST");
                return ds;
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

        public DataSet FetchStaffDetails(string StaffNum)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT AUM_STAFF_NAME, (CASE AUM_DESIGNATION  WHEN '1' THEN 'GM'  WHEN '2' THEN  'DGM' WHEN '3' THEN 'AGM' WHEN '4' THEN 'DM' WHEN '5' THEN 'Senior Manager' WHEN '6' THEN 'MANAGER' WHEN '7' THEN 'OFFICER' ELSE 'OTHERS' END) AUM_DESIGNATION,AUM_EMAIL FROM AAS_USER_MAST Where AUM_STAFF_NO =  '" + StaffNum + "' ", con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "AAS_USER_MAST");
                return ds;
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

        public string UpdateFormATeam(string Auditid, string reuirementid, string StaffNum, string TeamLeadyn, string AllocatedDT, string UpdtBy, string EngageStatus, string Status, string UpdtStat, string Action)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("AAS_POST_AUDITTEAMUPDATE", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("v_AuditID", OracleType.Number).Value = Auditid;
            dCmd.Parameters.Add("v_ReqCollectID", OracleType.Number).Value = reuirementid;
            dCmd.Parameters.Add("v_StaffNo", OracleType.VarChar).Value = StaffNum;
            dCmd.Parameters.Add("v_StaffNoEdit", OracleType.Number).Value = 0;
            dCmd.Parameters.Add("v_TeamLeadYN", OracleType.VarChar).Value = TeamLeadyn;
            dCmd.Parameters.Add("v_EngageStatus", OracleType.VarChar).Value = EngageStatus;
            dCmd.Parameters.Add("v_AllocDate", OracleType.VarChar).Value = AllocatedDT;
           dCmd.Parameters.Add("v_RelieveDate", OracleType.VarChar).Value = "";
            dCmd.Parameters.Add("v_IrregTot", OracleType.Number).Value = 0;
            dCmd.Parameters.Add("v_IrregRectiTot", OracleType.Number).Value = 0;
            dCmd.Parameters.Add("v_Status", OracleType.VarChar).Value = Status;
            dCmd.Parameters.Add("v_UpdtStat", OracleType.VarChar).Value = UpdtStat;
            dCmd.Parameters.Add("v_UpdtBy", OracleType.VarChar).Value = UpdtBy;
            dCmd.Parameters.Add("v_Action", OracleType.VarChar).Value = Action;
            dCmd.Parameters.Add("v_Result", OracleType.Number).Direction = ParameterDirection.Output;
            try
            {
                dCmd.ExecuteNonQuery();
                return Convert.ToString(dCmd.Parameters["v_Result"].Value);
            }
            
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dCmd.Dispose();
                conn.Close();
                conn.Dispose();
            }

        }

        public DataSet PostAuditForteamEditBind(string collectionid, string Action , string staffnumber)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dCmd = new OracleDataAdapter("PostAuditTeamEditDataBind", conn);
            dCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dCmd.SelectCommand.Parameters.Add("v_AuditId", OracleType.Number).Value = 0;
            dCmd.SelectCommand.Parameters.Add("v_CollectionID", OracleType.Number).Value = collectionid;
            dCmd.SelectCommand.Parameters.Add("v_StaffNumber", OracleType.VarChar).Value = staffnumber;
            dCmd.SelectCommand.Parameters.Add("v_Action", OracleType.VarChar).Value = Action;
            dCmd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dCmd.Fill(dSet);
                return dSet;
            }

            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            finally
            {
                dSet.Dispose();
                //dAd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

        // Commencedata Save

        public string UpdateCommenceData(string CollectionID,string AuditID,string Action,string AuditStage,string UpdtBy,string Status)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("PLANAPPLICATIONAUDIUPDATE_POST", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("v_ReqCollectID", OracleType.Number).Value = CollectionID;
            dCmd.Parameters.Add("v_AuditID", OracleType.Number).Value = AuditID;
            dCmd.Parameters.Add("v_Action", OracleType.VarChar).Value = Action;
            dCmd.Parameters.Add("v_AuditStage", OracleType.VarChar).Value = AuditStage;
            dCmd.Parameters.Add("v_UpdtBy", OracleType.VarChar).Value = UpdtBy;
            dCmd.Parameters.Add("v_Status", OracleType.VarChar).Value = Status;
            dCmd.Parameters.Add("v_FromDate", OracleType.VarChar).Value = "";
            dCmd.Parameters.Add("v_ToDate", OracleType.VarChar).Value = "";
            dCmd.Parameters.Add("v_Mandays", OracleType.VarChar).Value = "";
            dCmd.Parameters.Add("v_Gradation", OracleType.VarChar).Value = "";
            dCmd.Parameters.Add("v_UpdtStat", OracleType.VarChar).Value = "";
            
           
            dCmd.Parameters.Add("v_Result", OracleType.Number).Direction = ParameterDirection.Output;
            try
            {
                dCmd.ExecuteNonQuery();
                return Convert.ToString(dCmd.Parameters["v_Result"].Value);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                dCmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
        public DataSet FetchAuditId(string Action, string AuditID)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("FetchAuditId", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = Action;
            dAd.SelectCommand.Parameters.Add("v_AuditID", OracleType.Char).Value = AuditID;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AAS_PLAN_AUDIT");
                return dSet;
            }
            catch (Exception EX)
            {
                throw EX;
            }
            finally
            {
                dSet.Dispose();
                dAd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
        //public DataSet FetchAuditId(PlanApplicationAuditBO objbo)
        //{
        //    OracleConnection conn = new OracleConnection(connStr);
        //    conn.Open();
        //    OracleDataAdapter dAd = new OracleDataAdapter("FetchAuditId", conn);
        //    dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    //dAd.SelectCommand.Parameters.Add("v_ReqID", OracleType.Number).Value = objbo.ReqCollectID;
        //    dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
        //    dAd.SelectCommand.Parameters.Add("v_AuditID", OracleType.Char).Value = objbo.AuditID;
        //    dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
        //    DataSet dSet = new DataSet();
        //    try
        //    {
        //        dAd.Fill(dSet);
        //        return dSet;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        dSet.Dispose();
        //        dAd.Dispose();
        //        conn.Close();
        //        conn.Dispose();
        //    }
        //}

    }
}
