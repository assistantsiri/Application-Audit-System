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
    public class Post_AuditClosureDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
        public DataTable FetchAuditClosure_Post(PlanApplicationAuditBO BO)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("auditclosureload_post", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = BO.Action;
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

        public DataTable FetchAuditTeamLoad_Post(PlanApplicationAuditBO BO)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("FETCHAUDITTEAMLOAD1_POST", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_AuditID", OracleType.VarChar).Value = BO.AuditID;
            dAd.SelectCommand.Parameters.Add("v_ReqID", OracleType.Number).Value = BO.CollectID;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = BO.Action;
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

        public DataTable FetchGradation_Post(PlanApplicationAuditBO BO)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_CombinedRiskRating_Post", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("auditid", OracleType.Int32).Value = BO.AuditID;
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
        public string CheckMandatory_POST(string AuditID)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("CHECKMANDATORY_POST", conn);
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
        public Byte UpdateAuditTeam_Post(PlanApplicationAuditBO BO)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("AUDITCLOSUREATUPDATE_POST", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("v_AuditID", OracleType.Number).Value = BO.AuditID;
            dCmd.Parameters.Add("v_StaffNo", OracleType.Number).Value = BO.StaffNum;
            dCmd.Parameters.Add("v_IrregTot", OracleType.Number).Value = BO.ChklstPending;
            dCmd.Parameters.Add("v_IrregRectiTot", OracleType.Number).Value = BO.ChklstRectified;

            dCmd.Parameters.Add("v_Action", OracleType.VarChar).Value = BO.Action;
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

        public Byte UpdateAuditClosure_Post(PlanApplicationAuditBO BO)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("AuditClosureUpdate_POST", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("v_AuditID", OracleType.VarChar).Value = BO.AuditID;
            dCmd.Parameters.Add("v_ReqCollectID", OracleType.Number).Value = BO.CollectID;
            dCmd.Parameters.Add("v_FromDate", OracleType.VarChar).Value = BO.FromDt;
            dCmd.Parameters.Add("v_ToDate", OracleType.VarChar).Value = BO.ToDt;
            dCmd.Parameters.Add("v_AuditStage", OracleType.VarChar).Value = BO.AuditStage;
            dCmd.Parameters.Add("v_Status", OracleType.VarChar).Value = BO.Status;
            dCmd.Parameters.Add("v_Gradation", OracleType.VarChar).Value = BO.Gradation;
            dCmd.Parameters.Add("v_UpdtStat", OracleType.VarChar).Value = BO.UpdtStat;
            dCmd.Parameters.Add("v_UpdtBy", OracleType.VarChar).Value = BO.UpdtBy;
            dCmd.Parameters.Add("v_Action", OracleType.VarChar).Value = BO.Action;
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
        public DataTable FetchAuditIdCountCheckListDetails_Post(PlanApplicationAuditBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("select count(t.acd_aasauditid) as acd_aasauditid  from AAS_CHECKLIST_DTLS_POST t where t.acd_aasauditid= " + objBO.AuditID + " ", con);
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

    }
}
    