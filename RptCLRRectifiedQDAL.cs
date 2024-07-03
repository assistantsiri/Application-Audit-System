using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using DA;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;

namespace DA
{
    public class RptCLRRectifiedQDAL
    {
        string con = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
        public RptCLRRectifiedQDAL()
        {
           
        }
        public DataTable FetchCLRRectifiedQ(RptCLRRectifiedQBO objbo)
        {
            OracleConnection conn = new OracleConnection(con);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("rptclrrectifiedqueries", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_AUDITID", OracleType.Int32).Value = objbo.AUDITID;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "RptCLRRectifiedQueries");
                return dSet.Tables["RptCLRRectifiedQueries"];
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
        public DataTable FetchApplicationName(RptCLRRectifiedQBO objbo)
        {
            OracleConnection conn = new OracleConnection(con);
            conn.Open();
            //Modified on 10-12-2018
            //OracleCommand cmd = new OracleCommand("SELECT a.aat_staffnumber,c.arc_application_name FROM AAS_AUDIT_TEAM a , aas_req_collection c WHERE  a.aat_reqcollectid=c.arc_req_collectid and aat_engagestatus='I'  AND AAT_STAFFNUMBER='" + objbo.StaffNum + "'", conn);
            OracleCommand cmd = new OracleCommand("select ARC_APPLICATION_NAME from aas_req_collection where ARC_AASAUDIT_ID='" + objbo.AUDITID + "'", conn);
            //End
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
                conn.Close();
                conn.Dispose();
            }
        }

    }
}
