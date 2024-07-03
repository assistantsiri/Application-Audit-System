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
    public class DocArchiveDAL
    {
          string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
          public DocArchiveDAL()
        {

        }
          public DataTable DocumentArchive(DocArchiveBO objbo)
          {
              OracleConnection conn = new OracleConnection(connStr);
              conn.Open();
              OracleDataAdapter dAd = new OracleDataAdapter("DocumentArchive", conn);
              dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
           dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
              DataSet dSet = new DataSet();
              try
              {
                  dAd.Fill(dSet, "DocumentArchive");
                  return dSet.Tables["DocumentArchive"];
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
          public Byte UpdateDocupload(DocArchiveBO objbo)
          {
              OracleConnection conn = new OracleConnection(connStr);
              conn.Open();
              OracleCommand dCmd = new OracleCommand("AAS_FILE_ARCHIVE", conn);
              dCmd.CommandType = CommandType.StoredProcedure;
             
              dCmd.Parameters.Add("V_ARF_REQ_COLLECTID", OracleType.Int32).Value = objbo.collectId;
              dCmd.Parameters.Add("v_ARF_NEWUPLOADFILE", OracleType.VarChar).Value = objbo.newDocDesc;
              dCmd.Parameters.Add("v_ARF_UPLOADFILE", OracleType.VarChar).Value = objbo.Docname;
              dCmd.Parameters.Add("V_ARF_UPDT_BY", OracleType.VarChar).Value = objbo.UpdtdBy;
              dCmd.Parameters.Add("V_ARF_UPDT_DT", OracleType.VarChar).Value = objbo.UpdtdDt;
              dCmd.Parameters.Add("v_Result", OracleType.Byte).Direction = ParameterDirection.Output;

              try
              {
                  dCmd.ExecuteNonQuery();
                  return Convert.ToByte(dCmd.Parameters["v_Result"].Value);
              }
              catch
              {
                  throw;
              }
              finally
              {
                  dCmd.Dispose();
                  conn.Close();
                  conn.Dispose();
              }
          }
    }
     
}
