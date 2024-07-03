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
   public class UserMaintenanceDAL
    {
       string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
       public DataTable FetchUserDtls(UserMaintenanceBO objBO)
       {
           OracleConnection conn = new OracleConnection(connStr);
           conn.Open();
           OracleDataAdapter dAd = new OracleDataAdapter("FetchUserMast", conn);
           dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
           dAd.SelectCommand.Parameters.Add("v_StaffNo", OracleType.VarChar).Value = objBO.StaffNo;
                      dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objBO.Action;
           dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
           DataSet dSet = new DataSet();
           try
           {
               dAd.Fill(dSet, "AAS_USER_MAST");
               return dSet.Tables["AAS_USER_MAST"];
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
       public DataTable FetchUserMast(UserMaintenanceBO objBO)
       {
           OracleConnection con = new OracleConnection(connStr);
           con.Open();
           OracleCommand cmd = new OracleCommand("SELECT * FROM AAS_USER_MAST WHERE AUM_STAFF_NO='" + objBO.StaffNo + "' AND AUM_STATUS = 'A'  ", con);
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

       public DataTable FetchUserMastLog(UserMaintenanceBO objBO)
       {
           OracleConnection con = new OracleConnection(connStr);
           con.Open();
           OracleCommand cmd = new OracleCommand("SELECT max(AUL_LOG_ATTEMPT) as  AUL_LOG_ATTEMPT FROM AAS_USER_LOG WHERE AUL_STAFFNUMBER='" + objBO.StaffNo + "'  ", con);
           //OracleCommand cmd = new OracleCommand("SELECT * FROM AAS_USER_MAST_LOG WHERE AUML_STAFF_NO='" + objBO.StaffNo + "'  ", con);
           cmd.CommandType = CommandType.Text;
           OracleDataAdapter da = new OracleDataAdapter(cmd);
           DataSet ds = new DataSet();
           try
           {
               da.Fill(ds, "AAS_USER_LOG");
               return ds.Tables["AAS_USER_LOG"];
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

       public DataTable FetchUserMastLoad(UserMaintenanceBO objbo)
       {
           OracleConnection conn = new OracleConnection(connStr);
           conn.Open();
           OracleDataAdapter dAd = new OracleDataAdapter("USERMASTLOAD", conn);
           dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
           dAd.SelectCommand.Parameters.Add("v_StaffNo", OracleType.VarChar).Value = objbo.StaffNo;
           dAd.SelectCommand.Parameters.Add("v_Role", OracleType.VarChar).Value = objbo.Role;
           dAd.SelectCommand.Parameters.Add("v_Dept", OracleType.VarChar).Value = objbo.Dept;
           dAd.SelectCommand.Parameters.Add("v_DeSignation", OracleType.VarChar).Value = objbo.Designation;
           dAd.SelectCommand.Parameters.Add("v_Section", OracleType.VarChar).Value = objbo.Section;
           dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
           dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
           DataSet dSet = new DataSet();
           try
           {
               dAd.Fill(dSet, "AAS_USER_MAST");
               return dSet.Tables["AAS_USER_MAST"];
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

        public Byte UpdateUserMast(UserMaintenanceBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("USERMASTUPDATE", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("v_StaffNo", OracleType.VarChar).Value = objbo.StaffNo;
            dCmd.Parameters.Add("v_StaffName", OracleType.VarChar).Value = objbo.StaffName;
            dCmd.Parameters.Add("v_Dept", OracleType.VarChar).Value = objbo.Dept;
            dCmd.Parameters.Add("v_Designation", OracleType.VarChar).Value = objbo.Designation;
            dCmd.Parameters.Add("v_Role", OracleType.VarChar).Value = objbo.Role;
            dCmd.Parameters.Add("v_Phone", OracleType.VarChar).Value = objbo.Phone;
            dCmd.Parameters.Add("v_SecID", OracleType.VarChar).Value = objbo.SecId;
            dCmd.Parameters.Add("v_WingID", OracleType.VarChar).Value = objbo.WingId;  
            dCmd.Parameters.Add("v_Mobile", OracleType.VarChar).Value = objbo.Mobile;
            dCmd.Parameters.Add("v_Email", OracleType.VarChar).Value = objbo.Email;
            dCmd.Parameters.Add("v_Pwd_hashed", OracleType.VarChar).Value = objbo.Pwd;
            dCmd.Parameters.Add("v_Pwd", OracleType.VarChar).Value = objbo.Pwd_hashed;//v_Pwd
            dCmd.Parameters.Add("v_salt", OracleType.VarChar).Value = objbo.salt;
            dCmd.Parameters.Add("v_salt_state", OracleType.VarChar).Value = objbo.salt_state;
            dCmd.Parameters.Add("v_ValidFrom", OracleType.VarChar).Value = objbo.ValidFrom;
            dCmd.Parameters.Add("v_ValidTo", OracleType.VarChar).Value = objbo.ValidTo;
            dCmd.Parameters.Add("v_Status", OracleType.VarChar).Value = objbo.Status;
            dCmd.Parameters.Add("v_UpdtStatus", OracleType.VarChar).Value = objbo.Updtstatus;
            dCmd.Parameters.Add("v_UpdtBy", OracleType.VarChar).Value = objbo.UpdtBy;
            dCmd.Parameters.Add("v_Audit_Stat", OracleType.VarChar).Value = objbo.Audit_Stat;
            dCmd.Parameters.Add("v_Section", OracleType.VarChar).Value = objbo.Section;
            dCmd.Parameters.Add("v_Uselock", OracleType.VarChar).Value = objbo.user_lock;
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

        public DataTable FetchTeamLeaderCount(FormAATeamBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT * FROM AAS_AUDIT_TEAM WHERE AAT_REQCOLLECTID='" + objBO.ReqCollectID + "'  AND AAT_TEAMLEADYN='Y' ", con);
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
        public DataTable FetchAuditId(UserMaintenanceBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("select case when Max(AAT_AASAUDITID) is null then 0 else Max(AAT_AASAUDITID)  end as AAT_AASAUDITID " +
                " FROM AAS_AUDIT_TEAM WHERE  aat_engagestatus='I'  AND AAT_STAFFNUMBER=" + objBO.StaffNo, con);

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
        public DataTable FetchAuditIdPost(UserMaintenanceBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("select case when Max(AAT_AASAUDITID) is null then 0 else Max(AAT_AASAUDITID)  end as AAT_AASAUDITID " +
                " FROM AAS_AUDIT_TEAM_post WHERE  aat_engagestatus='I'  AND AAT_STAFFNUMBER=" + objBO.StaffNo, con);

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
        //added on 11082016
        public DataTable FetchLoginattempts(UserMaintenanceBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("select * from  aas_user_log b where b.aul_staffnumber="+objBO.StaffNo + " and b.aul_auditid=" + objBO.auditid + " and b.aul_log_date=to_char(sysdate,'dd/mon/yyyy') ", con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "aas_user_log");
                return ds.Tables["aas_user_log"];
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

        public Byte SaveUpdateLoginattempt(UserMaintenanceBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("AAS_LoginAttempt_INSERT_UPDATE", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("v_staffno", OracleType.VarChar).Value = objbo.StaffNo;
            dCmd.Parameters.Add("v_auditid", OracleType.VarChar).Value = objbo.auditid;
            dCmd.Parameters.Add("v_logindate", OracleType.VarChar).Value = objbo.UpdtDt;
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

        public DataTable FetchDesignation(UserMaintenanceBO objbo)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT AAS_SUB_CODE,AAS_DES FROM AAS_GEN_MASTER  WHERE AAS_MAIN_CODE=2 AND AAS_SUB_CODE <> 0 ORDER BY AAS_SUB_CODE", con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {

                da.Fill(ds, "AAS_GEN_MASTER");
                return ds.Tables["AAS_GEN_MASTER"];
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


        public DataTable FetchRole(UserMaintenanceBO objbo)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT AAS_SUB_CODE,AAS_DES FROM AAS_GEN_MASTER  WHERE AAS_MAIN_CODE=3 AND AAS_SUB_CODE <> 0 ORDER BY AAS_SUB_CODE", con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {

                da.Fill(ds, "AAS_GEN_MASTER");
                return ds.Tables["AAS_GEN_MASTER"];
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
        public DataTable FetchWing(UserMaintenanceBO objbo)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT AAS_SUB_CODE,AAS_DES FROM AAS_GEN_MASTER  WHERE AAS_MAIN_CODE=4 AND AAS_SUB_CODE <> 0 ORDER BY AAS_SUB_CODE", con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {

                da.Fill(ds, "AAS_GEN_MASTER");
                return ds.Tables["AAS_GEN_MASTER"];
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

        public DataTable FetchSection(UserMaintenanceBO objbo)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT ASM_SEC_CODE,ASM_SEC_CODE || '-' || ASM_SEC_NAME as ASM_SEC_NAME FROM AAS_SECTION_MAST  WHERE ASM_MAIN_CODE='" + objbo.Dept+"'  ORDER BY ASM_SEC_CODE", con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {

                da.Fill(ds, "AAS_SECTION_MAST");
                return ds.Tables["AAS_SECTION_MAST"];
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
        public DataTable AudtidIdLoad(UserMaintenanceBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("UserMastAuditIdLoad", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_staffno", OracleType.VarChar).Value = objbo.StaffNo;
                  dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "aas_audit_team");
                return dSet.Tables["aas_audit_team"];
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

        public DataTable FetchAuditId_POST(UserMaintenanceBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("select case when Max(AAT_AASAUDITID) is null then 0 else Max(AAT_AASAUDITID)  end as AAT_AASAUDITID " +
                " FROM AAS_AUDIT_TEAM_POST WHERE  aat_engagestatus='I'  AND AAT_STAFFNUMBER=" + objBO.StaffNo, con);

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
    }
}
