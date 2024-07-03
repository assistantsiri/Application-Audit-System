using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

using BO;

namespace DA
{
    public class CombinedRiskDAL
    {

        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
        public CombinedRiskDAL()
        {

        }
        public DataTable FetchRptAuditReportLoad(CombinedRiskBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("RPTAUDITREPORT", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_AUDITID", OracleType.Int32).Value = objbo.AUDITID;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "RPTAUDITREPORT");
                return dSet.Tables["RPTAUDITREPORT"];
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
        public DataTable FetchApplicationName(CombinedRiskBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT a.aat_staffnumber,c.arc_application_name FROM AAS_AUDIT_TEAM a , aas_req_collection c WHERE  a.aat_reqcollectid=c.arc_req_collectid and aat_engagestatus='I'  AND AAT_STAFFNUMBER=" + objBO.StaffNum, con);

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
        public DataTable FetchRisk(CombinedRiskBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_CombinedRiskRating", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("auditid", OracleType.Int32).Value = objbo.AUDITID;

            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AAS_CombinedRiskRating");
                return dSet.Tables["AAS_CombinedRiskRating"];
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
