<%@ Page Language="C#" MasterPageFile="~/addins_app/app_child.master" AutoEventWireup="True" CodeFile="CustomerReceipt.aspx.cs" Inherits="CustomerReceipt" %>

<asp:Content id="DefaultHead" ContentPlaceHolderID="ContentPlaceHolderDefaultHead" runat="server">
   <link rel="stylesheet" href="assets/css/default.css" media="screen" type="text/css" />
 </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="headerPlaceHolder" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="mainContent">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="458" border="1">
				<TR>
					<TD align="center" colSpan="2"><asp:label id="Label5" runat="server" Font-Underline="True" Font-Size="X-Large" Font-Bold="True">UWSP Archives Order Receipt</asp:label></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="2">Requests are answered on a first come, first served 
						basis and are processed as staff time permits. Depending on the backlog, the 
						turn around time for answering requests ranges from two to four weeks. If you 
						have not received the material you requested within <FONT face="Bookman Old Style" color="#ff0000">
							five weeks</FONT>, feel free to contact us and inquire as to the status of 
						your request.
                        </TD>
				</TR>
				<TR>
					<TD><asp:label id="Label18" runat="server">Transaction #:</asp:label></TD>
					<TD><asp:label id="lblTransID" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label2" runat="server">Name:</asp:label></TD>
					<TD><asp:label id="lblName" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label4" runat="server">Shipping Address (Line 1):</asp:label></TD>
					<TD><asp:label id="lblAdd1" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label6" runat="server">Shipping Address (Line 2):</asp:label></TD>
					<TD><asp:label id="lblAdd2" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label7" runat="server">City:</asp:label></TD>
					<TD><asp:label id="lblCity" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblStateOrProvince" runat="server">State:</asp:label></TD>
					<TD><asp:label id="lblState" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblZipOrPost" runat="server">Zipcode:</asp:label></TD>
					<TD><asp:label id="lblZip" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="Label9" runat="server">Country:</asp:Label></TD>
					<TD>
						<asp:Label id="lblCountry" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="Label10" runat="server">Province:</asp:Label></TD>
					<TD>
						<asp:Label id="lblProvince" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="Label11" runat="server">Postal Code:</asp:Label></TD>
					<TD>
						<asp:Label id="lblPostalCode" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label14" runat="server">Credit Card #:</asp:label></TD>
					<TD><asp:label id="lblCC" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label15" runat="server">Expiration Date:</asp:label></TD>
					<TD><asp:label id="lblExp" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label16" runat="server">Name on Card:</asp:label></TD>
					<TD><asp:label id="lblCName" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label17" runat="server">Amount (in U.S. dollars):</asp:label></TD>
					<TD><asp:label id="lblAmt" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label3" runat="server">Order ID#:</asp:label></TD>
					<TD><asp:label id="lblOID" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label8" runat="server">Email:</asp:label></TD>
					<TD><asp:label id="lblEmail" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<%--<asp:datagrid id="dgCart" runat="server" AutoGenerateColumns="False">
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" BackColor="Silver"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" BackColor="#FF66FF"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="CH_ID" HeaderText="CH_ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="CH_LAST_NM" ReadOnly="True" HeaderText="Family Name"></asp:BoundColumn>
								<asp:BoundColumn DataField="CH_FIRST_NM" ReadOnly="True" HeaderText="Head First name"></asp:BoundColumn>
								<asp:BoundColumn DataField="CH_PAGE" ReadOnly="True" HeaderText="Page"></asp:BoundColumn>
								<asp:BoundColumn DataField="CT_NAME" ReadOnly="True" HeaderText="Township"></asp:BoundColumn>
								<asp:BoundColumn DataField="CH_YEAR" ReadOnly="True" HeaderText="Year"></asp:BoundColumn>
								<asp:BoundColumn DataField="Quantity" HeaderText="No. of Copies"></asp:BoundColumn>
							</Columns>
						</asp:datagrid>--%>
		<asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="false" AutoGenerateDeleteButton="true"
              Width="100%" ShowFooter="true" DataKeyNames="GN_ID">
            <AlternatingRowStyle BackColor="WhiteSmoke" />
            <HeaderStyle BackColor="WhiteSmoke" Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" />
            <RowStyle Font-Size="X-Small" Font-Names="Verdana" BackColor="White" />		
		    <Columns>
				    <asp:BoundField DataField="FULL_NM" HeaderText="Name"></asp:BoundField>
				    <asp:TemplateField HeaderText="Record Type">
                        <ItemTemplate>
                            <%# GetRecordType(Convert.ToInt32(Eval("GN_RECORD_TYPE_CD")), Eval("GN_COUNTY").ToString()) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="QUANTITY" HeaderText="No. of Copies" />
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate><%# GetDollarSign(Eval("SUBTOTAL").ToString()) %></ItemTemplate>
                        <FooterTemplate><%# GetOrderTotal() %></FooterTemplate>
                        <FooterStyle Font-Bold="true" Font-Size="Small" />
                    </asp:TemplateField>
		    </Columns>		
        </asp:GridView></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<asp:ImageButton id="btnPrint" runat="server" onmouseover="this.src='images/PrintReceiptButtonAlt.gif';"
							onmouseout="this.src='images/PrintReceiptButton.gif';" AlternateText="Print the receipt" ImageUrl="images/PrintReceiptButton.gif" OnClick="btnPrint_OnClick"></asp:ImageButton></TD>
				</TR>
			</TABLE>

	</div>
</asp:Content>