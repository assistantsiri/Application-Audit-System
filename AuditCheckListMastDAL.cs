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
    public class AuditCheckListMastDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();

        public DataTable LoadCheckListMast(AuditCheckListMastBO AuditCheckListMast)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_AuditCheckListMastLoad", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_GRPCODE", OracleType.Int32).Value = AuditCheckListMast.GrpCode;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = AuditCheckListMast.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AAS_CHECKLIST_MAST");
                return dSet.Tables["AAS_CHECKLIST_MAST"];
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
        public DataTable FetchNewGrpCode(AuditCheckListMastBO AuditCheckListMast)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_AuditCheckListMastLoad", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_GRPCODE", OracleType.Int32).Value = AuditCheckListMast.GrpCode;            
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = AuditCheckListMast.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AAS_CHECKLIST_MAST");
                return dSet.Tables["AAS_CHECKLIST_MAST"];
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
        public Byte UpdtCheckListMast(AuditCheckListMastBO AuditCheckListMast)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AAS_AuditCheckListMastUpdt", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_GRPCODE", OracleType.Int32).Value = AuditCheckListMast.GrpCode;
            dAd.SelectCommand.Parameters.Add("V_ITEMCODE", OracleType.Int32).Value = AuditCheckListMast.ItemCode;
            dAd.SelectCommand.Parameters.Add("V_ITEMDESC", OracleType.VarChar).Value = AuditCheckListMast.ItemDescr;
            dAd.SelectCommand.Parameters.Add("V_GRPINDEX", OracleType.Int16).Value = AuditCheckListMast.GrpIndex;
            dAd.SelectCommand.Parameters.Add("V_PROMPT", OracleType.Int16).Value = AuditCheckListMast.Prompt;
            dAd.SelectCommand.Parameters.Add("V_MARKS", OracleType.Int16).Value = AuditCheckListMast.Marks;
            dAd.SelectCommand.Parameters.Add("V_STATUS", OracleType.VarChar).Value = AuditCheckListMast.Status;
            dAd.SelectCommand.Parameters.Add("V_UPDTBY", OracleType.VarChar).Value = AuditCheckListMast.UpdtBy;
            dAd.SelectCommand.Parameters.Add("V_UPDTDT", OracleType.VarChar).Value = AuditCheckListMast.UpdtDt;
            dAd.SelectCommand.Parameters.Add("V_ACTION", OracleType.Char).Value = AuditCheckListMast.Action;
            dAd.SelectCommand.Parameters.Add("v_RESULT", OracleType.Byte).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.SelectCommand.ExecuteNonQuery();
                return Convert.ToByte(dAd.SelectCommand.Parameters["v_Result"].Value);
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
