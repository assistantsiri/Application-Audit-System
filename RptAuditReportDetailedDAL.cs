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
    public class RptAuditReportDetailedDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();
        public RptAuditReportDetailedDAL()
        {

        }
        public DataTable FetchRptAuditReportLoad(RptAuditReportDetailedBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("RPTAUDITREPORTDETAILED", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("V_AUDITID", OracleType.Int32).Value = objbo.AUDITID;
            dAd.SelectCommand.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "aas_checklist_details");
                return dSet.Tables["aas_checklist_details"];
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
        public DataTable FetchRptAuditReportLoad1(RptAuditReportDetailedBO objbo)
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

        public DataTable FetchAuditFromToDate(RptAuditReportDetailedBO objbo)
        {
            OracleConnection con = new OracleConnection(connStr);
            con.Open();
            //OracleCommand cmd = new OracleCommand("SELECT TO_CHAR(APA_FROM_DATE, 'DD-MM-YYYY') AS APA_FROM_DATE,TO_CHAR(APA_TO_DATE, 'DD-MM-YYYY') AS APA_TO_DATE FROM AAS_PLAN_AUDIT WHERE APA_AASAUDITID = " + objbo.AUDITID + " ", con);
            OracleCommand cmd = new OracleCommand("SELECT AAT_STAFFNUMBER,AUM_STAFF_NAME,asm_sec_name, TO_CHAR(APA.APA_FROM_DATE, 'DD-MM-YYYY') AS APA_FROM_DATE,TO_CHAR(APA.APA_TO_DATE, 'DD-MM-YYYY') AS APA_TO_DATE,TO_CHAR(ARC.ARC_REQUESTDATE, 'DD-MM-YYYY') AS REQUESTDATE FROM AAS_PLAN_AUDIT APA,AAS_REQ_COLLECTION ARC,AAS_AUDIT_TEAM AAT,AAS_SECTION_MAST ASM,aas_user_mast AUM WHERE APA.APA_AASAUDITID = AAT.AAT_AASAUDITID  AND APA.APA_REQ_COLLECTID = ARC.ARC_REQ_COLLECTID AND AAT.AAT_STAFFNUMBER = AUM.AUM_STAFF_NO AND ROWNUM = 1 AND AAT.AAT_AASAUDITID = " + objbo.AUDITID + " ", con);
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
        public DataTable FetchApplicationName(RptAuditReportDetailedBO objBO)
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
        public DataTable FetchAuditReport_Doc_Upload(RptAuditReportDetailedBO objBO)
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
        public DataTable RptChecklistOthers(RptAuditReportDetailedBO AuditChecklistOths)
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


        public DataTable FetchRptClosedAuditReportLoad(RptAuditReportDetailedBO objbo)
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


    }
}
