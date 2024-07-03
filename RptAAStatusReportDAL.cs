using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OracleClient;
using BO;
using System.Configuration;
namespace DA
{
    public class RptAAStatusReportDAL
    {
        string con = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();

        public RptAAStatusReportDAL()
        {

        }
        public DataTable FetchRptAAStatusReport(RptAAStatusReportBO objbo,SectionMastBO ObjboSection)
        {
            OracleConnection conn = new OracleConnection(con);
            conn.Open();
            OracleDataAdapter oda = new OracleDataAdapter("RptAAStatusReport", conn);
            oda.SelectCommand.CommandType = CommandType.StoredProcedure;
            oda.SelectCommand.Parameters.Add("V_Action", OracleType.Char).Value = objbo.Action;
            oda.SelectCommand.Parameters.Add("V_Dept", OracleType.Char).Value = ObjboSection.MainCode;
            oda.SelectCommand.Parameters.Add("V_CUR", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            try
            {
                oda.Fill(ds, "RptAAStatusReport");
                return ds.Tables["RptAAStatusReport"];
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

