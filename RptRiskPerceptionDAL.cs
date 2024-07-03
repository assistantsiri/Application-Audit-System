using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using BO;


namespace DA
{
   public class RptRiskPerceptionDAL
    {  string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
       public RptRiskPerceptionDAL()
       {
       }
      
        public DataTable FetchRptRiskPerception(RptRiskPerceptionBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("RPTRISKPERCEPTION", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_AUDITID", OracleType.Int32).Value = objbo.AUDITID;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "RptRiskPerception");
                return dSet.Tables["RptRiskPerception"];
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
        public DataTable FetchApplicationName(RptRiskPerceptionBO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            //Start 11012017 kirthi
            //  OracleCommand cmd = new OracleCommand("SELECT a.aat_staffnumber,c.arc_application_name FROM AAS_AUDIT_TEAM a , aas_req_collection c WHERE  a.aat_reqcollectid=c.arc_req_collectid and aat_engagestatus='I'  AND AAT_STAFFNUMBER=" + objBO.StaffNum, con);
            //OracleCommand cmd = new OracleCommand("SELECT a.aat_staffnumber,c.arc_application_name FROM AAS_AUDIT_TEAM a , aas_req_collection c WHERE  a.aat_reqcollectid=c.arc_req_collectid and aat_engagestatus='I'  AND AAT_STAFFNUMBER='" + objBO.StaffNum +"'", con);
            //Modified on 10-12-2018
            OracleCommand cmd = new OracleCommand("select ARC_APPLICATION_NAME from aas_req_collection where ARC_AASAUDIT_ID='" + objBO.AUDITID + "'", con);
            //End
            //End 11012017 kirthi
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

