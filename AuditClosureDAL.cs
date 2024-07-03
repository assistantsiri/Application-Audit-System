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
   public class AuditClosureDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
        public Byte UpdateAuditAbundant(PlanApplicationAuditBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("AUDITCLOSUREABUNDUPDATE", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("v_AuditID", OracleType.VarChar).Value = objbo.AuditID;
            dCmd.Parameters.Add("v_ReqCollectID", OracleType.Number).Value = objbo.CollectID;
            dCmd.Parameters.Add("v_FromDate", OracleType.VarChar).Value = objbo.FromDt;
            dCmd.Parameters.Add("v_ToDate", OracleType.VarChar).Value = objbo.ToDt;
            dCmd.Parameters.Add("v_AuditStage", OracleType.VarChar).Value = objbo.AuditStage;
            dCmd.Parameters.Add("v_Status", OracleType.VarChar).Value = objbo.Status;
            dCmd.Parameters.Add("v_Gradation", OracleType.VarChar).Value = objbo.Gradation;
            dCmd.Parameters.Add("V_remarks", OracleType.VarChar).Value = objbo.Remarks;
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
        public DataTable FetchAuditClosure(PlanApplicationAuditBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AUDITCLOSURELOAD", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            //dAd.SelectCommand.Parameters.Add("v_AuditID", OracleType.Number).Value = objbo.AuditID;
            //dAd.SelectCommand.Parameters.Add("v_ReqID", OracleType.Number).Value = objbo.CollectID;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet);
                return dSet.Tables[0];
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
        public DataTable AuditReport(PlanApplicationAuditBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("R_AuditAbundant", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_ACTION", OracleType.Char).Value = objbo.Action;
            dAd.SelectCommand.Parameters.Add("V_CUR", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet);
                return dSet.Tables[0];
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
        public DataTable FetchAuditTeamLoad(PlanApplicationAuditBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("FETCHAUDITTEAMLOAD1", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_AuditID", OracleType.VarChar).Value = objbo.AuditID;
            dAd.SelectCommand.Parameters.Add("v_ReqID", OracleType.Number).Value = objbo.CollectID;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet);
                return dSet.Tables[0];
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


        public DataTable FetchRequirementId(PlanApplicationAuditBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT DISTINCT ARC_REQ_COLLECTID FROM AAS_REQ_COLLECTION WHERE ARC_UPDT_STAT='A' ORDER BY ARC_REQ_COLLECTID", con);
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
        public Byte UpdateAuditClosure(PlanApplicationAuditBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("AUDITCLOSUREUPDATE", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("v_AuditID", OracleType.VarChar).Value = objbo.AuditID;
            dCmd.Parameters.Add("v_ReqCollectID", OracleType.Number).Value = objbo.CollectID;
            dCmd.Parameters.Add("v_FromDate", OracleType.VarChar).Value = objbo.FromDt;
            dCmd.Parameters.Add("v_ToDate", OracleType.VarChar).Value = objbo.ToDt;
            dCmd.Parameters.Add("v_AuditStage", OracleType.VarChar).Value = objbo.AuditStage;
            dCmd.Parameters.Add("v_Status", OracleType.VarChar).Value = objbo.Status;
            dCmd.Parameters.Add("v_Gradation", OracleType.VarChar).Value = objbo.Gradation;
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

    


        public DataTable FetchApplicationName(PlanApplicationAuditBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT ARC_APPLICATION_NAME FROM AAS_REQ_COLLECTION Where ARC_REQ_COLLECTID = " + objBO.CollectID + " ", con);
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



        public DataTable FetchApplicationAudit(PlanApplicationAuditBO objBO)
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

        public DataTable CheckCommenceStatus(PlanApplicationAuditBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT * FROM AAS_PLAN_AUDIT WHERE APA_AUDIT_STAGE='C' AND APA_STATUS='A' AND APA_UPDT_STAT='P' AND APA_REQ_COLLECTID = " + objBO.CollectID + "", con);
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

        public DataTable FetchAuditIdCountCheckListDetails(PlanApplicationAuditBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("select count(t.acd_aasauditid) as acd_aasauditid  from aas_checklist_details t where t.acd_aasauditid= " + objBO.AuditID + " ", con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "CheckListDetailsAuditID");
                return ds.Tables["CheckListDetailsAuditID"];
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

        public DataTable FetchGradation(PlanApplicationAuditBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_CombinedRiskRating", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("auditid", OracleType.Int32).Value = objbo.AuditID;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AuditClouserGradation");
                return dSet.Tables["AuditClouserGradation"];
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

        public Byte UpdateAuditTeam(PlanApplicationAuditBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("AUDITCLOSUREATUPDATE", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("v_AuditID", OracleType.Number).Value = objbo.AuditID;
            dCmd.Parameters.Add("v_StaffNo", OracleType.Number).Value = objbo.StaffNum;
            dCmd.Parameters.Add("v_IrregTot", OracleType.Number).Value = objbo.ChklstPending;
            dCmd.Parameters.Add("v_IrregRectiTot", OracleType.Number).Value = objbo.ChklstRectified;

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



        public string CheckMandatory(string AuditID)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("CHECKMANDATORY", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("V_AUDITID", OracleType.Number).Value = AuditID;
            dCmd.Parameters.Add("V_MESSAGE", OracleType.VarChar, 500).Direction = ParameterDirection.Output;
            try
            {
                dCmd.ExecuteNonQuery();
                return Convert.ToString(dCmd.Parameters["V_MESSAGE"].Value);
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
