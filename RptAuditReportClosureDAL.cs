using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
namespace DA
{
   public  class RptAuditReportClosureDAL
    {
       string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
       public RptAuditReportClosureDAL()
       {

       }

       public DataTable FetchRptAuditReportLoad(RptAuditReportClosureBO objbo)
       {
           OracleConnection conn = new OracleConnection(connStr);
           conn.Open();
           OracleDataAdapter dAd = new OracleDataAdapter("RPTAUDITREPORTCLOSURE", conn);
           dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
           dAd.SelectCommand.Parameters.Add("V_AUDITID", OracleType.Int32).Value = objbo.AUDITID;
           dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
           dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
           DataSet dSet = new DataSet();
           try
           {
               dAd.Fill(dSet, "RPTAUDITREPORT");
               return dSet.Tables["RPTAUDITREPORT"];
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

       public DataTable FetchApplicationName(RptAuditReportClosureBO objBO)
       {
           OracleConnection con = new OracleConnection(connStr);
           con.Open();
           //OracleCommand cmd = new OracleCommand("SELECT a.aat_staffnumber,c.arc_application_name FROM AAS_AUDIT_TEAM a , aas_req_collection c WHERE  a.aat_reqcollectid=c.arc_req_collectid and aat_engagestatus='I'  AND AAT_STAFFNUMBER='" + objBO.StaffNum + "'", con);
           OracleCommand cmd = new OracleCommand("select ARC_APPLICATION_NAME from aas_req_collection where ARC_AASAUDIT_ID='" + objBO.AUDITID + "'", con);
           cmd.CommandType = CommandType.Text;
           OracleDataAdapter da = new OracleDataAdapter(cmd);
           DataSet ds = new DataSet();
           try
           {
               da.Fill(ds, "AAS_AUDIT_TEAM");
               return ds.Tables["AAS_AUDIT_TEAM"];
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

       public DataTable FetchAuditFromToDate(RptAuditReportClosureBO objbo)
       {
           OracleConnection con = new OracleConnection(connStr);
           con.Open();
           //OracleCommand cmd = new OracleCommand("SELECT TO_CHAR(APA_FROM_DATE, 'DD-MM-YYYY') AS APA_FROM_DATE,TO_CHAR(APA_TO_DATE, 'DD-MM-YYYY') AS APA_TO_DATE FROM AAS_PLAN_AUDIT WHERE APA_AASAUDITID = " + objbo.AUDITID + " ", con);
           OracleCommand cmd = new OracleCommand("SELECT AAT_STAFFNUMBER,AUM_STAFF_NAME,asm_sec_name, TO_CHAR(A.APA_FROM_DATE, 'DD-MM-YYYY') AS APA_FROM_DATE,TO_CHAR(A.APA_TO_DATE, 'DD-MM-YYYY') AS APA_TO_DATE, TO_CHAR(B.ARC_REQUESTDATE, 'DD-MM-YYYY') AS REQUESTDATE FROM AAS_PLAN_AUDIT A , AAS_REQ_COLLECTION B, aas_audit_team C,AAS_SECTION_MAST S, aas_user_mast D where s.asm_main_code = D.aum_dept and s.asm_sec_code  = D.aum_section and D.AUM_STAFF_NO in(select AAT_STAFFNUMBER from aas_audit_team C where C.AAT_AASAUDITID =" + objbo.AUDITID + " and rownum=1) AND A.APA_AASAUDITID=B.ARC_AASAUDIT_ID AND A.APA_AASAUDITID = C.AAT_AASAUDITID AND A.APA_REQ_COLLECTID=B.ARC_REQ_COLLECTID AND C.AAT_STAFFNUMBER=D.AUM_STAFF_NO AND A.APA_AASAUDITID = " + objbo.AUDITID + " ", con);
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


       public DataTable FetchRptAuditReportLoad1(RptAuditReportClosureBO objbo)
       {
           OracleConnection conn = new OracleConnection(connStr);
           conn.Open();
           OracleDataAdapter dAd = new OracleDataAdapter("AAS_CombinedRiskRating", conn);
           dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
           dAd.SelectCommand.Parameters.Add("auditid", OracleType.Int32).Value = objbo.AUDITID;
           //dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
           dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
           DataSet dSet = new DataSet();
           try
           {
               dAd.Fill(dSet, "RPTAUDITREPORT");
               return dSet.Tables["RPTAUDITREPORT"];
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

       public DataTable RptChecklistOthers(RptAuditReportClosureBO AuditChecklistOths)
       {
           OracleConnection conn = new OracleConnection(connStr);
           conn.Open();
           OracleDataAdapter dAd = new OracleDataAdapter("RPT_CHECKLISTOTHERS", conn);
           dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
           dAd.SelectCommand.Parameters.Add("V_AUDITID", OracleType.Char).Value = AuditChecklistOths.AUDITID;
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


       public DataTable FetchRptClosedAuditReportLoad(RptAuditReportClosureBO objbo)
       {
           OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("RPTCLOSEDAUDITREPORT", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AAS_PLAN_AUDIT");
                return dSet.Tables["AAS_PLAN_AUDIT"];
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

       public DataTable FetchAuditReport_Doc_Upload(RptAuditReportClosureBO objBO)
       {
           OracleConnection con = new OracleConnection(connStr);
           con.Open();
           OracleCommand cmd = new OracleCommand("select t.aaru_aasauditid,t.aaru_report_file_name,case when t.aaru_report_location is not null then 'D:/Kirthi Daily Work/02-Jun-2017/AAS/AAS' || LTRIM(t.aaru_report_location,'~') end aaru_report_location,t.aaru_status,t.aaru_updt_stat,t.aaru_updt_by,t.aaru_updt_dt from aas_audit_report_upload t where t.aaru_aasauditid='" + objBO.AUDITID + "'", con);

           cmd.CommandType = CommandType.Text;
           OracleDataAdapter da = new OracleDataAdapter(cmd);
           DataSet ds = new DataSet();
           try
           {
               da.Fill(ds, "AAS_AUDIT_TEAM");
               return ds.Tables["AAS_AUDIT_TEAM"];
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
    }
    }

