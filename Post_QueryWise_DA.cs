using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using BO;

namespace DA
{
  public  class Post_QueryWise_DA
    {
        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();

        public DataSet QueryWiseAuditPost(Post_QueryWise_BO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            DataSet ds = new DataSet();
            try
            {
                OracleCommand cmd = new OracleCommand("R_QueryWiseAudit_Post", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("V_DPCD", OracleType.Number).Value = objBO.audit_id;              
                cmd.Parameters.Add("V_Action", OracleType.VarChar).Value = objBO.Action;
                cmd.Parameters.Add("V_CUR", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds;
        }
        public DataSet QueryWiseAudit(Post_QueryWise_BO objBO)
        {
            OracleConnection con = new OracleConnection(connStr);
            DataSet ds = new DataSet();
            try
            {
                OracleCommand cmd = new OracleCommand("R_QueryWiseAudit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("V_DPCD", OracleType.Number).Value = objBO.audit_id;              
                cmd.Parameters.Add("V_Action", OracleType.VarChar).Value = objBO.Action;
                cmd.Parameters.Add("V_Dept", OracleType.VarChar).Value = objBO.Dept;
                cmd.Parameters.Add("V_CUR", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds;
        }
    }
}
