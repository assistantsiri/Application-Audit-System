using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BL;
using BO;
using System.Data;
using System.Web.UI.WebControls;

public partial class CheckListStatus : System.Web.UI.Page
{
    //Added By Nagarathna
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["TxtRemarkNew"] != null)
        {
            TextBox txtObservation = (TextBox)gvCheckListStatus.Rows[Convert.ToInt32(Session["TxtRemarkIndex"])].FindControl("txtObservation");
            txtObservation.Text = Session["TxtRemarkNew"].ToString();
            txtObservation.Focus();
            HiddenField hdnEditFalg = (HiddenField)gvCheckListStatus.Rows[Convert.ToInt32(Session["TxtRemarkIndex"])].FindControl("hdnEditFalg");
            hdnEditFalg.Value = "Y";
            Session["TxtRemarkNew"] = null;
        }


        if (Session["TxtReplyNew"] != null)
        {
            TextBox txtReply = (TextBox)gvCheckListStatus.Rows[Convert.ToInt32(Session["TxtReplyIndex"])].FindControl("txtReply");
            txtReply.Text = Session["TxtReplyNew"].ToString();
            txtReply.Focus();
            HiddenField hdnEditFalg = (HiddenField)gvCheckListStatus.Rows[Convert.ToInt32(Session["TxtReplyIndex"])].FindControl("hdnEditFalg");
            hdnEditFalg.Value = "Y";
            Session["TxtReplyNew"] = null;
        }
        if (!IsPostBack)
        {
            ViewState["DeptId"] = Convert.ToInt32(Session["DeptId"].ToString());
            if (Convert.ToInt32(Session["VauditId"].ToString()) != 0)
            {
                ViewState["AuditId"] = Convert.ToInt32(Session["VauditId"].ToString());
            }
            pnlGridChklstStatusDetails.Visible = false;
        }
        BindGrid();
        //Added on 10-12-2018
        lblAudit.Text = Session["Auditid"].ToString();
        lblApplication.Text = Session["AppName"].ToString();
        lblGroups.Visible = false;
        //End
    }
    private void BindGrid()
    {
        AuditStatusBAL objbl = new AuditStatusBAL();
        AuditStatusBO objbo = new AuditStatusBO();
        DataTable dt = new DataTable();        
        objbo.AuditId = Convert.ToInt32(Session["Auditid"]);
        objbo.Section = Session["Section"].ToString();
        objbo.roleid = Convert.ToInt16(Session["RoleId"]);
        objbo.deptid = Convert.ToInt16(Session["DeptId"]);
        objbo.Action = "ST";
        dt = objbl.FetchAuditCheckListStatus(objbo);
        if (dt.Rows.Count > 0)
        {
            dlCheckListStatus.DataSource = dt;
            dlCheckListStatus.DataBind();
        }
        else
        {
            Globals.Show("No Records!!!");
        }
    }

    protected void dlCheckListStatus_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblSection = (Label)e.Item.FindControl("lblSections");
            Label lblslNo = (Label)e.Item.FindControl("lblSlNo");
            LinkButton lnkselect = (LinkButton)e.Item.FindControl("lnkSelect");
            LinkButton lnkTotobs = (LinkButton)e.Item.FindControl("lnkTotOBS");
            LinkButton lnkech = (LinkButton)e.Item.FindControl("lnkECH");
            LinkButton lnkpending = (LinkButton)e.Item.FindControl("lnkPending");
            LinkButton lnkreplied = (LinkButton)e.Item.FindControl("lnkReplied");
            LinkButton lnkaccept = (LinkButton)e.Item.FindControl("lnkAccept");
            LinkButton lnkdeny = (LinkButton)e.Item.FindControl("lnkDeny");
            if (lblSection.Text == "TOTAL")
            {
                lblslNo.Text = "";
                lnkselect.Enabled = false;
                lnkTotobs.Enabled = false;
                lnkech.Enabled = false;
                lnkpending.Enabled = false;
                lnkreplied.Enabled = false;
                lnkaccept.Enabled = false;
                lnkdeny.Enabled = false;
            }

        }
    }
    private void clear()
    {
        gvCheckListStatus.DataSource = null;
        gvCheckListStatus.DataBind();
        Msg.Text = "";
    }

    protected void dlCheckListStatus_ItemCommand(object source, DataListCommandEventArgs e)
    {
        AuditStatusBAL objbl = new AuditStatusBAL();
        AuditStatusBO objbo = new AuditStatusBO();
        DataTable dt = new DataTable();
        pnlGridChklstStatusDetails.Visible = true;
        ViewState["GRP_CODE"] = ((System.Web.UI.WebControls.Label)dlCheckListStatus.Items[e.Item.ItemIndex].FindControl("lblMainCode")).Text;
        //Added on 10-12-2018
        lblGroups.Visible = true;
        ViewState["GroupName"] = ((System.Web.UI.WebControls.Label)dlCheckListStatus.Items[e.Item.ItemIndex].FindControl("lblSections")).Text;
        lblGroups.Text = ViewState["GroupName"].ToString();
        //End
        objbo.AuditId = Convert.ToInt32(Session["Auditid"]);
        objbo.Section = Session["Section"].ToString();
        objbo.roleid = Convert.ToInt16(Session["RoleId"]);
        objbo.deptid = Convert.ToInt16(Session["DeptId"]);
        try
        {
            clear();
            if (e.CommandName == "Select")
            {
                ViewState["CommandName"] = "Select";
            }
            else if (e.CommandName == "TOTOBS")
            {
                ViewState["CommandName"] = "TOTOBS";
            }
            else if (e.CommandName == "ECH")
            {
                ViewState["CommandName"] = "ECH";
            }
            else if (e.CommandName == "Pending")
            {
                ViewState["CommandName"] = "Pending";
            }
            else if (e.CommandName == "Reply")
            {
                ViewState["CommandName"] = "Reply";
            }
            else if (e.CommandName == "Accept")
            {
                ViewState["CommandName"] = "Accept";
            }
            else if (e.CommandName == "Deny")
            {
                ViewState["CommandName"] = "Deny";
            }
            BindCheckList();
        }
        catch (Exception ee)
        {
            Globals.Show(ee.Message.ToString());
        }
    }
    private void BindCheckList()
    {
        AuditStatusBAL objbl = new AuditStatusBAL();
        AuditStatusBO objbo = new AuditStatusBO();
        DataTable dTable = new DataTable();
        btnCancel.Visible = true;
        objbo.AuditId = Convert.ToInt32(Session["Auditid"]);
        objbo.GroupCode = Convert.ToInt32(ViewState["GRP_CODE"]);
        try
        {
            string CommandName = ViewState["CommandName"].ToString();

            if (CommandName == "Select")
            {
                objbo.Status = "I";
            }
            else if (CommandName == "TOTOBS")
            {
                objbo.Status = "O";
            }
            else if (CommandName == "ECH")
            {
                objbo.Status = "E";
            }
            else if (CommandName == "Pending")
            {
                objbo.Status = "P";
            }
            else if (CommandName == "Reply")
            {
                objbo.Status = "R";
            }
            else if (CommandName == "Accept")
            {
                objbo.Status = "AC";
            }
            else if (CommandName == "Deny")
            {
                objbo.Status = "DE";
            }
            objbo.Action = "Q";
            dTable = objbl.FetchCheckListData(objbo);
            if (dTable.Rows.Count > 0)
            {
                gvCheckListStatus.DataSource = dTable;
                gvCheckListStatus.DataBind();

            }
            else
            {
                Globals.Show("No Records...");
            }
        }
        catch (Exception ee)
        {
            Globals.Show(ee.Message.ToString());
        }
        finally
        {
            objbl = null;
            objbo = null;
            dTable = null;
        }
    }

    protected void gvCheckListStatus_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataRowView drview = e.Row.DataItem as DataRowView;
            pnlGridChklstStatusDetails.Visible = true;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RadioButtonList rblApplicable = (RadioButtonList)e.Row.FindControl("rblApplicable");
                RadioButtonList rblDeviated = (RadioButtonList)e.Row.FindControl("rblDeviated");
                DropDownList ddlRisk = (DropDownList)e.Row.FindControl("ddlRisk");
                TextBox txtObservation = (TextBox)e.Row.FindControl("txtObservation");
                TextBox txtReply = (TextBox)e.Row.FindControl("txtReply");
                ImageButton imgViewReply = (ImageButton)e.Row.FindControl("imgViewReply");
                RadioButtonList rblAcceptDeny = (RadioButtonList)e.Row.FindControl("rblAcceptDeny");
                TextBox tbRemarks = (TextBox)e.Row.FindControl("tbRemarks");
                Label lblReplyStatus = (Label)e.Row.FindControl("lblReplyStatus");
                LinkButton lnkVerify = (LinkButton)e.Row.FindControl("lnkVerify");
                ImageButton imgEditReply = (ImageButton)e.Row.FindControl("imgEditReply");
                ImageButton imgReply = (ImageButton)e.Row.FindControl("imgReply");

                if (drview[12].ToString() == "0")
                {
                    rblApplicable.Visible = false;
                    rblDeviated.Visible = false;
                    ddlRisk.Visible = false;
                    txtObservation.Visible = false;
                    txtReply.Visible = false;
                    imgViewReply.Visible = false;
                    rblAcceptDeny.Visible = false;
                    tbRemarks.Visible = false;
                    imgEditReply.Visible = false;
                    imgReply.Visible = false;

                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Blue;
                    e.Row.Cells[1].Font.Bold = true;
                    e.Row.Cells[0].ForeColor = System.Drawing.Color.Blue;
                    e.Row.Cells[0].Font.Bold = true;
                }
                else
                {
                    if (drview[5].ToString() == "Y" || drview[5].ToString() == "N") rblApplicable.SelectedValue = drview[5].ToString();
                    else rblApplicable.ClearSelection();

                    if (drview[6].ToString() == "Y" || drview[6].ToString() == "N") rblDeviated.SelectedValue = drview[6].ToString();
                    else rblDeviated.ClearSelection();

                    if (drview[7].ToString() == "E" || drview[7].ToString() == "C" || drview[7].ToString() == "H" || drview[7].ToString() == "O") ddlRisk.SelectedValue = drview[7].ToString();
                    else ddlRisk.ClearSelection();

                    if (drview[10].ToString() == "A" || drview[10].ToString() == "D") rblAcceptDeny.SelectedValue = drview[10].ToString();
                    else rblAcceptDeny.ClearSelection();


                    if (drview[5].ToString() == "N")
                    {
                        rblApplicable.Enabled = false;
                        rblDeviated.Enabled = false;
                        ddlRisk.Enabled = false;
                        txtObservation.Enabled = false;
                        txtReply.Enabled = false;
                        imgViewReply.Enabled = false;
                        rblAcceptDeny.Enabled = false;
                        tbRemarks.Enabled = false;
                        imgEditReply.Enabled = false;
                        imgReply.Enabled = false;
                        lnkVerify.Enabled = false;
                        lnkVerify.Visible = false;
                    }


                    if (drview[7].ToString() == "O" || drview[10].ToString() == "A")
                    {
                        txtReply.Enabled = false;
                        imgViewReply.Enabled = false;
                        imgEditReply.Enabled = false;
                        imgReply.Enabled = false;
                    }

                    rblApplicable.Visible = true;
                    rblDeviated.Visible = true;
                    ddlRisk.Visible = true;
                    txtObservation.Visible = true;
                    txtReply.Visible = true;
                    imgViewReply.Visible = true;
                    rblAcceptDeny.Visible = true;
                    tbRemarks.Visible = true;
                    imgEditReply.Visible = true;
                    imgReply.Visible = true;
                }

                if ((Convert.ToInt16(Session["RoleId"].ToString()) == 1 && Convert.ToInt16(Session["DeptId"].ToString()) == 1))  
                {
                    rblApplicable.Enabled = false;
                    rblDeviated.Enabled = false;
                    ddlRisk.Enabled = false;
                    txtObservation.Enabled = false;
                    txtReply.Enabled = false;
                    if (txtReply.Text != "")
                    {
                        if (lblReplyStatus.Text == "A")
                        {
                            rblAcceptDeny.Enabled = true;
                            tbRemarks.Enabled = true;
                            tbRemarks.Text = "";
                            if (rblAcceptDeny.SelectedValue == "D")
                            {
                                rblAcceptDeny.ClearSelection();
                                tbRemarks.Text = "";
                            }
                            else if (rblAcceptDeny.SelectedValue == "A")
                            {
                                rblApplicable.Enabled = false;
                                rblDeviated.Enabled = false;
                                ddlRisk.Enabled = false;
                                txtObservation.Enabled = false;
                                txtReply.Enabled = false;
                                rblAcceptDeny.Enabled = false;
                                tbRemarks.Enabled = false;
                            }
                        }
                        else if (lblReplyStatus.Text == "P")
                        {
                            txtReply.Text = "";
                            rblAcceptDeny.Enabled = false;
                            tbRemarks.Enabled = false;                         
                        }
                    }
                    else
                    {
                        rblAcceptDeny.Enabled = false;
                        tbRemarks.Enabled = false;
                        tbRemarks.Text = "";
                    }
                }
                else if ((Convert.ToInt16(Session["RoleId"].ToString()) == 2 && Convert.ToInt16(Session["DeptId"].ToString()) == 1))  
                {
                    txtReply.Enabled = false;                   
                    if (txtReply.Text != "")
                    {
                        if (lblReplyStatus.Text == "A")
                        {
                            rblAcceptDeny.Enabled = true;
                            tbRemarks.Enabled = true;                         
                            if (rblAcceptDeny.SelectedValue == "D")
                            {
                                rblAcceptDeny.ClearSelection();
                                tbRemarks.Text = "";
                            }
                            else if (rblAcceptDeny.SelectedValue == "A")
                            {
                                rblApplicable.Enabled = false;
                                rblDeviated.Enabled = false;
                                ddlRisk.Enabled = false;
                                txtObservation.Enabled = false;
                                txtReply.Enabled = false;
                                rblAcceptDeny.Enabled = false;
                                tbRemarks.Enabled = false;
                            }
                        }
                        else if (lblReplyStatus.Text == "P")
                        {
                            txtReply.Text = "";
                            rblAcceptDeny.Enabled = false;
                            tbRemarks.Enabled = false;                            
                        }
                    }
                    else
                    {
                        rblAcceptDeny.Enabled = false;
                        tbRemarks.Enabled = false;
                        tbRemarks.Text = "";
                    }                  
                }
                else
                {
                    if (txtObservation.Text != "")
                    {                        
                        if (Convert.ToInt16(Session["RoleId"].ToString()) <= 4 && Convert.ToInt16(Session["DeptId"].ToString()) != 1)
                        {                           
                            if (txtReply.Text == "")
                            {
                                lnkVerify.Enabled = false;
                            }
                            else
                            {
                                lnkVerify.Enabled = true;
                                lnkVerify.Visible = true;
                            }
                        }                     
                        else
                        {
                            string designation = Session["Designation"].ToString();
                            if ((lblReplyStatus.Text == "A") || (designation == "5") || (designation == "6") || (designation == "7"))
                                lnkVerify.Visible = false;
                            else if (ddlRisk.SelectedValue == "O")
                                lnkVerify.Visible = false;
                            else
                                lnkVerify.Visible = true;
                            if (rblAcceptDeny.SelectedValue == "D")
                            {
                                if (lblReplyStatus.Text == "")
                                {
                                    txtReply.Enabled = true;
                                    txtReply.Text = "";
                                }
                                else
                                {
                                    txtReply.Enabled = true;
                                }

                            }
                            else if (rblAcceptDeny.SelectedValue == "A")
                            {
                                txtReply.Enabled = false;
                            }
                        }
                    }
                    else if (txtObservation.Text == "")
                    {
                        txtReply.Enabled = false;
                    }
                    rblApplicable.Enabled = false;
                    rblDeviated.Enabled = false;
                    ddlRisk.Enabled = false;
                    txtObservation.Enabled = false;
                    rblAcceptDeny.Enabled = false;
                    tbRemarks.Enabled = false;              
                }
            }
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                // when mouse is over the row, save original color to new attribute, and change it to highlight color
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");
                // when mouse leaves the row, change the bg color to its original value   
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }
        }                                  
        catch (Exception ee)
        {
            Globals.Show(ee.Message.ToString());
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        AuditCheckListDtlsBAL p = new AuditCheckListDtlsBAL();
        AuditCheckListDtlsBO AuditCheckListDtls = new AuditCheckListDtlsBO();
        string sMsg = string.Empty;
        try
        {
            AuditCheckListDtls.AuditID = Convert.ToInt32(Session["Auditid"]);
            AuditCheckListDtls.Dept = Convert.ToInt32(ViewState["DeptId"]);

            foreach (GridViewRow row in gvCheckListStatus.Rows)
            {
                if (gvCheckListStatus.DataKeys[row.RowIndex].Values[2].ToString() == "1")
                {
                    HiddenField hdnEditFalg = (HiddenField)row.FindControl("hdnEditFalg");
                    if (hdnEditFalg.Value == "Y")
                    {
                        RadioButtonList rblApplicable = (RadioButtonList)row.FindControl("rblApplicable");
                        RadioButtonList rblDeviated = (RadioButtonList)row.FindControl("rblDeviated");
                        DropDownList ddlRisk = (DropDownList)row.FindControl("ddlRisk");
                        TextBox txtObservation = (TextBox)row.FindControl("txtObservation");
                        TextBox txtReply = (TextBox)row.FindControl("txtReply");
                        RadioButtonList rblAcceptDeny = (RadioButtonList)row.FindControl("rblAcceptDeny");
                        TextBox tbRemarks = (TextBox)row.FindControl("tbRemarks");
                        Label lblReplyStatus = (Label)row.FindControl("lblReplyStatus");
                        Label lblReplyUpdtBy = (Label)row.FindControl("lblReplyUpdtBy");

                        AuditCheckListDtls.GroupCode = Convert.ToInt32(gvCheckListStatus.DataKeys[row.RowIndex].Values[0].ToString());
                        AuditCheckListDtls.ItemCode = Convert.ToInt32(gvCheckListStatus.DataKeys[row.RowIndex].Values[1].ToString());
                        AuditCheckListDtls.Applicable = rblApplicable.SelectedValue;
                        AuditCheckListDtls.YNAns = rblDeviated.SelectedValue;
                        AuditCheckListDtls.GradeOption = ddlRisk.SelectedValue;
                        AuditCheckListDtls.ChecklistStatus = "A";
                        AuditCheckListDtls.Observation = txtObservation.Text;
                        if (Convert.ToInt32(ViewState["DeptId"].ToString()) == 1)
                        {
                            AuditCheckListDtls.ReplyStatus = lblReplyStatus.Text;
                            AuditCheckListDtls.UpdtBy = Session["StaffNum"].ToString();
                            AuditCheckListDtls.UpdtDt = DateTime.Now.ToString("dd-MMM-yyyy");
                            AuditCheckListDtls.ReplyUpdtBy = lblReplyUpdtBy.Text;
                            AuditCheckListDtls.Dept = 1;
                            if (rblAcceptDeny.SelectedValue == "D")
                                AuditCheckListDtls.ReplyStatus = "";
                        }
                        AuditCheckListDtls.Reply = txtReply.Text;
                        AuditCheckListDtls.AcceptDeny = rblAcceptDeny.SelectedValue;

                        //if (Convert.ToInt32(ViewState["DeptId"].ToString()) == 2)

                        //modified by Nagarathna on 01-10-2018
                        if (Convert.ToInt32(ViewState["DeptId"].ToString()) >= 2)
                        //end on 01-10-2018
                        {
                            if (lblReplyStatus.Text == "")
                                AuditCheckListDtls.ReplyStatus = "P";
                            else
                                AuditCheckListDtls.ReplyStatus = lblReplyStatus.Text;
                            AuditCheckListDtls.ReplyUpdtBy = Session["StaffNum"].ToString();
                            AuditCheckListDtls.ReplyUpdtDt = DateTime.Now.ToString("dd-MMM-yyyy");
                        }
                        AuditCheckListDtls.Remarks = tbRemarks.Text;
                        AuditCheckListDtls.Action = "I";
                        sMsg = p.UpdtCheckListDtls_New(AuditCheckListDtls);
                        Msg.Visible = true;
                        Msg.Text = sMsg;                       
                    }                  
                }
            }
            BindCheckList();            
        }
        catch (Exception ee)
        {
            Globals.Show(ee.Message.ToString());
        }
        finally
        {
            p = null;
            AuditCheckListDtls = null;
            sMsg = null;           
        }
    }
    protected void rblApplicable_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            GridViewRow currentRow = (GridViewRow)((RadioButtonList)sender).Parent.Parent;
            HiddenField hdnEditFalg = (HiddenField)currentRow.FindControl("hdnEditFalg");
            hdnEditFalg.Value = "Y";
            RadioButtonList rbl = sender as RadioButtonList;
            GridViewRow row = rbl.NamingContainer as GridViewRow;
            TextBox txtObs = row.FindControl("txtObservation") as TextBox;
            TextBox txtReply = row.FindControl("txtReply") as TextBox;
            TextBox tbRemarks = row.FindControl("tbRemarks") as TextBox;
            RadioButtonList rblAccDeny = row.FindControl("rblAcceptDeny") as RadioButtonList;          
            RadioButtonList rblApplicable = row.FindControl("rblApplicable") as RadioButtonList;
            RadioButtonList rblDeviated = row.FindControl("rblDeviated") as RadioButtonList;
            DropDownList ddlRisk = row.FindControl("ddlRisk") as DropDownList;
            ImageButton imgViewReply = row.FindControl("imgViewReply") as ImageButton;
            Label lblReplyStatus = row.FindControl("lblReplyStatus") as Label;
            LinkButton lnkVerify = row.FindControl("lnkVerify") as LinkButton;
            ImageButton imgEditReply = row.FindControl("imgEditReply") as ImageButton;
            ImageButton imgReply = row.FindControl("imgReply") as ImageButton;

            if (rbl.SelectedItem.Value == "N")
            {
                txtObs.Enabled = false;
                rblAccDeny.Enabled = false;
                tbRemarks.Enabled = false;
                rblApplicable.Enabled = false;
                rblDeviated.Enabled = false;
                ddlRisk.Enabled = false;
                imgViewReply.Enabled = false;
                lblReplyStatus.Enabled = false;
                lnkVerify.Enabled = false;
                imgEditReply.Enabled = false;
                imgReply.Enabled = false;

            }

            else if (rbl.SelectedItem.Value == "Y")
            {
                txtObs.Enabled = true;
                if (txtReply.Text == "")
                {
                    rblAccDeny.Enabled = false;
                }
            }
        }
        catch (Exception ee)
        {
            Globals.Show(ee.Message.ToString());
        }
    }

    protected void lnkVerify_Click1(object sender, EventArgs e)
    {
        string VerifyMsg = string.Empty;
        try
        {
            GridViewRow currentRow = (GridViewRow)((LinkButton)sender).Parent.Parent;
            HiddenField hdnEditFalg = (HiddenField)currentRow.FindControl("hdnEditFalg");
            hdnEditFalg.Value = "Y";            
            LinkButton lnkVerify = sender as LinkButton;
            GridViewRow row = lnkVerify.NamingContainer as GridViewRow;
            TextBox txtObs = row.FindControl("txtObservation") as TextBox;
            TextBox txtReply = row.FindControl("txtReply") as TextBox;
            TextBox tbRemarks = row.FindControl("tbRemarks") as TextBox;
            RadioButtonList rblAccDeny = row.FindControl("rblAcceptDeny") as RadioButtonList;
            Label lblReplyStatus = row.FindControl("lblReplyStatus") as Label;
            Label lblReplyUpdtBy = row.FindControl("lblReplyUpdtBy") as Label;            
            if (txtReply.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter the reply before Verifying!!!')", true);
                return;
            }
            AuditCheckListDtlsBO AuditCheckListDtls = new AuditCheckListDtlsBO();
            AuditCheckListDtlsBAL p = new AuditCheckListDtlsBAL();
            AuditCheckListDtls.AuditID = Convert.ToInt32(Session["Auditid"]);
            AuditCheckListDtls.GroupCode = Convert.ToInt32(gvCheckListStatus.DataKeys[currentRow.RowIndex].Values[0].ToString());
            AuditCheckListDtls.ItemCode = Convert.ToInt32(gvCheckListStatus.DataKeys[currentRow.RowIndex].Values[1].ToString());
            AuditCheckListDtls.Action = "V";          
            if (lblReplyStatus.Text == "")
                AuditCheckListDtls.ReplyStatus = "P";
            else
                AuditCheckListDtls.ReplyStatus = "A";
            AuditCheckListDtls.ReplyUpdtBy = Session["StaffNum"].ToString();
            AuditCheckListDtls.ReplyUpdtDt = DateTime.Now.ToString("dd-MMM-yyyy");
            int logusr = Convert.ToInt32(Session["StaffNum"]);
            int datausr = Convert.ToInt32(lblReplyUpdtBy.Text);

            if (lblReplyUpdtBy.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Reply cannot be verified before saving the data!!!')", true);
                return;
            }            
            if (Convert.ToInt32(ViewState["DeptId"].ToString()) != 1)
            {
                if (lblReplyStatus.Text == "A")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Already verified!!!')", true);
                    return;
                }
                if (logusr == datausr)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Maker cannot Authorize the Details!!!')", true);
                    return;
                }
            }

            VerifyMsg = p.UpdtCheckListDtls_New(AuditCheckListDtls);
            BindCheckList();

            Msg.Visible = true;
            Msg.Text = VerifyMsg;
            lnkVerify.Focus();          
        }
        catch (Exception ee)
        {
            Globals.Show(ee.Message.ToString());
        }
    }
    protected void rblDeviated_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow currentRow = (GridViewRow)((RadioButtonList)sender).Parent.Parent;
            HiddenField hdnEditFalg = (HiddenField)currentRow.FindControl("hdnEditFalg");
            hdnEditFalg.Value = "Y";
        }
        catch (Exception ee)
        {
            Globals.Show(ee.Message.ToString());
        }
    }
    protected void ddlRisk_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow currentRow = (GridViewRow)((DropDownList)sender).Parent.Parent;
            HiddenField hdnEditFalg = (HiddenField)currentRow.FindControl("hdnEditFalg");
            hdnEditFalg.Value = "Y";
        }
        catch (Exception ee)
        {
            Globals.Show(ee.Message.ToString());
        }
    }
    protected void rblAcceptDeny_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow currentRow = (GridViewRow)((RadioButtonList)sender).Parent.Parent;
            HiddenField hdnEditFalg = (HiddenField)currentRow.FindControl("hdnEditFalg");
            hdnEditFalg.Value = "Y";
        }
        catch (Exception ee)
        {
            Globals.Show(ee.Message.ToString());
        }
    }
    protected void tbRemarks_TextChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            HiddenField hdnEditFalg = (HiddenField)currentRow.FindControl("hdnEditFalg");
            hdnEditFalg.Value = "Y";
        }
        catch (Exception ee)
        {
            Globals.Show(ee.Message.ToString());
        }
    }
    protected void imgViewReply_Click(object sender, ImageClickEventArgs e)
    {
        GridViewRow currentRow = (GridViewRow)((ImageButton)sender).Parent.Parent;
        Session["D_AuditID"] = Session["AuditId"].ToString();
        Session["D_GrpCode"] = gvCheckListStatus.DataKeys[currentRow.RowIndex].Values[0].ToString();
        Session["D_Item"] = gvCheckListStatus.DataKeys[currentRow.RowIndex].Values[1].ToString();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Display", "window.open('View.aspx', 'window','toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=0,width=785,height=500,left=300,top=100');", true);
    }

    protected void txtObservation_TextChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            HiddenField hdnEditFalg = (HiddenField)currentRow.FindControl("hdnEditFalg");
            hdnEditFalg.Value = "Y";
        }
        catch (Exception ee)
        {
            Globals.Show(ee.Message.ToString());
        }
    }
    protected void imgEditReply_Click(object sender, ImageClickEventArgs e)
    {
        GridViewRow currentRow = (GridViewRow)((ImageButton)sender).Parent.Parent;
        HiddenField hdnEditFalg = (HiddenField)currentRow.FindControl("hdnEditFalg");
        hdnEditFalg.Value = "Y";

        TextBox txtObservation = (TextBox)currentRow.FindControl("txtObservation");
        string sControls = "E|" + txtObservation.ClientID;
        Session["TxtRemark"] = txtObservation.Text;
        Session["TxtRemarkIndex"] = currentRow.RowIndex;
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "EnterText", "window.open('EnterText.aspx?Action=" + sControls + "', 'window','toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=0,width=650,height=275,left=300,top=100');", true);
    }

    protected void imgReply_Click(object sender, ImageClickEventArgs e)
    {
        GridViewRow currentRow = (GridViewRow)((ImageButton)sender).Parent.Parent;
        HiddenField hdnEditFalg = (HiddenField)currentRow.FindControl("hdnEditFalg");
        hdnEditFalg.Value = "Y";

        TextBox txtReply = (TextBox)currentRow.FindControl("txtReply");
        string sControls = "R|" + txtReply.ClientID;
        Session["TxtReply"] = txtReply.Text;
        Session["TxtReplyIndex"] = currentRow.RowIndex;
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "EnterReply", "window.open('EnterReply.aspx?Action=" + sControls + "', 'window','toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=0,width=650,height=275,left=300,top=100');", true);
    }

    protected void txtReply_TextChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            HiddenField hdnEditFalg = (HiddenField)currentRow.FindControl("hdnEditFalg");
            hdnEditFalg.Value = "Y";
        }
        catch (Exception ee)
        {
            Globals.Show(ee.Message.ToString());
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("auditStatusWing.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlGridChklstStatusDetails.Visible = false;
    }
}