<%@ Page Language="C#" MasterPageFile="~/addins_app/app_child.master" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ MasterType virtualpath="~/addins_app/app_child.master" %>

<asp:Content id="DefaultHead" ContentPlaceHolderID="ContentPlaceHolderDefaultHead" runat="server">
    <link rel="stylesheet" href="assets/css/default.css" media="screen" type="text/css" />
    <link rel="stylesheet" href="assets/css/jquery-ui.custom.css" media="screen" type="text/css" />
    <script src="assets/js/jquery-ui.min.custom.js" type="text/javascript"></script>
<%--    <script src="assets/js/jquery.ba-bbq.js" type="text/javascript"></script>--%>
    
    <script type="text/javascript" language="javascript">

        $(function() {

            // The "tab widgets" to handle.
            var tabs = $('.tabs'),

            // This selector will be reused when selecting actual tab widget A elements.
            tab_a_selector = 'ul.ui-tabs-nav a';

            // Enable tabs on all tab widgets. The `event` property must be overridden so
            // that the tabs aren't changed on click, and any custom event name can be
            // specified. Note that if you define a callback for the 'select' event, it
            // will be executed for the selected tab whenever the hash changes.
            tabs.tabs({ event: 'change' });

            // Define our own click handler for the tabs, overriding the default.
            tabs.find(tab_a_selector).click(function() {
                var state = {},

                // Get the id of this tab widget.
      id = $(this).closest('.tabs').attr('id'),

                // Get the index of this tab.
      idx = $(this).parent().prevAll().length;

                // Set the state!
                state[id] = idx;
                $.bbq.pushState(state);
            });

            // Bind an event to window.onhashchange that, when the history state changes,
            // iterates over all tab widgets, changing the current tab as necessary.
            $(window).bind('hashchange', function(e) {

                // Iterate over all tab widgets.
                tabs.each(function() {

                    // Get the index for this tab widget from the hash, based on the
                    // appropriate id property. In jQuery 1.4, you should use e.getState()
                    // instead of $.bbq.getState(). The second, 'true' argument coerces the
                    // string value to a number.
                    var idx = $.bbq.getState(this.id, true) || 0;

                    // Select the appropriate tab for this tab widget by triggering the custom
                    // event specified in the .tabs() init above (you could keep track of what
                    // tab each widget is on using .data, and only select a tab if it has
                    // changed).
                    $(this).find(tab_a_selector).eq(idx).triggerHandler('change');
                });
            })

            // Since the event is only triggered when the hash changes, we need to trigger
            // the event now, to handle the hash the page may have loaded with.
            $(window).trigger('hashchange');

        });

        $(function() {

            // Syntax highlighter.
            SyntaxHighlighter.highlight();

        });

</script>

 </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="headerPlaceHolder" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 <asp:UpdatePanel ID="upTop" runat="server" UpdateMode="Conditional">
 <ContentTemplate>
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

    <div>
        <br/>  
    <table width="100%"><tr><td align="center" class="style1" valign="middle"> 
    <asp:Label Text="Central Wisconsin Genealogy Index" Font-Bold="True" runat="server" 
            CssClass="ClassHeading"></asp:Label>
    </td></tr>
  <%--    <tr><td align="center" class="style1" valign="middle"> 
            <asp:Label ID="Label12" Text="Search" Font-Bold="True" runat="server" 
            CssClass="ClassHeading"></asp:Label>
            </td></tr>--%>
      </table>
    </div> 
    <br/>     
    <div id="search_tabs" class="tabs">
  <ul>
    <li><a href="#search_tabs_0">Search</a></li>
    <li><a href="#search_tabs_1">Results</a></li>
  </ul>
  <div id="search_tabs_0">
               <br/>
                <table>
                    <tr>
                        <td><asp:Label ID="Label1" runat="server" Text="Last Name:" CssClass="searchLabels"></asp:Label></td>
                        <td><asp:TextBox ID="txtLast" runat="server" CssClass="txtBox" /></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblFirstName" runat="server" Text="First Name:" CssClass="searchLabels"></asp:Label></td>
                            <td><asp:TextBox ID="txtFirst" runat="server" CssClass="txtBox"/></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblCounty" runat="server" Text="County:" CssClass="searchLabels"></asp:Label></td>
                            <td><asp:DropDownList ID="ddlCounty" runat="server" CssClass="countyDdl" Width="148px">
                                    <asp:ListItem Text=" Search All Counties " Selected="True" Value="All"></asp:ListItem>
                                    <asp:ListItem Text=" Portage County      " Value="Portage"></asp:ListItem>
                                    <asp:ListItem Text=" Waupaca County      " Value="Waupaca"></asp:ListItem>
                                    </asp:DropDownList>&nbsp;&nbsp;&nbsp;<a href="Images/state_county.gif" target="_blank" title="County Map" class="countyMap">County Map</a>
                           </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblDate" runat="server" Text="<b>Date obituary was published,</b><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;not date of death (14 Apr 2007):" CssClass="searchLabels2"></asp:Label></td>
                            <td><asp:TextBox ID="txtDate" runat="server" CssClass="txtBox"/>
                                <asp:CustomValidator runat="server" ID="validateDateObit" ControlToValidate="txtDate" EnableClientScript="False" OnServerValidate="ValidateDateObit" ErrorMessage="Please enter a valid date." Display="Dynamic" SetFocusOnError="True" ValidateEmptyText="True" />
                            </td>
                            <ajaxToolkit:CalendarExtender ID="calExtenderDateObitPub" TargetControlID="txtDate" Format="d MMM yyyy" runat="server" Enabled="True" />
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblYear" runat="server" Text="<b>Event Year:</b>&nbsp;&nbsp;(i.e. 2007) " CssClass="searchLabels2"></asp:Label></td>
                            <td><asp:TextBox ID="txtYear" runat="server" CssClass="txtBox"/>
                                <asp:RegularExpressionValidator runat="server" ID="regExpressValYear" ControlToValidate="txtYear" ErrorMessage="Please enter a four digit year." SetFocusOnError="True" ValidationExpression="^[0-9]{4}$" Display="Dynamic" />
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblType" runat="server" Text="Record Types:" CssClass="searchLabels"></asp:Label></td>
                            <td><asp:CheckBox ID="cbObits" runat="server" Text=" Obituaries" Checked="True" /><br/>
                                <asp:CheckBox ID="cbCensus" runat="server" Text=" Census" Checked="True" /><br/>
                                <asp:CheckBox ID="cbNatural" runat="server" Text=" Naturalization" Checked="True" />
                            </td>
                        </tr>
                        <tr>
                            <td><br/><br/></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_OnClick" Text="Search" CssClass="btnBox" />&nbsp;&nbsp;
                                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_OnClick" Text="Clear Fields" CssClass="btnBox" />                
                            </td>    
                        </tr>
                 </table>
  </div>
  <div id="search_tabs_1">
            <table>
                <tr>
                    <td>
                        

            <asp:GridView ID="gvSearchList" runat="server" AutoGenerateColumns="False" AllowPaging="true" 
                OnRowDataBound="gvSearchList_OnRowDataBound" PageSize="10" OnPageIndexChanging="gvSearchList_OnPageIndexChanging" DataKeyNames="GN_ID" 
			    EmptyDataText="No results were found matching the search parameters entered." BackColor="White" BorderColor="#4A3C8C" 
			    BorderStyle="None" BorderWidth="1px" CellPadding="2" CellSpacing="2" GridLines="None" CssClass="gvSearchList">
			    <Columns>
                <asp:BoundField DataField="GN_ID" Visible="false" ItemStyle-Width="1px"/>
                <asp:BoundField DataField="FULL_NM" HeaderText="Name" ItemStyle-Width="94px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gvSearchListHeader" />
                <asp:TemplateField HeaderText="Alt Names" ItemStyle-Width="94px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gvSearchListHeader">
                    <ItemTemplate>
                        <%# GetAltNames(Convert.ToInt32(Eval("GN_RECORD_TYPE_CD")), Eval("GN_ID").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Record Type" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gvSearchListHeader">
                    <ItemTemplate>
                        <%# GetRecordType(Convert.ToInt32(Eval("GN_RECORD_TYPE_CD")), Eval("GN_COUNTY").ToString()) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="GN_BIRTH_YEAR_OR_AGE" HeaderText="Birth Year or Age" ItemStyle-Width="72px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderText="Date of Record" ItemStyle-Width="72px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gvSearchListHeader">
                    <ItemTemplate>
                        <%#	GetDateofRecord(Convert.ToInt32(Eval("GN_ID")), Convert.ToInt32(Eval("GN_RECORD_TYPE_CD")), Eval("N_ABBR").ToString(), Eval("GN_DATE_OF_RECORD").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Location" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gvSearchListHeader">
                    <ItemTemplate>
                        <%# GetLocation(Convert.ToInt32(Eval("GN_RECORD_TYPE_CD")), Eval("GN_LOCATION").ToString(), Eval("GN_ID").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="114px" ItemStyle-Width="114px" HeaderStyle-VerticalAlign="Middle">
                    <HeaderTemplate>
                        <asp:Button ID="btnViewCart" runat="server" Text="<%# GetCartQuantity() %>" OnClick="btnViewCart_OnClick" ToolTip="View Cart (# of items in cart)" Width="110px" CssClass="btnBoxViewCart"/>
                    </HeaderTemplate> 
                    <ItemTemplate>
                        <asp:Button ID="btnAddToOrder" runat="server" OnClick="btnAddToOrder_OnClick" Text="Add to Order" Width="110px" CssClass="btnBox btnBoxAddToOrder" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        </td></tr>
                        <tr>
                        <td></td>
                        <td colspan="5">
                            <div id="<%# Eval("GN_ID") %>" style="display: none; position: relative">
                            <asp:GridView ID="gvSearchList_Family" ShowHeader="true" ShowFooter="false" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="CM_FIRST_NM" HeaderText="Other Household Members"  />
                                    <asp:BoundField DataField="CM_AGE" HeaderText="Age" />
                                    <asp:BoundField DataField="CM_PAGE" HeaderText="Location" />
                                </Columns>
                            </asp:GridView> 
                            <asp:GridView ID="gvSearchList_Nat" ShowHeader="true" ShowFooter="false" runat="server"
                                AutoGenerateColumns="true"></asp:GridView>                                       
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
     
        </asp:GridView>
                 </td>
                </tr>
            </table>
  </div>
  <div class="shim"></div>
</div>
 <%--   <ajaxToolkit:TabContainer ID="tcPage" runat="server" ActiveTabIndex="0" OnClientActiveTabChanged="tcPageClientActiveTabChanged">
        <ajaxToolkit:TabPanel ID="searchPanel" HeaderText="Search" runat="server">
            <ContentTemplate>
                <br/>
                <table>
                    <tr>
                        <td><asp:Label runat="server" Text="Last Name:" CssClass="searchLabels"></asp:Label></td>
                        <td><asp:TextBox ID="txtLast" runat="server" CssClass="txtBox" /></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblFirstName" runat="server" Text="First Name:" CssClass="searchLabels"></asp:Label></td>
                            <td><asp:TextBox ID="txtFirst" runat="server" CssClass="txtBox"/></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblCounty" runat="server" Text="County:" CssClass="searchLabels"></asp:Label></td>
                            <td><asp:DropDownList ID="ddlCounty" runat="server" CssClass="countyDdl" Width="148px">
                                    <asp:ListItem Text=" Search All Counties " Selected="True" Value="All"></asp:ListItem>
                                    <asp:ListItem Text=" Portage County      " Value="Portage"></asp:ListItem>
                                    <asp:ListItem Text=" Waupaca County      " Value="Waupaca"></asp:ListItem>
                                    </asp:DropDownList>&nbsp;&nbsp;&nbsp;<a href="Images/state_county.gif" target="_blank" title="County Map" class="countyMap">County Map</a>
                           </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblDate" runat="server" Text="<b>Date obituary was published,</b><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;not date of death (14 Apr 2007):" CssClass="searchLabels2"></asp:Label></td>
                            <td><asp:TextBox ID="txtDate" runat="server" CssClass="txtBox"/>
                                <asp:CustomValidator runat="server" ID="validateDateObit" ControlToValidate="txtDate" EnableClientScript="False" OnServerValidate="ValidateDateObit" ErrorMessage="Please enter a valid date." Display="Dynamic" SetFocusOnError="True" ValidateEmptyText="True" />
                            </td>
                            <ajaxToolkit:CalendarExtender ID="calExtenderDateObitPub" TargetControlID="txtDate" Format="d MMM yyyy" runat="server" Enabled="True" />
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblYear" runat="server" Text="<b>Event Year:</b>&nbsp;&nbsp;(i.e. 2007) " CssClass="searchLabels2"></asp:Label></td>
                            <td><asp:TextBox ID="txtYear" runat="server" CssClass="txtBox"/>
                                <asp:RegularExpressionValidator runat="server" ID="regExpressValYear" ControlToValidate="txtYear" ErrorMessage="Please enter a four digit year." SetFocusOnError="True" ValidationExpression="^[0-9]{4}$" Display="Dynamic" />
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblType" runat="server" Text="Record Types:" CssClass="searchLabels"></asp:Label></td>
                            <td><asp:CheckBox ID="cbObits" runat="server" Text=" Obituaries" Checked="True" /><br/>
                                <asp:CheckBox ID="cbCensus" runat="server" Text=" Census" Checked="True" /><br/>
                                <asp:CheckBox ID="cbNatural" runat="server" Text=" Naturalization" Checked="True" />
                            </td>
                        </tr>
                        <tr>
                            <td><br/><br/></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_OnClick" Text="Search" CssClass="btnBox" />&nbsp;&nbsp;
                                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_OnClick" Text="Clear Fields" CssClass="btnBox" />                
                            </td>    
                        </tr>
                 </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="resultsPanel" HeaderText="Results" runat="server">
            <ContentTemplate>
            <table>
                <tr>
                    <td>
                        

            <asp:GridView ID="gvSearchList" runat="server" AutoGenerateColumns="False" AllowPaging="true" 
                OnRowDataBound="gvSearchList_OnRowDataBound" PageSize="10" OnPageIndexChanging="gvSearchList_OnPageIndexChanging" DataKeyNames="GN_ID" 
			    EmptyDataText="No results were found matching the search parameters entered." BackColor="White" BorderColor="#4A3C8C" 
			    BorderStyle="None" BorderWidth="1px" CellPadding="2" CellSpacing="2" GridLines="None" CssClass="gvSearchList">
			    <Columns>
                <asp:BoundField DataField="GN_ID" Visible="false" ItemStyle-Width="1px"/>
                <asp:BoundField DataField="FULL_NM" HeaderText="Name" ItemStyle-Width="94px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gvSearchListHeader" />
                <asp:TemplateField HeaderText="Alt Names" ItemStyle-Width="94px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gvSearchListHeader">
                    <ItemTemplate>
                        <%# GetAltNames(Convert.ToInt32(Eval("GN_RECORD_TYPE_CD")), Eval("GN_ID").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Record Type" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gvSearchListHeader">
                    <ItemTemplate>
                        <%# GetRecordType(Convert.ToInt32(Eval("GN_RECORD_TYPE_CD")), Eval("GN_COUNTY").ToString()) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="GN_BIRTH_YEAR_OR_AGE" HeaderText="Birth Year or Age" ItemStyle-Width="72px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderText="Date of Record" ItemStyle-Width="72px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gvSearchListHeader">
                    <ItemTemplate>
                        <%#	GetDateofRecord(Convert.ToInt32(Eval("GN_ID")), Convert.ToInt32(Eval("GN_RECORD_TYPE_CD")), Eval("N_ABBR").ToString(), Eval("GN_DATE_OF_RECORD").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Location" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="gvSearchListHeader">
                    <ItemTemplate>
                        <%# GetLocation(Convert.ToInt32(Eval("GN_RECORD_TYPE_CD")), Eval("GN_LOCATION").ToString(), Eval("GN_ID").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="114px" ItemStyle-Width="114px" HeaderStyle-VerticalAlign="Middle">
                    <HeaderTemplate>
                        <asp:Button ID="btnViewCart" runat="server" Text="<%# GetCartQuantity() %>" OnClick="btnViewCart_OnClick" ToolTip="View Cart (# of items in cart)" Width="110px" CssClass="btnBoxViewCart"/>
                    </HeaderTemplate> 
                    <ItemTemplate>
                        <asp:Button ID="btnAddToOrder" runat="server" OnClick="btnAddToOrder_OnClick" Text="Add to Order" Width="110px" CssClass="btnBox btnBoxAddToOrder" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        </td></tr>
                        <tr>
                        <td></td>
                        <td colspan="5">
                            <div id="<%# Eval("GN_ID") %>" style="display: none; position: relative">
                            <asp:GridView ID="gvSearchList_Family" ShowHeader="true" ShowFooter="false" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="CM_FIRST_NM" HeaderText="Other Household Members"  />
                                    <asp:BoundField DataField="CM_AGE" HeaderText="Age" />
                                    <asp:BoundField DataField="CM_PAGE" HeaderText="Location" />
                                </Columns>
                            </asp:GridView> 
                            <asp:GridView ID="gvSearchList_Nat" ShowHeader="true" ShowFooter="false" runat="server"
                                AutoGenerateColumns="true"></asp:GridView>                                       
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
     
        </asp:GridView>
                            </td>
                </tr>
            </table>
        </ContentTemplate>
      </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer> --%>
    
    <asp:Button ID="btnPhantom" runat="server" Text="phantom" CssClass="hiddenbtn" />
        
    <ajaxToolkit:ModalPopupExtender ID="mpeShoppingCart" RepositionMode="None" runat="server" PopupControlID="pnlShoppingCart"
           BackgroundCssClass="modalBackground" TargetControlID="btnPhantom" PopupDragHandleControlID="pnlShoppingCart" X="0" Y="0">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlShoppingCart" runat="server" CssClass="modalPopup" HorizontalAlign="Center" Width="730px">
        <table class="pnlShoppingCartTable">
            <tr>
                <td colspan="3" align="center">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="false" Width="100%" ShowFooter="true" DataKeyNames="GN_ID" OnRowDeleting="gvCart_OnRowDeleting">
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnCloseCart" runat="server" Text="Continue searching" OnClick="btnCloseCart_OnClick" CssClass="btnBox" />
                </td>
                <td>
                    <asp:Button ID="btnCheckoutCredit" runat="server" Text="Pay with Credit Card" OnClick="btnCheckoutCredit_OnClick" CssClass="btnBox"/>  
                </td>
                <td>
                    <asp:Button ID="btnCheckoutPrint" runat="server" Text="Print A Mail Order Form" OnClick="btnCheckoutPrint_OnClick" CssClass="btnBox"/>             
                </td>
            </tr>
        </table>  
     </asp:Panel>  
    </div>
        <br/>  
        <br/>  
     <div class="Lib_footer">
        <asp:Table ID="footerJointProjects" runat="server" CssClass="libfooterTable">
            <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell ID="TableCell1" runat="server" CssClass="jointProjectsCell">
                    <asp:Label ID="jointProjectsLabel" runat="server" Text="Joint projects of the:" CssClass="jointProjectsLabelStyle" />
                </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow2" runat="server">
                <asp:TableCell ID="TableCell2" runat="server" CssClass="jointProjectsCell">
                    <asp:Label ID="Label6" runat="server" Text="UWSP University Archives" />
                </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow3" runat="server">
                <asp:TableCell ID="TableCell3" runat="server" CssClass="jointProjectsCell">
                    <asp:Label ID="Label7" runat="server" Text="Portage County Public Library" />
                </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow4" runat="server">
                <asp:TableCell ID="TableCell4" runat="server" CssClass="jointProjectsCell">
                    <asp:Label ID="Label8" runat="server" Text="Stevens Point Area Genealogical Society" />
                </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow5" runat="server">
                <asp:TableCell ID="TableCell5" runat="server" CssClass="jointProjectsCell">
                    <asp:Label ID="Label9" runat="server" Text="Waupaca Area Genealogical Society" />
                </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow6" runat="server">
                <asp:TableCell ID="TableCell6" runat="server" CssClass="jointProjectsCell">
                    <asp:Label ID="Label10" runat="server" Text=" " />
                </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow7" runat="server">
                <asp:TableCell ID="TableCell7" runat="server" CssClass="jointProjectsCell">
                    <asp:Label ID="Label11" runat="server">
                        For Genealogy Index problems or feedback, 
         <a href="mailto:archives@uwsp.edu?subject=Feedback" class="contactUnivArch">Contact University Archives</a> 
         715-346-2586
                    </asp:Label>
                </asp:TableCell></asp:TableRow></asp:Table><br />
  </div>
 </div>
 </ContentTemplate>
 </asp:UpdatePanel>

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
                    rows[i].cells[7].style.display = "none"; } catch (Error) { };
            }
        }
    </script>
    
 
    </asp:Content>