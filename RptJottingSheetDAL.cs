using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.OracleClient;
using BO;
using System.Configuration;

namespace DA
{
    public class RptJottingSheetDAL
    {
        string con = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
        public RptJottingSheetDAL()
        {

        }
        public DataTable FetchRptJottingSheet(RptJottingSheetBO objbo)
        {
            OracleConnection conn = new OracleConnection(con);
            conn.Open();
            OracleDataAdapter oda = new OracleDataAdapter("RptJottingSheet", conn);
            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.Add("V_AUDITID", OracleType.Int32).Value = objbo.AUDITID;
            oda.SelectCommand.Parameters.Add("V_Action", OracleType.Char).Value = objbo.Action;
            oda.SelectCommand.Parameters.Add("V_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            try
            {
                oda.Fill(ds, "RptJottingSheet");
                return ds.Tables["RptJottingSheet"];
            }
            catch
            {
                throw;
            }
            finally
            {
                objbo = null;

            }
        }
        public DataTable FetchApplicationName(RptJottingSheetBO objbo)
        {

            OracleConnection conn = new OracleConnection(con);
            conn.Open();
            //Start 11012017 kirthi
           // OracleCommand cmd = new OracleCommand("SELECT a.aat_staffnumber,c.arc_application_name FROM AAS_AUDIT_TEAM a , aas_req_collection c WHERE  a.aat_reqcollectid=c.arc_req_collectid and aat_engagestatus='I'  AND AAT_STAFFNUMBER=" + objbo.StaffNum , conn);
            //OracleCommand cmd = new OracleCommand("SELECT a.aat_staffnumber,c.arc_application_name FROM AAS_AUDIT_TEAM a , aas_req_collection c WHERE  a.aat_reqcollectid=c.arc_req_collectid and aat_engagestatus='I'  AND AAT_STAFFNUMBER='" + objbo.StaffNum +"'", conn);
            //Modified on 10-12-2018
            OracleCommand cmd = new OracleCommand("select ARC_APPLICATION_NAME from aas_req_collection where ARC_AASAUDIT_ID='" + objbo.AUDITID + "'", conn);
            //End
            //End 11012017 kirthi
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter oda = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                oda.Fill(ds, "ApplicationName");
                return ds.Tables["ApplicationName"];
            }
            catch
            {
                throw;
            }
            finally
            {
                objbo = null;
            }
        }
    }

}
