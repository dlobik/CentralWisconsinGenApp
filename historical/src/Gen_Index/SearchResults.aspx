<%@ Page Language="C#" MasterPageFile="~/addins_app/app_child.master" AutoEventWireup="true" CodeFile="SearchResults.aspx.cs" Inherits="SearchResults" EnableEventValidation="false" %>

<asp:Content id="DefaultHead" ContentPlaceHolderID="ContentPlaceHolderDefaultHead" runat="server">
    <link rel="stylesheet" href="assets/css/default.css" media="screen" type="text/css" />

 </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="headerPlaceHolder" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="mainContent">
    <div id="bodyinfo">
      <div id="genIndexNav">
         <ul>
             <li>
                 <a href="http://www.uwsp.edu/library/archives/Pages/researchGuides.aspx#census" target="_blank">Census Information</a>
             </li>
             <li>
                 <a href="http://www.uwsp.edu/library/archives/Pages/researchGuides.aspx#nat" target="_blank">Naturalization Information</a>
             </li>
             <li>
                 <a href="http://www.uwsp.edu/library/archives/Pages/researchGuides.aspx#obit" target="_blank">Obituary Information</a>
             </li>
             <li>
                 <a href="http://www.uwsp.edu/landing/Pages/visit.aspx" target="_blank">Visitor’s Information</a>
             </li>
         </ul> 
     </div>
     <br/>
     <br/>
     <div> 
        <table width="100%"><tr><td align="center" class="style1" valign="middle"> 
            <asp:Label ID="Label5" Text="Central Wisconsin Genealogy Index" Font-Bold="True" runat="server" 
            CssClass="ClassHeading"></asp:Label>
            </td></tr> 
            <tr><td align="center" class="style1" valign="middle"> 
            <asp:Label ID="Label12" Text="Search Results" Font-Bold="True" runat="server" 
            CssClass="ClassHeading"></asp:Label>
            </td></tr> 
        </table>
     </div>
          <asp:UpdatePanel ID="upTop" runat="server" UpdateMode="Conditional"><ContentTemplate>
            <asp:GridView ID="gvSearchList" runat="server" AutoGenerateColumns="False" AllowPaging="true" 
            OnRowDataBound="gvSearchList_OnRowDataBound"
			PageSize="10" OnPageIndexChanging="gvSearchList_OnPageIndexChanging" DataKeyNames="GN_ID" 
			Width="100%" EmptyDataText="No results were found matching the search parameters entered." BackColor="White" BorderColor="#4A3C8C" 
			BorderStyle="None" BorderWidth="1px" CellPadding="2" CellSpacing="2" GridLines="None" CssClass="gvSearchList">
	      <%--   <AlternatingRowStyle BackColor="WhiteSmoke" />
	        <HeaderStyle BackColor="Cornsilk" />--%>
	        <Columns>
                <asp:BoundField DataField="GN_ID" Visible="false" />
                <asp:BoundField DataField="FULL_NM" HeaderText="Name" ItemStyle-Width="95px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gvSearchListHeader" />
                <asp:TemplateField HeaderText="Alt Names" ItemStyle-Width="95px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gvSearchListHeader">
                    <ItemTemplate>
                        <%# GetAltNames(Convert.ToInt32(Eval("GN_RECORD_TYPE_CD")), Eval("GN_ID").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Record Type" ItemStyle-Width="87px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gvSearchListHeader">
                    <ItemTemplate>
                        <%# GetRecordType(Convert.ToInt32(Eval("GN_RECORD_TYPE_CD")), Eval("GN_COUNTY").ToString()) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="GN_BIRTH_YEAR_OR_AGE" HeaderText="Birth Year or Age" ItemStyle-Width="75px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderText="Date of Record" ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gvSearchListHeader">
                    <ItemTemplate>
                        <%#	GetDateofRecord(Convert.ToInt32(Eval("GN_ID")), Convert.ToInt32(Eval("GN_RECORD_TYPE_CD")), Eval("N_ABBR").ToString(), Eval("GN_DATE_OF_RECORD").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Location" ItemStyle-Width="147px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gvSearchListHeader">
                    <ItemTemplate>
                        <%# GetLocation(Convert.ToInt32(Eval("GN_RECORD_TYPE_CD")), Eval("GN_LOCATION").ToString(), Eval("GN_ID").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                    <HeaderTemplate>
                        <asp:Button ID="btnViewCart" runat="server" Text="<%# GetCartQuantity() %>" 
                            OnClick="btnViewCart_OnClick" ToolTip="View Cart (# of items in cart)" CssClass="btnBox btnBoxViewCart"/>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnAddToOrder" runat="server" OnClick="btnAddToOrder_OnClick" Text="Add to Order" CssClass="btnBox btnBoxAddToOrder" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        </td></tr>
                        <tr>
                        <td></td>
                        <td colspan="5">
                            <div id="<%# Eval("GN_ID") %>" style="display: none; position: relative">
                            <asp:GridView ID="gvSearchList_Family" ShowHeader="true" ShowFooter="false" runat="server" AutoGenerateColumns="false" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="CM_FIRST_NM" HeaderText="Other Household Members"  />
                                    <asp:BoundField DataField="CM_AGE" HeaderText="Age" />
                                    <asp:BoundField DataField="CM_PAGE" HeaderText="Location" />
                                </Columns>
                            </asp:GridView> 
                            <asp:GridView ID="gvSearchList_Nat" ShowHeader="true" ShowFooter="false" runat="server"
                                AutoGenerateColumns="true" Width="100%"></asp:GridView>                                       
                            </div>
                        </td>                        
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Left" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#623f99" Font-Bold="True" ForeColor="#F7F7F7" VerticalAlign="Middle" Height="35"/>
        <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
   
            <asp:Button ID="btnPhantom" runat="server" Text="phantom" CssClass="hiddenbtn" />
        
            <ajaxToolkit:ModalPopupExtender ID="mpeShoppingCart" RepositionMode="None" runat="server" PopupControlID="pnlShoppingCart"
                BackgroundCssClass="modalBackground" 
                TargetControlID="btnPhantom" PopupDragHandleControlID="pnlShoppingCart" X="0" Y="0"></ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="pnlShoppingCart" runat="server" CssClass="modalPopup" 
            HorizontalAlign="Center" Width="730px">
        <table class="pnlShoppingCartTable"><tr ><td colspan="3" align="center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
        <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="false"
         Width="100%" ShowFooter="true" DataKeyNames="GN_ID" OnRowDeleting="gvCart_OnRowDeleting">
            <%-- <AlternatingRowStyle BackColor="WhiteSmoke" />
            <HeaderStyle BackColor="WhiteSmoke" Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" />
            <RowStyle Font-Size="Small" Font-Names="Verdana" BackColor="White" />	--%>	
		    <Columns>
		        <asp:CommandField ShowDeleteButton="True" ItemStyle-CssClass="shoppingCartDelete"/>
				    <asp:BoundField DataField="FULL_NM" HeaderText="Name"></asp:BoundField>
				    <asp:TemplateField HeaderText="Record Type">
                        <ItemTemplate>
                            <%# GetRecordType(Convert.ToInt32(Eval("GN_RECORD_TYPE_CD")), Eval("GN_COUNTY").ToString()) %>
                        </ItemTemplate>
                        <FooterTemplate>Total: <%# GetOrderTotal() %></FooterTemplate>
                        <FooterStyle Font-Bold="true" Font-Size="Small" />
                    </asp:TemplateField>
		    </Columns>	
		<RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Left" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#623f99" Font-Bold="True" ForeColor="#F7F7F7" VerticalAlign="Middle" Height="35"/>
        <AlternatingRowStyle BackColor="#F7F7F7" />	
        </asp:GridView>
        </ContentTemplate></asp:UpdatePanel>
        </td></tr>
        <tr><td><asp:Button ID="btnCloseCart" runat="server" Text="Continue searching" OnClick="btnCloseCart_OnClick" CssClass="btnBox" />
        </td><td><asp:Button ID="btnCheckoutCredit" runat="server" Text="Pay with Credit Card" OnClick="btnCheckoutCredit_OnClick" CssClass="btnBox"/>  
        </td><td><asp:Button ID="btnCheckoutPrint" runat="server" Text="Print A Mail Order Form" OnClick="btnCheckoutPrint_OnClick" CssClass="btnBox"/>             
        </td></tr>
        </table>  
         
        </asp:Panel>  
        <br/>
        <br/>
            <div class="Lib_footer">
                <asp:Table ID="footerJointProjects" runat="server" CssClass="libfooterTable">
                    <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell ID="TableCell1" runat="server" CssClass="jointProjectsCell">
                    <asp:Label ID="jointProjectsLabel" runat="server" Text="Joint projects of the:" CssClass="jointProjectsLabelStyle" />
                </asp:TableCell>
            </asp:TableRow>
                    <asp:TableRow ID="TableRow2" runat="server">
                <asp:TableCell ID="TableCell2" runat="server" CssClass="jointProjectsCell">
                    <asp:Label ID="Label6" runat="server" Text="UWSP University Archives" />
                </asp:TableCell>
            </asp:TableRow>
                    <asp:TableRow ID="TableRow3" runat="server">
                <asp:TableCell ID="TableCell3" runat="server" CssClass="jointProjectsCell">
                    <asp:Label ID="Label7" runat="server" Text="Portage County Public Library" />
                </asp:TableCell>
            </asp:TableRow>
                    <asp:TableRow ID="TableRow4" runat="server">
                <asp:TableCell ID="TableCell4" runat="server" CssClass="jointProjectsCell">
                    <asp:Label ID="Label8" runat="server" Text="Stevens Point Area Genealogical Society" />
                </asp:TableCell>
            </asp:TableRow>
                    <asp:TableRow ID="TableRow5" runat="server">
                <asp:TableCell ID="TableCell5" runat="server" CssClass="jointProjectsCell">
                    <asp:Label ID="Label9" runat="server" Text="Waupaca Area Genealogical Society" />
                </asp:TableCell>
            </asp:TableRow>
                    <asp:TableRow ID="TableRow6" runat="server">
                <asp:TableCell ID="TableCell6" runat="server" CssClass="jointProjectsCell">
                    <asp:Label ID="Label10" runat="server" Text=" " />
                </asp:TableCell>
            </asp:TableRow>
                    <asp:TableRow ID="TableRow7" runat="server">
                <asp:TableCell ID="TableCell7" runat="server" CssClass="jointProjectsCell">
                    <asp:Label ID="Label11" runat="server">
                        For Genealogy Index problems or feedback, 
         <a href="mailto:archives@uwsp.edu?subject=Feedback" class="contactUnivArch">Contact University Archives</a> 
         715-346-2586
                    </asp:Label>
                </asp:TableCell>
            </asp:TableRow>
                </asp:Table>
                <br />
            </div>
          </ContentTemplate></asp:UpdatePanel>   
       <!-- Include JavaScript -->
<script language="JavaScript" type="text/javascript">
    var currentlyOpenedDiv = "";
    var currentlyOpenedDiv2 = "";
    function CollapseExpand(object, object2) {
        var div = document.getElementById(object);
        if (currentlyOpenedDiv != "" && currentlyOpenedDiv != div) {
            currentlyOpenedDiv.style.display = "none";
        }
        if (div.style.display == "none") {
            div.style.display = "inline";
            currentlyOpenedDiv = div;
        }
        else {
            div.style.display = "none";
        }
    }
</script>

   <script type="text/javascript" language="javascript" >
       function pageLoad() {
           //hide the last column in management gridview
           var rows = document.getElementById("<%=gvSearchList.ClientID%>").rows;
           var NumRows = rows.length - 1;
           for (var i = 0; i < NumRows; i++) {
               try {
                   rows[i].cells[7].style.display = "none";
               } catch (Error) { };
           }
       }
    </script>     
    </div>
    </div>
</asp:Content>