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
    public class MenuDAL
    {


        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();

        public MenuDAL()
        {

        }
        public DataTable FetchMenuMastLoad(MenuBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("MENUMASTLOAD", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_Type", OracleType.VarChar).Value = objbo.type;
            dAd.SelectCommand.Parameters.Add("v_Freeze", OracleType.VarChar).Value = objbo.Freeze;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AAS_MENUMASTER");
                return dSet.Tables["AAS_MENUMASTER"];
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

        public DataTable FetchPostMenuMastLoad(MenuBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_POST_MENUMASTLOAD", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_Type", OracleType.VarChar).Value = objbo.type;
            dAd.SelectCommand.Parameters.Add("v_Freeze", OracleType.VarChar).Value = objbo.Freeze;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AAS_MENUMASTER");
                return dSet.Tables["AAS_MENUMASTER"];
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
        public DataTable FetchAppName(Int32 auditid)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand(" select ARC_APPLICATION_NAME from aas_req_collection where ARC_AASAUDIT_ID=" + auditid, conn);
            dCmd.CommandType = CommandType.Text;
            OracleDataAdapter dAd = new OracleDataAdapter(dCmd);
            DataSet dSet = new DataSet();

            try
            {
                dAd.Fill(dSet, "aas_req_collection");
                return dSet.Tables["aas_req_collection"];
            }
            catch
            {
                throw;
            }
            finally
            {
                dSet.Dispose();
                dAd.Dispose();
                dCmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }


        public DataTable FetchUserDetails(Int32 deptid, Int32 roleid)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            //OracleCommand dCmd = new OracleCommand("select a.role_desc,(select case when " + deptid + " =1 then 'Inspection' when " + deptid + " =2 then 'DIT' end  from dual)as dept   from  aas_rolemaster a where a.roleid=" + roleid, conn);
            OracleCommand dCmd = new OracleCommand("select a.role_desc,(SELECT AAS_DES FROM AAS_GEN_MASTER  WHERE AAS_MAIN_CODE=4 AND AAS_SUB_CODE <> 0 AND AAS_SUB_CODE= '" + deptid + "') as dept   from  aas_rolemaster a where a.roleid=" + roleid, conn);
            dCmd.CommandType = CommandType.Text;
            OracleDataAdapter dAd = new OracleDataAdapter(dCmd);
            DataSet dSet = new DataSet();

            try
            {
                dAd.Fill(dSet, "aas_req_collection");
                return dSet.Tables["aas_req_collection"];
            }
            catch
            {
                throw;
            }
            finally
            {
                dSet.Dispose();
                dAd.Dispose();
                dCmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
