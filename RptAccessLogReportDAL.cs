using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data;
using System.Data.OracleClient;
using BO;


namespace DA
{
    public class RptAccessLogReportDAL
    {
        string con = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
        public RptAccessLogReportDAL()
        {

        }
        public DataTable FetchRptAccessLogReport(RptAccessLogReportBO objbo)
        {

            OracleConnection conn = new OracleConnection(con);
            conn.Open();
            OracleDataAdapter oda = new OracleDataAdapter("RptAccessLogReport", con);
            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.Add("V_Action", OracleType.Char).Value = objbo.Action;
            oda.SelectCommand.Parameters.Add("V_CUR", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            try
            {
                oda.Fill(ds, "RptAccessLogReport");
                return ds.Tables["RptAccessLogReport"];
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                objbo = null;
            }
        }

    }
}
