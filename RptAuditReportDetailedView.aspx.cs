using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CrystalDecisions.Reporting.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using BO;
using BL;
using System.Windows.Forms;

public partial class RptAuditReportDetailedView : System.Web.UI.Page
{
    RptAuditReportDetailedBO objbo = new RptAuditReportDetailedBO();
    RptAuditReportDetailedBAL objbl = new RptAuditReportDetailedBAL();
    ReportDocument reportdoc = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                getrecords();
            }
            catch(Exception ex)
            {
                Globals.Show(ex.Message, "True");
            }
        }
    }

    public void getrecords()
    {
        ReportDocument subRepDoc = new ReportDocument();
        CrystalDecisions.CrystalReports.Engine.TextObject txtAuditID = default(CrystalDecisions.CrystalReports.Engine.TextObject);
        CrystalDecisions.CrystalReports.Engine.TextObject txtAppName = default(CrystalDecisions.CrystalReports.Engine.TextObject);
      
        //Modified BY shwetha on 28/09/2016

        CrystalDecisions.CrystalReports.Engine.TextObject txtStaffNo = default(CrystalDecisions.CrystalReports.Engine.TextObject);
        CrystalDecisions.CrystalReports.Engine.TextObject txtStaffName = default(CrystalDecisions.CrystalReports.Engine.TextObject); 
        CrystalDecisions.CrystalReports.Engine.TextObject txtAuditFromToDate = default(CrystalDecisions.CrystalReports.Engine.TextObject);
        
       
    
        //Start Nagarathna 14-02-2018
        CrystalDecisions.CrystalReports.Engine.TextObject txtAuditorNo = default(CrystalDecisions.CrystalReports.Engine.TextObject);
        CrystalDecisions.CrystalReports.Engine.TextObject txtAuditorName = default(CrystalDecisions.CrystalReports.Engine.TextObject);
        CrystalDecisions.CrystalReports.Engine.TextObject txtWing = default(CrystalDecisions.CrystalReports.Engine.TextObject);
        CrystalDecisions.CrystalReports.Engine.TextObject txtSection = default(CrystalDecisions.CrystalReports.Engine.TextObject);
        // End Nagarathna

      
        reportdoc.Load(Server.MapPath("R_Audit_Report_Detailed.rpt"));
        CRV.ReportSource = reportdoc;
        objbo.AUDITID = Convert.ToInt32(Session["VauditId"]);
        objbo.StaffNum = Session["StaffNum"].ToString();
        DataTable dTAuditFromToDate = new DataTable();
        DataTable dTAudit = new DataTable();
        DataTable tbl = new DataTable();
        dTAudit = objbl.FetchApplicationName(objbo);
        if (dTAudit.Rows.Count > 0)
        {
            Session["AppName"] = dTAudit.Rows[0]["arc_application_name"];
        }

             txtAuditID = reportdoc.ReportDefinition.ReportObjects["txtAuditID"] as TextObject;
             txtAppName = reportdoc.ReportDefinition.ReportObjects["txtAppName"] as TextObject;
             txtStaffNo = reportdoc.ReportDefinition.ReportObjects["txtStaffNo"] as TextObject;
             txtStaffName = reportdoc.ReportDefinition.ReportObjects["txtStaffName"] as TextObject;
             txtAuditFromToDate = reportdoc.ReportDefinition.ReportObjects["txtAuditFromToDate"] as TextObject;
            

            // Start by Nagarathna
             txtAuditorNo = reportdoc.ReportDefinition.ReportObjects["txtAuditorNo"] as TextObject;
             txtAuditorName = reportdoc.ReportDefinition.ReportObjects["txtAuditorName"] as TextObject;
             txtSection = reportdoc.ReportDefinition.ReportObjects["txtSection"] as TextObject;
             txtWing = reportdoc.ReportDefinition.ReportObjects["txtWing"] as TextObject;
           //  End 
      
            txtAuditID.Text = objbo.AUDITID.ToString();
            txtAppName.Text = Session["AppName"].ToString();
            txtStaffNo.Text = Session["StaffNum"].ToString();
            txtStaffName.Text = Session["StaffName"].ToString();
            txtWing.Text = Session["hdnWing"].ToString();

            dTAuditFromToDate = objbl.FetchAuditFromToDate(objbo);
            if (dTAuditFromToDate.Rows.Count > 0)
            {
                String Auditorname = dTAuditFromToDate.Rows[0]["AUM_STAFF_NAME"].ToString();
                String Auditorno = dTAuditFromToDate.Rows[0]["AAT_STAFFNUMBER"].ToString();
                String AuditFrom = dTAuditFromToDate.Rows[0]["APA_FROM_DATE"].ToString();
                String AuditTo = dTAuditFromToDate.Rows[0]["APA_TO_DATE"].ToString();
                String section = dTAuditFromToDate.Rows[0]["asm_sec_name"].ToString();
                txtAuditFromToDate.Text = "Audit period From " + AuditFrom + " " + "To " + AuditTo;
                txtAuditorNo.Text = Auditorno;
                txtAuditorName.Text = Auditorname;
                txtSection.Text = section;
      
              
            }

        RptAuditReportDetailedBO objbo_AR = new RptAuditReportDetailedBO();
        RptAuditReportDetailedBAL objbl_AR = new RptAuditReportDetailedBAL();
        DataTable dt_AR = new DataTable();
        objbo_AR.AUDITID = Convert.ToInt32(Session["VauditId"]);
        objbo.Action = "O";
        dt_AR = objbl.FetchRptAuditReportLoad(objbo);
        if (dt_AR.Rows.Count > 0)
        {
            subRepDoc = reportdoc.OpenSubreport("RptAuditReportDetailed.rpt");
            subRepDoc.SetDataSource(dt_AR);
            CRV.ReportSource = subRepDoc;
        }

        RptAuditReportDetailedBO objbo_CO = new RptAuditReportDetailedBO();
        RptAuditReportDetailedBAL objbl_CO = new RptAuditReportDetailedBAL();
        DataTable dt_CO = new DataTable();
        objbo_CO.AUDITID = Convert.ToInt32(Session["VauditId"]);
        dt_CO = objbl_CO.RptChecklistOthers(objbo_CO);
        if (dt_CO.Rows.Count > 0)
        {
            subRepDoc = reportdoc.OpenSubreport("R_Checklist_Others_Report.rpt");
            subRepDoc.SetDataSource(dt_CO);
            CRV.ReportSource = subRepDoc;
        }

        else
            subRepDoc = reportdoc.OpenSubreport("R_Checklist_Others_Report.rpt");
        subRepDoc.SetDataSource(dt_CO);
        CRV.ReportSource = subRepDoc;


        DataTable tb2 = new DataTable();
        objbo.AUDITID = Convert.ToInt32(Session["VauditId"]);
        tb2 = objbl.FetchRptAuditReportLoad1(objbo);
        if (tb2.Rows.Count > 0)
        {
            subRepDoc = reportdoc.OpenSubreport("RptAARGradation.rpt");
            subRepDoc.SetDataSource(tb2);
            CRV.ReportSource = subRepDoc;
        }
        ReportDesignconfig();
        CRV.DataBind();
        System.IO.Stream stream = reportdoc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        reportdoc.Dispose();

        try
        {
            byte[] PDFByteArray = new Byte[stream.Length];
            stream.Position = 0;
            stream.Read(PDFByteArray, 0, Convert.ToInt32(stream.Length));
            Context.Response.ClearContent();
            Context.Response.ClearHeaders();
            Context.Response.AddHeader("content-disposition", "filename=R_Audit_Report_Detailed.pdf");
            Context.Response.ContentType = "application/pdf";
            Context.Response.AddHeader("content-length", PDFByteArray.Length.ToString());
            Context.Response.BinaryWrite(PDFByteArray);
            Context.Response.Flush();
            Context.Response.End();
        }
        catch (Exception ee)
        {
            Globals.Show(ee.Message.ToString(), "");
        }
        finally
        {
            stream.Flush();
            stream.Close();
            stream.Dispose();
        }
    }
  
    private void ReportDesignconfig()
    {
        try
        {
            CRV.BestFitPage = true;
            CRV.ForeColor = System.Drawing.SystemColors.ControlText;
            CRV.PageToTreeRatio = 20;
            CRV.PageZoomFactor = 100;
            CRV.HasDrillUpButton = true;
            CRV.PageDrillUp();
            CRV.DisplayGroupTree = false;
            CRV.DisplayToolbar = true;
            CRV.HasGotoPageButton = true;
            CRV.HasPageNavigationButtons = true;
            CRV.HasZoomFactorList = false;
            CRV.HasSearchButton = true;
            CRV.HasExportButton = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        reportdoc.Close();
        reportdoc.Dispose();
        CRV.Dispose();
        GC.Collect();
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        reportdoc.Close();
        reportdoc.Dispose();
        CRV.Dispose();
        GC.Collect();
    }
    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {
    }

}
