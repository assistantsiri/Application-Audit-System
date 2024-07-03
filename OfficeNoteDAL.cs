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
    public class OfficeNoteDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();

        public OfficeNoteDAL()
        {
        }

        public DataTable FetchOfficeNote(OfficeNoteBO Officenote)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("OfficeNoteLoad", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_auditId", OracleType.Number).Value = Officenote.audit_id;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = Officenote.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "aas_officenote_order");
                return dSet.Tables["aas_officenote_order"];
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

        public String UpdateOfficeNote(OfficeNoteBO Officenote)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("OfficeNoteUpdate", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("v_audit_id", OracleType.Number).Value = Officenote.audit_id;
            dCmd.Parameters.Add("v_from_adrs1", OracleType.VarChar).Value = Officenote.from_adrs1;
            dCmd.Parameters.Add("v_from_adrs2", OracleType.VarChar).Value = Officenote.from_adrs2;
            dCmd.Parameters.Add("v_from_adrs3", OracleType.VarChar).Value = Officenote.from_adrs3;
            dCmd.Parameters.Add("v_to_adrs1", OracleType.VarChar).Value = Officenote.to_adrs1;
            dCmd.Parameters.Add("v_to_adrs2", OracleType.VarChar).Value = Officenote.to_adrs2;
            dCmd.Parameters.Add("v_to_adrs3", OracleType.VarChar).Value = Officenote.to_adrs3;
            dCmd.Parameters.Add("v_ref_number", OracleType.VarChar).Value = Officenote.ref_number;
            dCmd.Parameters.Add("v_note_date", OracleType.VarChar).Value = Officenote.note_date;
            dCmd.Parameters.Add("v_note_subject", OracleType.VarChar).Value = Officenote.note_subject;
            dCmd.Parameters.Add("v_present_proposal", OracleType.VarChar).Value = Officenote.present_proposal;
            dCmd.Parameters.Add("v_background", OracleType.VarChar).Value = Officenote.background;
            dCmd.Parameters.Add("v_recommendations", OracleType.VarChar).Value = Officenote.recommendations;
            dCmd.Parameters.Add("v_submitted_oredr", OracleType.VarChar).Value = Officenote.submitted_oredr;
            dCmd.Parameters.Add("v_dm_view", OracleType.VarChar).Value = Officenote.dm_view;
            dCmd.Parameters.Add("v_dgm_order", OracleType.VarChar).Value = Officenote.dgm_order;
            dCmd.Parameters.Add("v_orderby", OracleType.VarChar).Value = Officenote.orderby;


            dCmd.Parameters.Add("v_status", OracleType.VarChar).Value = Officenote.status;
            dCmd.Parameters.Add("v_updt_status", OracleType.VarChar).Value = Officenote.updt_stat;
            dCmd.Parameters.Add("v_updt_by", OracleType.VarChar).Value = Officenote.updt_by;
            dCmd.Parameters.Add("v_updt_date", OracleType.VarChar).Value = Officenote.updt_date;

            dCmd.Parameters.Add("v_Action", OracleType.Char).Value = Officenote.Action;
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
