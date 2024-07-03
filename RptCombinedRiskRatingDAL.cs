using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.OracleClient;
using BO;

namespace DA
{
    public class RptCombinedRiskRatingDAL
    {
        string con = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
        public RptCombinedRiskRatingDAL()
        {

        }
        public DataTable FetchRiskRatingFirstLevel(RptCombinedRiskRatingBO objbo)
        {
            OracleConnection conn = new OracleConnection(con);
            conn.Open();
            OracleDataAdapter oda = new OracleDataAdapter("RPTRISKPERCEPTION", conn);
            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.Add("V_AUDITID", OracleType.Int32).Value = objbo.AUDITID;
            oda.SelectCommand.Parameters.Add("V_Action", OracleType.Char).Value = objbo.Action;
            oda.SelectCommand.Parameters.Add("V_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            try
            {
                oda.Fill(ds,"RiskRating");
                return ds.Tables["RiskRating"];
            }
            catch
            {
                throw;
            }
            finally
            {
                objbo = null;
                ds = null;
                oda = null;
                conn.Close();
                conn.Dispose();
            }

        }
        public DataTable FetchRiskRatingSecondLevel(RptCombinedRiskRatingBO objbo)
        {
            OracleConnection conn = new OracleConnection(con);
            conn.Open();
            OracleDataAdapter oda = new OracleDataAdapter("AAS_SecondLevelRiskRating", conn);
            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.Add("auditid", OracleType.Int32).Value = objbo.AUDITID;
            oda.SelectCommand.Parameters.Add("V_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            try
            {
                oda.Fill(ds, "RiskRating");
                return ds.Tables["RiskRating"];
            }
            catch
            {
                throw;
            }
            finally
            {
                objbo = null;
                ds = null;
                oda = null;
                conn.Close();
                conn.Dispose();
            }

        }
        public DataTable FetchRiskRatingCombined(RptCombinedRiskRatingBO objbo)
        {
            OracleConnection conn = new OracleConnection(con);
            conn.Open();
            OracleDataAdapter oda = new OracleDataAdapter("AAS_CombinedRiskRating", conn);
            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.Add("auditid", OracleType.Int32).Value = objbo.AUDITID;
            oda.SelectCommand.Parameters.Add("V_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            try
            {
                oda.Fill(ds, "RiskRating");
                return ds.Tables["RiskRating"];
            }
            catch
            {
                throw;
            }
            finally
            {
                objbo = null;
                ds = null;
                oda = null;
                conn.Close();
                conn.Dispose();
            }

        }
        public DataTable FetchApplicationName(RptCombinedRiskRatingBO objbo)
        {
            OracleConnection conn = new OracleConnection(con);
            conn.Open();
            //Start 11012017 kirthi 
            //OracleCommand cmd = new OracleCommand("SELECT a.aat_staffnumber,c.arc_application_name FROM AAS_AUDIT_TEAM a , aas_req_collection c WHERE  a.aat_reqcollectid=c.arc_req_collectid and aat_engagestatus='I'  AND AAT_STAFFNUMBER=" + objbo.StaffNum, conn);
            OracleCommand cmd = new OracleCommand("SELECT a.aat_staffnumber,c.arc_application_name FROM AAS_AUDIT_TEAM a , aas_req_collection c WHERE  a.aat_reqcollectid=c.arc_req_collectid and aat_engagestatus='I'  AND AAT_STAFFNUMBER='" + objbo.StaffNum + "'", conn);
            //Start 11012017 kirthi 
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
