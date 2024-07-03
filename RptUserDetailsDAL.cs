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
  public class RptUserDetailsDAL
    {
      string con = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
      public RptUserDetailsDAL()
      {

      }
      public DataTable FetchRptUserDetails(RptUserDetailsBO objbo)
      {

          OracleConnection conn = new OracleConnection(con);
          conn.Open();
          OracleDataAdapter oda = new OracleDataAdapter("RptUserDetails", con);
          oda.SelectCommand.CommandType = CommandType.StoredProcedure;
          oda.SelectCommand.Parameters.Add("V_Action", OracleType.Char).Value = objbo.Action;
          oda.SelectCommand.Parameters.Add("V_CUR", OracleType.Cursor).Direction = ParameterDirection.Output;
          DataSet ds = new DataSet();
          try
          {
              oda.Fill(ds, "RptUserDetailsBO");
              return ds.Tables["RptUserDetailsBO"];
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
