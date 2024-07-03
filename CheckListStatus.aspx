<%@ Page Title="" Language="C#" MasterPageFile="~/AASMaster.master" AutoEventWireup="true" CodeFile="CheckListStatus.aspx.cs" Inherits="CheckListStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="Server">

    <script type="text/javascript">
        function AutoExpand(txtbox) {
            txtbox.style.height = "1px";
            txtbox.style.height = 50 + txtbox.scrollHeight + "px";
        }
        function AutoContract(txtbox) {
            txtbox.style.height = "35px";
        }

    </script>
    <script src="http://code.jquery.com/jquery-1.11.3.js" type="text/javascript"></script>

   <%-- <script type="text/javascript">
        $(document).ready(function () {
            maintainScrollPosition();
        });
        function pageLoad() {
            maintainScrollPosition();
        }
        function maintainScrollPosition() {
            $("#dvScroll").scrollTop($('#<%=hfScrollPosition.ClientID%>').val());
        }
        function setScrollPosition(scrollValue) {
            $('#<%=hfScrollPosition.ClientID%>').val(scrollValue);
        }
    </script>--%>

    <div class="PageContent">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:HiddenField ID="hfScrollPosition" Value="0" runat="server" />
                <br />
                <asp:Label ID="lblHeading" runat="server" CssClass="PageTitle" Text="Audit Report Status" ForeColor="#5C2D50"></asp:Label>
                <br />
                <br />
                 <asp:Label ID="lblAuditId" runat="server" Text="Audit Id:" ForeColor="#5C2D50" Font-Size="Small" Font-Bold="true"></asp:Label>
                 <asp:Label ID="lblAudit" runat="server" ForeColor="#5C2D50" Text="Label"  Font-Size="Small" Font-Bold="true"></asp:Label>&nbsp;&nbsp;
                 <asp:Label ID="lblAppName" runat="server"  Text="Application Name:" ForeColor="#5C2D50" Font-Size="Small" Font-Bold="true" ></asp:Label>
                 <asp:Label ID="lblApplication" runat="server"  ForeColor="#5C2D50" Text="Label"  Font-Size="Small" Font-Bold="true"></asp:Label>
                
                <strong style="text-align: center; align-items: center; color: #5C2D50;">
                    <br />

                    <asp:Panel ID="pnlGridAudit" runat="server">
                        <table style="width: 100%">
                            <tr>
                                <td align="center">
                                    <asp:DataList ID="dlCheckListStatus" runat="server" DataKeyField="GRPCODE" Font-Names="Verdana" GridLines="Both"
                                        OnItemCommand="dlCheckListStatus_ItemCommand" OnItemDataBound="dlCheckListStatus_ItemDataBound">
                                        <HeaderTemplate>
                                            <td style="background-color: #003058; color: white; font-size: small; background-color: #666699">Sl No</td>
                                            <td style="background-color: #003058; color: white; font-size: small; background-color: #666699">Checklist Areas</td>
                                            <td style="background-color: #003058; color: white; font-size: small; background-color: #666699">Status</td>
                                            <td style="background-color: #003058; color: white; font-size: small; background-color: #666699">Tot OBS</td>
                                            <td style="background-color: #003058; color: white; font-size: small; background-color: #666699">ECH</td>
                                            <td style="background-color: #003058; color: white; font-size: small; background-color: #666699">Pending</td>
                                            <td style="background-color: #003058; color: white; font-size: small; background-color: #666699">Replied</td>
                                            <td style="background-color: #003058; color: white; font-size: small; background-color: #666699">Accept</td>
                                            <td style="background-color: #003058; color: white; font-size: small; background-color: #666699">Deny</td>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <td style="background-color: white; font-size: small; text-align: center;">
                                                <asp:Label ID="lblSlNo" runat="server" Text='<%#Eval("SLNUM") %>' />
                                            </td>
                                            <asp:Label ID="lblMainCode" runat="server" Visible="false" Text='<%#Eval("GRPCODE") %>' />
                                            <td style="background-color: white; font-size: small; text-align: left; color: blue;">
                                                <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select" CausesValidation="false" Text='<%#Eval("ITEMDESC") %>' />
                                                <asp:Label ID="lblSections" runat="server" Text='<%#Eval("ITEMDESC") %>' Visible="false" />
                                            </td>
                                            <td style="background-color: white; font-size: small; text-align: left; color: blue;">
                                                <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>' />
                                            </td>
                                            <td style="background-color: white; font-size: small; text-align: left; color: blue;">
                                                <asp:LinkButton ID="lnkTotOBS" runat="server" CommandName="TOTOBS" CausesValidation="false" Text='<%#Eval("TOTOBS") %>' />
                                                <asp:Label ID="lblTOTOBS" runat="server" Text='<%#Eval("TOTOBS") %>' Visible="false" />
                                            </td>
                                            <td style="background-color: white; font-size: small; text-align: left; color: blue;">
                                                <asp:LinkButton ID="lnkECH" runat="server" CommandName="ECH" CausesValidation="false" Text='<%#Eval("ECH") %>' />
                                                <asp:Label ID="lblECH" runat="server" Text='<%#Eval("ECH") %>' Visible="false" />
                                            </td>
                                            <td style="background-color: white; font-size: small; text-align: left; color: blue;">
                                                <asp:LinkButton ID="lnkPending" runat="server" CommandName="Pending" CausesValidation="false" Text='<%#Eval("PENDING") %>' />
                                                <asp:Label ID="lblPending" runat="server" Text='<%#Eval("PENDING") %>' Visible="false" />
                                            </td>
                                            <td style="background-color: white; font-size: small; text-align: left; color: blue;">
                                                <asp:LinkButton ID="lnkReplied" runat="server" CommandName="Reply" CausesValidation="false" Text='<%#Eval("REPLIED") %>' />
                                                <asp:Label ID="lblReplied" runat="server" Text='<%#Eval("REPLIED") %>' Visible="false" />
                                            </td>
                                            <td style="background-color: white; font-size: small; text-align: left; color: blue;">
                                                <asp:LinkButton ID="lnkAccept" runat="server" CommandName="Accept" CausesValidation="false" Text='<%#Eval("ACCEPT") %>' />
                                                <asp:Label ID="lblAccept" runat="server" Text='<%#Eval("ACCEPT") %>' Visible="false" />
                                            </td>
                                            <td style="background-color: white; font-size: small; text-align: left; color: blue;">
                                                <asp:LinkButton ID="lnkDeny" runat="server" CommandName="Deny" CausesValidation="false" Text='<%#Eval("DENY") %>' />
                                                <asp:Label ID="lblDeny" runat="server" Text='<%#Eval("DENY") %>' Visible="false" />
                                            </td>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>                            
                            <tr>
                                <td>
                                    <asp:Button ID="btnBack" runat="server" BackColor="#666699" Font-Bold="True" ForeColor="White" Text="Back" Height="27px" Width="70px" OnClick="btnBack_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                     <asp:Label ID="lblGroups" runat="server"  ForeColor="#5C2D50" Font-Size="Small" Font-Bold="true" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <br>


                    <asp:Panel ID="pnlGridChklstStatusDetails" runat="server">
                        <table style="width: 100%">
                            <tr>
                                <td style="align-content: center">
                                    <div id="dvScroll" onscroll="setScrollPosition(this.scrollTop);" style="width: 1069px; height: 400px; overflow: scroll">
                                        <asp:GridView ID="gvCheckListStatus" runat="server" AutoGenerateColumns="False" DataKeyNames="GRPCODE, ACM_ITEMCODE, PROMPT" OnRowDataBound="gvCheckListStatus_RowDataBound">
                                            <HeaderStyle BackColor="#666699" Font-Bold="false" Font-Size="Small" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="ITEMDESC" HeaderText="Query Details" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200px">
                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Applicable" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdnEditFalg" runat="server" />
                                                        <asp:RadioButtonList ID="rblApplicable" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblApplicable_SelectedIndexChanged1" RepeatDirection="Vertical">
                                                            <asp:ListItem Value="Y">Y</asp:ListItem>
                                                            <asp:ListItem Value="N">N</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Deviated" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:RadioButtonList ID="rblDeviated" runat="server" OnSelectedIndexChanged="rblDeviated_SelectedIndexChanged" RepeatDirection="Vertical">
                                                            <asp:ListItem Value="Y">Y</asp:ListItem>
                                                            <asp:ListItem Value="N">N</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Risk Rating">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlRisk" runat="server" OnSelectedIndexChanged="ddlRisk_SelectedIndexChanged" RepeatDirection="Vertical">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Value="E">Exposure</asp:ListItem>
                                                            <asp:ListItem Value="C">Concern</asp:ListItem>
                                                            <asp:ListItem Value="H">HouseKeeping</asp:ListItem>
                                                            <asp:ListItem Value="O">Okay</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Observations-IS Auditor">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtObservation" runat="server" Height="50px" OnTextChanged="txtObservation_TextChanged" onblur="AutoContract(this);" onClick="AutoExpand(this);" onkeyup="AutoExpand(this);" Text='<%#DataBinder.Eval(Container.DataItem, "OBSERVE")  %>' TextMode="MultiLine"></asp:TextBox>
                                                        &nbsp;
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgEditReply" runat="server" Height="21px" ImageUrl="~/Images/Text-editor.png" OnClick="imgEditReply_Click" ToolTip="Edit/View Observation" Width="21px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Reply">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtReply" runat="server" Height="50px" onblur="AutoContract(this);" onClick="AutoExpand(this);" onkeyup="AutoExpand(this);" OnTextChanged="txtReply_TextChanged" Text='<%#DataBinder.Eval(Container.DataItem, "REPLY")  %>' TextMode="MultiLine"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgViewReply" runat="server" ImageUrl="~/Images/View.gif" ToolTip="View Previous Reply " OnClick="imgViewReply_Click" />  
                                                          <asp:LinkButton ID="lnkVerify" runat="server" Text="Verify" ToolTip="Verify Reply" CommandName="Verify" Style="height: 16px" Visible="False" OnClick="lnkVerify_Click1" />                                                       
                                                        <asp:ImageButton ID="imgReply" runat="server" Height="21px" ImageUrl="~/Images/Text-editor.png" OnClick="imgReply_Click" ToolTip="Edit/View Reply" Width="21px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Accept / Deny">
                                                    <ItemTemplate>
                                                        <asp:RadioButtonList ID="rblAcceptDeny" runat="server" OnSelectedIndexChanged="rblAcceptDeny_SelectedIndexChanged" RepeatDirection="Vertical">
                                                            <asp:ListItem Value="A">A</asp:ListItem>
                                                            <asp:ListItem Value="D">D</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="tbRemarks" runat="server" Height="50px" onblur="AutoContract(this);" onClick="AutoExpand(this);" onkeyup="AutoExpand(this);" Text='<%#DataBinder.Eval(Container.DataItem, "REMARKS")  %>' OnTextChanged="tbRemarks_TextChanged" TextMode="MultiLine"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUpdtBy" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "UPDTBY")  %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblUpdtDt" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "UPDT_DT")  %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblReplyStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "REPLYSTATUS")  %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblReplyUpdtBy" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "REPLYUPBY")  %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblReplyUpdt" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "REPLYUPDT_DT")  %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <tr>
                                    <td><strong style="text-align: center; align-items: center; color: #5C2D50;">
                                    <asp:Button ID="btnSave" runat="server" BackColor="#666699" Font-Bold="True" ForeColor="White" OnClick="btnSave_Click" Text="Save" Height="27px" Width="80px" />
                                    <strong style="text-align: center; color: #5C2D50;"><span style="text-align: center; color: #5C2D50;">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" BackColor="#666699" Font-Bold="True" ForeColor="White" Style="height: 27px" Text="Cancel" Width="80px" OnClick="btnCancel_Click" />
                                        <br />
                                          <asp:Label ID="Msg" runat="server" Text="Label" Visible="False"></asp:Label>
                            </tr>  
                                    </div>
                                </td>
                            </tr>                                                      
                        </table>
                    </asp:Panel>
                </strong>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="dlCheckListStatus" EventName="ItemCommand" />
                <asp:AsyncPostBackTrigger ControlID="dlCheckListStatus" EventName="ItemDataBound" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>

