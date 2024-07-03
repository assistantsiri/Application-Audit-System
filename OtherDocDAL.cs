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
   public class OtherDocDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();

        public OtherDocDAL()
        {

        }
        public Byte SaveUpdateDocupload(OtherDocBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("AAS_Other_FILES_UPDATION", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("V_ARF_REQ_SLNO", OracleType.Int32).Value = objbo.uploadSLno;
            dCmd.Parameters.Add("V_ARF_auditid", OracleType.Int32).Value = objbo.AuditId;
            dCmd.Parameters.Add("V_ARF_DOCDESC", OracleType.VarChar).Value = objbo.DocDesc;
            dCmd.Parameters.Add("V_ARF_DOCNAME", OracleType.VarChar).Value = objbo.Docname;
            dCmd.Parameters.Add("V_ARC_FILEPATH", OracleType.VarChar).Value = objbo.filepath;
            dCmd.Parameters.Add("V_ARF_UPDT_STAT", OracleType.VarChar).Value = objbo.UpdtStatus;
            dCmd.Parameters.Add("V_ARF_UPDT_BY", OracleType.VarChar).Value = objbo.UpdtdBy;
            dCmd.Parameters.Add("V_ARF_UPDT_DT", OracleType.VarChar).Value = objbo.UpdtdDt;
            dCmd.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
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
        public DataTable FetchUpload(OtherDocBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand(" select * from AAS_OTHER_FILES where AOF_AASAUDITID=" + objbo.AuditId + "  order by AOF_FILESRNUMBER  ", conn);
            dCmd.CommandType = CommandType.Text;
            OracleDataAdapter dAd = new OracleDataAdapter(dCmd);
            DataSet dSet = new DataSet();

            try
            {
                dAd.Fill(dSet, "AAS_OTHER_FILES");
                return dSet.Tables["AAS_OTHER_FILES"];
            }
            catch
            {
                throw;
            }
            finally
            {
                dSet.Dispose();
                dAd.Dispose();
                dCmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
        public DataTable GetDocumentname(OtherDocBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand(" select  AOF_UPLOADFILE from AAS_OTHER_FILES where AOF_AASAUDITID=" + objbo.AuditId + " and AOF_FILESRNUMBER =" + objbo.uploadSLno, conn);
            dCmd.CommandType = CommandType.Text;
            OracleDataAdapter dAd = new OracleDataAdapter(dCmd);
            DataSet dSet = new DataSet();

            try
            {
                dAd.Fill(dSet, "AAS_OTHER_FILES");
                return dSet.Tables["AAS_OTHER_FILES"];
            }
            catch
            {
                throw;
            }
            finally
            {
                dSet.Dispose();
                dAd.Dispose();
                dCmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
        public Byte DeleteDoc(OtherDocBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("delete from AAS_OTHER_FILES where AOF_AASAUDITID=" + objbo.AuditId + " and AOF_FILESRNUMBER =" + objbo.uploadSLno, conn);
            dCmd.CommandType = CommandType.Text;


            try
            {
                dCmd.ExecuteNonQuery();
                return 1;
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
        public Byte UpdateSLnoDelete(int slno)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("update aas_other_files set aof_filesrnumber=aof_filesrnumber - 1 where aof_filesrnumber >" + slno, conn);
            dCmd.CommandType = CommandType.Text;


            try
            {
                dCmd.ExecuteNonQuery();
                return 1;
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
        public DataTable FetchFileNo(OtherDocBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand(" select case when max(AOF_FILESRNUMBER)+1 is null then 0 else max(AOF_FILESRNUMBER)+1 end as AOF_FILESRNUMBER  from AAS_OTHER_FILES where AOF_AASAUDITID=" + objbo.AuditId, conn);
            dCmd.CommandType = CommandType.Text;
            OracleDataAdapter dAd = new OracleDataAdapter(dCmd);
            DataSet dSet = new DataSet();

            try
            {
                dAd.Fill(dSet, "AAS_OTHER_FILES");
                return dSet.Tables["AAS_OTHER_FILES"];
            }
            catch
            {
                throw;
            }
            finally
            {
                dSet.Dispose();
                dAd.Dispose();
                dCmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
