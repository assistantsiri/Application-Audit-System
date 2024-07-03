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
    public class AudithistoryDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
        public AudithistoryDAL()
        {

        }
        public DataTable FetchauditHistory(Int32 reqid)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AuditHistory", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_REQ_COLLECTID", OracleType.Int32).Value = reqid;
                dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AuditHistory");
                return dSet.Tables["AuditHistory"];
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
        public DataTable FetctReqID()
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("SELECT DISTINCT APA_REQ_COLLECTID ,APA_REQ_COLLECTID || '-' ||(select b.arc_application_name from aas_req_collection b where b.arc_req_collectid=APA_REQ_COLLECTID) as appname FROM aas_plan_audit WHERE APA_AUDIT_STAGE='O' order by APA_REQ_COLLECTID", conn);
            dCmd.CommandType = CommandType.Text;
            OracleDataAdapter dAd = new OracleDataAdapter(dCmd);
            DataSet dSet = new DataSet();

            try
            {
                dAd.Fill(dSet, "aas_plan_audit");
                return dSet.Tables["aas_plan_audit"];
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
