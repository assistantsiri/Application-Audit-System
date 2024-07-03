<%@ Page Title="" Language="C#" MasterPageFile="~/AASMaster.master" AutoEventWireup="true" CodeFile="RptAuditReportDetailed.aspx.cs" Inherits="RptAuditReportDetailed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="font-size: medium; font-family: Verdana; text-align: center; height: 300px; align-items: center" class="PageContent">
                <strong style="text-align: center; align-items: center; color: #5C2D50;">
                    <asp:Panel ID="PnlAppDtls" runat="server" HorizontalAlign="Center">
                        <span style="font-size: medium; color: #5C2D50; font-weight: bold">
                            <br />
                            <asp:Label ID="lblName" runat="server" Text="Application Auditee Replies Report"></asp:Label>
                            <br />
                        </span>
                </strong>
                <center>
                            <asp:DataList ID="dlAppDtls" runat="server" CssClass="basix" Font-Bold="False" Font-Names="Verdana" GridLines="Both" OnEditCommand="dlAppDtls_EditCommand">                                
                                <HeaderTemplate>
                                    <td style="background-color: #666699; color: white; font-size: small">Audit ID</td>
                                    <td style="background-color: #666699; color: white; font-size: small">Requirement ID</td>
                                    <td style="background-color: #666699; color: white; font-size: small">Application/Software Name</td>
                                    <td style="background-color: #666699; color: white; font-size: small">Status</td>
                                    <td style="background-color: #666699"></td>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <td style="background-color: white; font-size: small; padding-right: 10px; align-items: center">
                                        <asp:HiddenField ID="hdnWing" runat="server" Value='<%#Eval("Wing") %>' />
                                        <asp:Label ID="lblAuditId" runat="server" Text='<%#Eval("AuditId") %>'></asp:Label>
                                    </td>
                                    <td style="background-color: white; font-size: small; padding-right: 10px">
                                        <asp:Label ID="lblReqId" runat="server" Text='<%#Eval("ReqId") %>'></asp:Label>
                                    </td>
                                    <td style="background-color: white; font-size: small; padding-right: 10px">
                                        <asp:Label ID="lblAppName" runat="server" Text='<%#Eval("AppName") %>'></asp:Label>
                                    </td>
                                    <td style="background-color: white; font-size: small; padding-right: 10px">
                                        <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("APA_AUDIT_STAGE") %>'></asp:Label>
                                    </td>
                                    <td style="background-color: white; color: #5C2D50; font-size: small; padding-right: 10px">
                                        <asp:LinkButton ID="lnkView" runat="server" CommandName="Edit" Font-Underline="False">View Report</asp:LinkButton>
                                    </td>
                                </ItemTemplate>
                            </asp:DataList>
                              </center>
                <div id="divLink">
                    <asp:LinkButton ID="lnkPrev" runat="server" Font-Bold="False" Font-Names="Verdana" Font-Size="Small" Font-Underline="False" ForeColor="#5C2D50" OnClick="lnkPrev_Click" Text="Prev"></asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lnkNext" runat="server" Font-Bold="False" Font-Names="Verdana" Font-Size="Small" Font-Underline="False" ForeColor="#5C2D50" OnClick="lnkNext_Click" Text="Next"></asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lnkFirst" runat="server" Font-Bold="False" Font-Names="Verdana" Font-Size="Small" Font-Underline="False" ForeColor="#5C2D50" OnClick="lnkFirst_Click" Text="First"></asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lnkLast" runat="server" Font-Bold="False" Font-Names="Verdana" Font-Size="Small" Font-Underline="False" ForeColor="#5C2D50" OnClick="lnkLast_Click" Text="Last"></asp:LinkButton>
                    <br />
                </div>
                <br />
                <center>
                <table style="border-color: #3366FF; border-width: 2px; font-size: small; margin-left: 62px; width: 550px; border-top-style: groove; font-family: Verdana; border-right-style: groove; border-left-style: groove; background-color: white; border-bottom-style: groove"
                    id="Table1" align="center">
                    <tbody>
                        <tr>
                            <td style="width: 1080px; height: 26px; background-color: white; text-align: left; font-weight: normal;" align="right">Search Application Name</td>
                            <td style="width: 106px; height: 26px; text-align: left;" class="auto-style4">
                                <asp:DropDownList ID="ddlAppName" runat="server" Width="250px"></asp:DropDownList>
                            </td>
                            <%--<td style="width: 12px; height: 26px;">
                                <asp:RequiredFieldValidator ID="reqAuditId" runat="server" ControlToValidate="ddlAppName" ErrorMessage="*" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                            </td>--%>
                            <td style="width: 12px; height: 26px;">&nbsp;</td>
                            </td>
                    <td align="left" style="width: 136px; vertical-align: middle; height: 26px;">
                        <asp:Button ID="btnGo" runat="server" BackColor="#666699" Font-Bold="False" ForeColor="White" AutoPostBack="true"
                            OnClick="btnGo_Click" Text="Go" Width="47px" BorderStyle="None" Height="23px" />
                        &nbsp;
                    </td>
                        </tr>
                    </tbody>
                </table>
                    </center>
                 <asp:Label ID="Msg" runat="server" Font-Size="Small" Visible="False"></asp:Label>
                <br />
                <asp:Button ID="btnBack" runat="server" BackColor="#666699" CausesValidation="False" Font-Bold="False" Font-Names="Verdana" ForeColor="White" OnClick="btnBack_Click" Text="Back" Width="80px" />
                <br />

                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

