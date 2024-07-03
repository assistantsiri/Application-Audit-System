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
  public  class DashboardDAL
    {

       string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
       public DashboardDAL()
        {

        }
        public DataTable FetchDashboard()
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("Dashboard", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            
                dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "Dashboard");
                return dSet.Tables["Dashboard"];
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
