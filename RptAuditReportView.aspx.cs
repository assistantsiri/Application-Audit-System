//   ****************************************************************
//    AAS CURRENT VERSION   : 1.0 BASELINED VERSION
//    DATED                 : 03-Aug-2016
//    AUTHOR                : Kirthi 
//    Page                  : RptAuditReportView.aspx
//   ----------------------------------------------------------------
//   SL NO.  DATE    MODIFIED BY     REASON                 VERSION
//   ----------------------------------------------------------------
//  1       24-01-2017  kirthi      to execute pdf file in DIT server
//
//
//
//   ****************************************************************
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

public partial class RptAuditReportView : System.Web.UI.Page
{
    ReportDocument reportdoc = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            getreport();
        }
        catch (Exception ex)
        {
            Globals.Show(ex.Message.ToString(), "");
        }

    }
    private void getreport()
    {
        CrystalDecisions.CrystalReports.Engine.TextObject txtAuditID = default(CrystalDecisions.CrystalReports.Engine.TextObject);
        CrystalDecisions.CrystalReports.Engine.TextObject txtAppName = default(CrystalDecisions.CrystalReports.Engine.TextObject);
     
        //Modified BY shwetha on 28/09/2016
        
        CrystalDecisions.CrystalReports.Engine.TextObject txtStaffNo = default(CrystalDecisions.CrystalReports.Engine.TextObject);
        CrystalDecisions.CrystalReports.Engine.TextObject txtStaffName = default(CrystalDecisions.CrystalReports.Engine.TextObject);
       
        CrystalDecisions.CrystalReports.Engine.TextObject txtAuditFromToDate = default(CrystalDecisions.CrystalReports.Engine.TextObject);
        CrystalDecisions.CrystalReports.Engine.TextObject txtAuditClosureDt = default(CrystalDecisions.CrystalReports.Engine.TextObject);
     
        //Modified BY shwetha on 28/09/2016
        //Start Kirthi 03-06-2017
        //CrystalDecisions.CrystalReports.Engine.TextObject txtReqDate = default(CrystalDecisions.CrystalReports.Engine.TextObject);       
        //End Kirthi 03-06-2017

        //Start By Nagarathna 
        CrystalDecisions.CrystalReports.Engine.TextObject txtAuditComplte = default(CrystalDecisions.CrystalReports.Engine.TextObject);
        CrystalDecisions.CrystalReports.Engine.TextObject txtWing = default(CrystalDecisions.CrystalReports.Engine.TextObject);

        //Modified by Nagarathna on 10-12-2018
        CrystalDecisions.CrystalReports.Engine.TextObject txtSection = default(CrystalDecisions.CrystalReports.Engine.TextObject);

        //End By Nagarathna

        RptAuditReportBO objbo = new RptAuditReportBO();
        RptAuditReportBAL objbl = new RptAuditReportBAL();
        DataTable dTAuditFromToDate = new DataTable();

        objbo.AUDITID = Convert.ToInt32(Session["VauditId"]);
        objbo.StaffNum = (Session["StaffNum"]).ToString();
        
        DataTable dTAudit = new DataTable();

        dTAudit = objbl.FetchApplicationName(objbo);
        if (dTAudit.Rows.Count > 0)
        {
            Session["AppName"] = dTAudit.Rows[0]["arc_application_name"];
          
        }
       
        objbo.Action = "O";

        DataTable tbl = new DataTable();
        tbl = objbl.FetchRptAuditReportLoad(objbo);
       
        if (tbl.Rows.Count > 0)
        {

            reportdoc.Load(Server.MapPath("RptAuditReport.rpt"));
            reportdoc.SetDataSource(tbl);
            CrystalReportViewer1.ReportSource = reportdoc;
            txtAuditID = reportdoc.ReportDefinition.ReportObjects["txtAuditID"] as TextObject;
            txtAppName = reportdoc.ReportDefinition.ReportObjects["txtAppName"] as TextObject;

            //Modified BY shwetha on 28/09/2016
            txtStaffNo = reportdoc.ReportDefinition.ReportObjects["txtStaffNo"] as TextObject;
            txtStaffName = reportdoc.ReportDefinition.ReportObjects["txtStaffName"] as TextObject;
            txtAuditFromToDate = reportdoc.ReportDefinition.ReportObjects["txtAuditFromToDate"] as TextObject;
            txtAuditClosureDt = reportdoc.ReportDefinition.ReportObjects["txtAuditClosureDt"] as TextObject;
            // End 

            // Added By Nagarathna
            txtAuditComplte = reportdoc.ReportDefinition.ReportObjects["txtAuditComplte"] as TextObject;
            txtWing = reportdoc.ReportDefinition.ReportObjects["txtWing"] as TextObject;
            //Modified by Nagarathna on 10-12-2018
            txtSection = reportdoc.ReportDefinition.ReportObjects["txtSection"] as TextObject;
            // End 

            //Start Kirthi 03-06-2017

            //End Kirthi 03-06-2017

            txtAuditID.Text = objbo.AUDITID.ToString();
           

            // Modified By Nagarathna on 15-02-2018
             txtWing.Text = Session["hdnWing"].ToString();
            // End
             txtAppName.Text = Session["AppName"].ToString();
             dTAuditFromToDate = objbl.FetchAuditFromToDate(objbo);
            if (dTAuditFromToDate.Rows.Count > 0)
            {
                String StaffNo = dTAuditFromToDate.Rows[0]["AAT_STAFFNUMBER"].ToString();
                String StaffName = dTAuditFromToDate.Rows[0]["AUM_STAFF_NAME"].ToString();
                String AuditFrom = dTAuditFromToDate.Rows[0]["APA_FROM_DATE"].ToString();
                String AuditTo = dTAuditFromToDate.Rows[0]["APA_TO_DATE"].ToString();
                String CompleteDate = dTAuditFromToDate.Rows[0]["APA_TO_DATE"].ToString();
                //Modified by Nagarathna on 10-12-2018
                String Section = dTAuditFromToDate.Rows[0]["asm_sec_name"].ToString();              
                //
                txtAuditFromToDate.Text = "Audit period From " + AuditFrom + " " + "To " + AuditTo;
                txtAuditClosureDt.Text = AuditTo;
                txtStaffNo.Text = StaffNo;
                txtStaffName.Text = StaffName;
                txtAuditComplte.Text = CompleteDate;
                //Modified by Nagarathna on 10-12-2018
                txtSection.Text = Section;
                //
            
            }
         
            CrystalReportViewer1.DataBind();
            System.IO.Stream stream = reportdoc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            reportdoc.Dispose();

            try
            {
                byte[] PDFByteArray = new Byte[stream.Length];
                stream.Position = 0;
                stream.Read(PDFByteArray, 0, Convert.ToInt32(stream.Length));
                Context.Response.ClearContent();
                Context.Response.ClearHeaders();
                Context.Response.AddHeader("content-disposition", "filename=R_Audit_Report.pdf");
                Context.Response.ContentType = "application/pdf";
                Context.Response.AddHeader("content-length", PDFByteArray.Length.ToString());
                Context.Response.BinaryWrite(PDFByteArray);
                Context.Response.Flush();
                Context.Response.End();
                if ((Convert.ToInt32(Session["DeptId"])) == 1 && (Convert.ToInt32(Session["RoleId"]) == 1))
                {
                    Session["V_auditId"] = null;
                }
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
        else
            Globals.Show("No Records....!!!", "Close");
        objbl = null;
        objbo = null;
        tbl.Dispose();
    }
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        reportdoc.Close();
        reportdoc.Dispose();
        CrystalReportViewer1.Dispose();
        GC.Collect();
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        reportdoc.Close();
        reportdoc.Dispose();
        CrystalReportViewer1.Dispose();
        GC.Collect();
    }
}


//    private void ReportDesignconfig()
//{
//    try {
//        CrystalReportViewer1.BestFitPage = true;
//        CrystalReportViewer1.ForeColor = System.Drawing.SystemColors.ControlText;
//        CrystalReportViewer1.PageToTreeRatio = 20;
//        CrystalReportViewer1.PageZoomFactor = 100;
//        CrystalReportViewer1.HasDrillUpButton = true;
//        CrystalReportViewer1.PageDrillUp();
//        CrystalReportViewer1.DisplayGroupTree = false;
//        CrystalReportViewer1.DisplayToolbar = true;
//        CrystalReportViewer1.HasGotoPageButton = true;
//        CrystalReportViewer1.HasPageNavigationButtons = true;
//        CrystalReportViewer1.HasZoomFactorList = false;
//        CrystalReportViewer1.HasSearchButton = true;
//        CrystalReportViewer1.HasExportButton = true;
//    } catch (Exception ex) {
//        throw ex;
//    }
//}
//public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
//{
//}
