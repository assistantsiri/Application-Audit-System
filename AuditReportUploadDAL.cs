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
   public class AuditReportUploadDAL
    {
   string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();

   public AuditReportUploadDAL()
        {
        }

        public DataTable FetchAuditReportUpload(AuditReportUploadBO upload)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AuditReportUploadLoad", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_auditId", OracleType.Number).Value = upload.audit_id;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = upload.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "aas_audit_report_upload");
                return dSet.Tables["aas_audit_report_upload"];
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

        public String UpdateAuditReportUpload(AuditReportUploadBO upload)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("AuditReportUpdate", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("v_audit_id", OracleType.Number).Value = upload.audit_id;
            dCmd.Parameters.Add("v_filename", OracleType.VarChar).Value = upload.filename;
            dCmd.Parameters.Add("v_location", OracleType.VarChar).Value = upload.location;

            dCmd.Parameters.Add("v_status", OracleType.VarChar).Value = upload.status;
            dCmd.Parameters.Add("v_fileno", OracleType.Number).Value = upload.slno ;
            dCmd.Parameters.Add("v_updt_status", OracleType.VarChar).Value = upload.updt_stat;
            dCmd.Parameters.Add("v_updt_by", OracleType.VarChar).Value = upload.updt_by;
            dCmd.Parameters.Add("v_updt_date", OracleType.VarChar).Value = upload.updt_date;

            dCmd.Parameters.Add("v_Action", OracleType.Char).Value = upload.Action;
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

