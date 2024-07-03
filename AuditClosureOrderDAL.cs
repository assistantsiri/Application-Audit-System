using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using BO;

namespace DA
{
    public class AuditClosureOrderDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();

        public AuditClosureOrderDAL()
        {
        }

        public DataTable FetchAuditClosureOrder(AuditClosureOrderBO Audit)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AuditClosureOrderLoad", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_auditId", OracleType.Number).Value = Audit.audit_id;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = Audit.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "aas_audit_closure_order");
                return dSet.Tables["aas_audit_closure_order"];
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

        public String UpdateAuditClosureOrder(AuditClosureOrderBO Audit)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("AuditClosureOrderUpdate", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("v_audit_id", OracleType.Number).Value = Audit.audit_id;
            dCmd.Parameters.Add("v_from_adrs1", OracleType.VarChar).Value = Audit.from_adrs1;
            dCmd.Parameters.Add("v_from_adrs2", OracleType.VarChar).Value = Audit.from_adrs2;
            dCmd.Parameters.Add("v_from_adrs3", OracleType.VarChar).Value = Audit.from_adrs3;
            dCmd.Parameters.Add("v_to_adrs1", OracleType.VarChar).Value = Audit.to_adrs1;
            dCmd.Parameters.Add("v_to_adrs2", OracleType.VarChar).Value = Audit.to_adrs2;
            dCmd.Parameters.Add("v_to_adrs3", OracleType.VarChar).Value = Audit.to_adrs3;
            dCmd.Parameters.Add("v_ref_frnumber", OracleType.VarChar).Value = Audit.ref_fromnumber;
            dCmd.Parameters.Add("v_ref_tonumber", OracleType.VarChar).Value = Audit.ref_tonumber;
            dCmd.Parameters.Add("v_note_date", OracleType.VarChar).Value = Audit.note_date;
            dCmd.Parameters.Add("v_note_subject", OracleType.VarChar).Value = Audit.note_subject;
            dCmd.Parameters.Add("v_orderdetails", OracleType.VarChar).Value = Audit.orderdetails;
            dCmd.Parameters.Add("v_orderby", OracleType.VarChar).Value = Audit.orderby;
            dCmd.Parameters.Add("v_status", OracleType.VarChar).Value = Audit.status;
            dCmd.Parameters.Add("v_updt_status", OracleType.VarChar).Value = Audit.updt_stat;
            dCmd.Parameters.Add("v_updt_by", OracleType.VarChar).Value = Audit.updt_by;
            dCmd.Parameters.Add("v_updt_date", OracleType.VarChar).Value = Audit.updt_date;

            dCmd.Parameters.Add("v_Action", OracleType.Char).Value = Audit.Action;
            dCmd.Parameters.Add("v_Result", OracleType.VarChar, 500).Direction = ParameterDirection.Output;
            try
            {
                dCmd.ExecuteNonQuery();
                return Convert.ToString(dCmd.Parameters["v_Result"].Value);
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

