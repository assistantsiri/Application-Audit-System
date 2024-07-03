using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using BO;
using DA;
using System.Configuration;
using System.Data.OracleClient;


namespace DA
{
    public class RptCLPendingQueriesDAL
    {
        string con = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
        public RptCLPendingQueriesDAL()
        {

        }
        public DataTable FetchRptCLPendingQueries(RptCLPendingQueriesBO objbo)
        {
            OracleConnection conn = new OracleConnection(con);
            conn.Open();
            OracleDataAdapter dta = new OracleDataAdapter("RPTCLRPENDINGQUERIES", conn);
            dta.SelectCommand.CommandType = CommandType.StoredProcedure;
            dta.SelectCommand.Parameters.Add("V_AUDITID", OracleType.Int32).Value = objbo.AUDITID;
            dta.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
            dta.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            try
            {
                dta.Fill(ds, "RptCLPendingQueries");
                return ds.Tables["RptCLPendingQueries"];
            }
            catch
            {
                throw;
            }
            finally
            {
                ds.Dispose();
                dta.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
        public DataTable FetchApplicationName(RptCLPendingQueriesBO objbo)
        {
            OracleConnection conn = new OracleConnection(con);
            conn.Open();
            //Modified on 10-12-2018
            //OracleDataAdapter dta = new OracleDataAdapter("SELECT a.aat_staffnumber,c.arc_application_name FROM AAS_AUDIT_TEAM a , aas_req_collection c WHERE  a.aat_reqcollectid=c.arc_req_collectid and aat_engagestatus='I'  AND AAT_STAFFNUMBER='" + objbo.StaffNum + "'", conn);
            OracleDataAdapter dta = new OracleDataAdapter("select ARC_APPLICATION_NAME from aas_req_collection where ARC_AASAUDIT_ID='" + objbo.AUDITID + "'", conn);
            //End
            dta.SelectCommand.CommandType = CommandType.Text;

            DataSet ds = new DataSet();
            try
            {
                dta.Fill(ds, "AAS_App_Name");
                return ds.Tables["AAS_App_Name"];
            }
            catch
            {
                throw;
            }
            finally
            {
                ds.Dispose();
                dta.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
