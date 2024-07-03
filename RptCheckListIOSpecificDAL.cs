using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using System.Data;
using System.Configuration;
using System.Data.OracleClient;

namespace DA
{
   public class RptCheckListIOSpecificDAL
    {
       string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
       public RptCheckListIOSpecificDAL()
       {

       }
       public DataTable FetchApplicationName(RptCheckListIOSpecificBO chckListIoSpecificBO)
       {
           OracleConnection conn = new OracleConnection(connStr);
           conn.Open();
           OracleDataAdapter dAd = new OracleDataAdapter("RPTCHKLISTIOSPECIFIC", conn);
           dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
           dAd.SelectCommand.Parameters.Add("V_AUDITID", OracleType.Int32).Value = chckListIoSpecificBO.Action;
           dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = chckListIoSpecificBO.Action;
           dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
           DataSet dSet = new DataSet();
           try
           {
               dAd.Fill(dSet, "AAS_CHECKLIST_OTHERS");
               return dSet.Tables["AAS_CHECKLIST_OTHERS"];
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
       public DataTable FetchAuditFromToDate(RptCheckListIOSpecificBO chckListIoSpecificBO)
       {
           OracleConnection con = new OracleConnection(connStr);
           con.Open();
           OracleCommand cmd = new OracleCommand("SELECT AAT_STAFFNUMBER,AUM_STAFF_NAME,asm_sec_name, TO_CHAR(APA.APA_FROM_DATE, 'DD-MM-YYYY') AS APA_FROM_DATE,TO_CHAR(APA.APA_TO_DATE, 'DD-MM-YYYY') AS APA_TO_DATE,TO_CHAR(ARC.ARC_REQUESTDATE, 'DD-MM-YYYY') AS REQUESTDATE FROM AAS_PLAN_AUDIT APA,AAS_REQ_COLLECTION ARC,AAS_AUDIT_TEAM AAT,AAS_SECTION_MAST ASM,aas_user_mast AUM WHERE APA.APA_AASAUDITID = AAT.AAT_AASAUDITID  AND APA.APA_REQ_COLLECTID = ARC.ARC_REQ_COLLECTID AND AAT.AAT_STAFFNUMBER = AUM.AUM_STAFF_NO AND ROWNUM = 1 AND AAT.AAT_AASAUDITID = " + chckListIoSpecificBO.AuditID + " ", con);
           cmd.CommandType = CommandType.Text;
           OracleDataAdapter da = new OracleDataAdapter(cmd);
           DataSet ds = new DataSet();
           try
           {
               da.Fill(ds, "AAS_PLAN_AUDIT");
               return ds.Tables["AAS_PLAN_AUDIT"];
           }
           catch
           {
               throw;
           }
           finally
           {
               ds.Dispose();
               da.Dispose();
               cmd.Dispose();
               con.Close();
               con.Dispose();
           }
       }
       public DataTable FetchCheckListIOSpecificRpt(RptCheckListIOSpecificBO chckListIoSpecificBO)
       {
           OracleConnection conn = new OracleConnection(connStr);
           conn.Open();
           OracleDataAdapter dAd = new OracleDataAdapter("RPTCHKLISTIOSPECIFIC", conn);
           dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
           dAd.SelectCommand.Parameters.Add("V_AUDITID", OracleType.Int32).Value = chckListIoSpecificBO.AuditID;
           dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = chckListIoSpecificBO.Action;
           dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
           DataSet dSet = new DataSet();
           try
           {
               dAd.Fill(dSet, "AAS_CHECKLIST_OTHERS");
               return dSet.Tables["AAS_CHECKLIST_OTHERS"];
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
