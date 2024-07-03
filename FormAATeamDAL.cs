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
    public class FormAATeamDAL
    {

        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
        public DataSet FetchFormATeam(FormAATeamBO objbo)
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

        public Byte UpdateFormATeam(FormAATeamBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("AUDITTEAMUPDATE", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("v_AuditID", OracleType.Number).Value = objbo.AuditID;
            dCmd.Parameters.Add("v_ReqCollectID", OracleType.Number).Value = objbo.ReqCollectID;
            dCmd.Parameters.Add("v_StaffNo", OracleType.VarChar).Value = objbo.StaffNum;
            dCmd.Parameters.Add("v_StaffNoEdit", OracleType.Number).Value = objbo.StaffNumEdit;
            dCmd.Parameters.Add("v_TeamLeadYN", OracleType.VarChar).Value = objbo.TeamLeadYN;
            dCmd.Parameters.Add("v_EngageStatus", OracleType.VarChar).Value = objbo.EngageStatus;
            dCmd.Parameters.Add("v_AllocDate", OracleType.VarChar).Value = objbo.AllocDate;
            dCmd.Parameters.Add("v_RelieveDate", OracleType.VarChar).Value = objbo.RelieveDt;
            dCmd.Parameters.Add("v_IrregTot", OracleType.Number).Value = objbo.IrregTot;
            dCmd.Parameters.Add("v_IrregRectiTot", OracleType.Number).Value = objbo.IrregRectiTot;
            dCmd.Parameters.Add("v_Status", OracleType.VarChar).Value = objbo.Status;
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

        public DataTable FetchReqCollectionDetails(FormAATeamBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT * FROM AAS_REQ_COLLECTION Where ARC_REQ_COLLECTID = " + objBO.ReqCollectID + " ", con);
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

        public DataTable FetchStaffNum(FormAATeamBO objBO)
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
                return ds.Tables["AAS_USER_MAST"];
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

        public DataTable FetchStaffDetails(FormAATeamBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT AUM_STAFF_NAME, (CASE AUM_DESIGNATION  WHEN '1' THEN 'GM'  WHEN '2' THEN  'DGM' WHEN '3' THEN 'AGM' WHEN '4' THEN 'DM' WHEN '5' THEN 'Senior Manager' WHEN '6' THEN 'MANAGER' WHEN '7' THEN 'OFFICER' ELSE 'OTHERS' END) AUM_DESIGNATION,AUM_EMAIL FROM AAS_USER_MAST Where AUM_STAFF_NO =  '" + objBO.StaffNum + "' ", con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "AAS_USER_MAST");
                return ds.Tables["AAS_USER_MAST"];
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

        public DataTable FetchTeamLeaderCount(FormAATeamBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT * FROM AAS_AUDIT_TEAM WHERE AAT_REQCOLLECTID='" + objBO.ReqCollectID + "'  AND AAT_TEAMLEADYN='Y' AND AAT_STATUS = 'A' AND AAT_ENGAGESTATUS <> 'R'", con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "AAS_AUDIT_TEAM");
                return ds.Tables["AAS_AUDIT_TEAM"];
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

        public DataTable FetchFormAATeamDetails(FormAATeamBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT * FROM AAS_AUDIT_TEAM WHERE AAT_REQCOLLECTID='" + objBO.ReqCollectID + "'  AND AAT_STATUS = 'A' AND AAT_UPDT_STAT='P' ", con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "AAS_AUDIT_TEAM");
                return ds.Tables["AAS_AUDIT_TEAM"];
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

        public DataTable FetchAuditID(FormAATeamBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT AAT_AASAUDITID FROM AAS_AUDIT_TEAM WHERE AAT_REQCOLLECTID='" + objBO.ReqCollectID + "'  AND AAT_STATUS = 'A' AND AAT_UPDT_STAT='A'", con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "AAS_AUDIT_TEAM");
                return ds.Tables["AAS_AUDIT_TEAM"];
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



        public DataTable FetchAllocateStaffCount(FormAATeamBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT * FROM AAS_USER_MAST WHERE AUM_STAFF_NO ='" + objBO.StaffNum + "' AND AUM_AUDIT_STAT='I' AND AUM_STATUS = 'A' ", con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "AAS_USER_MAST");
                return ds.Tables["AAS_USER_MAST"];
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

        public DataTable FetchRequirementId(FormAATeamBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();

            OracleCommand cmd = new OracleCommand("SELECT DISTINCT A.APA_REQ_COLLECTID as APA_REQ_COLLECTID,B.ARC_REQ_COLLECTID,A.APA_REQ_COLLECTID || '-' || B.ARC_APPLICATION_NAME AS ARC_APPLICATION_NAME  FROM AAS_PLAN_AUDIT A,AAS_REQ_COLLECTION B WHERE B.ARC_REQ_COLLECTID = A.APA_REQ_COLLECTID AND APA_STATUS='A'  ORDER BY APA_REQ_COLLECTID", con);
            //OracleCommand cmd = new OracleCommand("select arc_req_collectid  from aas_req_collection where arc_updt_stat='A'", con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {

                da.Fill(ds);
                return ds.Tables[0];
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

