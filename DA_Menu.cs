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
    public class DA_Menu
    {


        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();

        public DA_Menu()
        {

        }
        public DataTable FetchMenuMastLoad(BO_Menu objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("MENUMASTLOAD", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_Type", OracleType.VarChar).Value = objbo.type;
            dAd.SelectCommand.Parameters.Add("v_Freeze", OracleType.VarChar).Value = objbo.Freeze;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AAS_MENUMASTER");
                return dSet.Tables["AAS_MENUMASTER"];
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
