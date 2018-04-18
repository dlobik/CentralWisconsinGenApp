<%@ Page Language="C#" MasterPageFile="~/addins_app/app_child.master" AutoEventWireup="true" CodeFile="OrderDetails.aspx.cs" Inherits="OrderDetails" %>

<asp:Content id="DefaultHead" ContentPlaceHolderID="ContentPlaceHolderDefaultHead" runat="server">
   <link rel="stylesheet" href="assets/css/default.css" media="screen" type="text/css" />
 </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="headerPlaceHolder" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="mainContent">
			<table id="Table1" cellspacing="1" cellpadding="1" width="300" border="1">
	<tr>
		<td align="center" colspan="3"><asp:label Runat="server" Font-Size="X-Large" Font-Bold="True" Font-Underline="True">Order Details Page</asp:label></td>
	</tr>
	<tr>
		<td><asp:label id="Label1" runat="server" width="150px">Order ID:</asp:label></td>
		<td colspan="2"><asp:textbox id="orderIDTextBox" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:label id="Label20" runat="server" width="150px">Transaction ID:</asp:label></td>
		<td colspan="2"><asp:textbox id="TransID" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:label id="Label2" runat="server" width="150px">Total Amount:</asp:label></td>
		<td colspan="2"><asp:label id="totalAmountLabel" runat="server"></asp:label></td>
	</tr>
	<tr>
		<td><asp:label id="Label4" runat="server" width="150px">Date Created:</asp:label></td>
		<td colspan="2"><asp:textbox id="dateCreatedTextBox" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:label id="Label5" runat="server" width="150px">Date Shipped:</asp:label></td>
		<td colspan="2"><asp:textbox id="dateShippedTextBox" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:label id="Label6" runat="server" width="150px">Payment Verified:</asp:label></td>
		<td colspan="2"><asp:textbox id="verifiedTextBox" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:label id="Label7" runat="server" width="150px">Completed:</asp:label></td>
		<td colspan="2"><asp:textbox id="completedTextBox" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:label id="Label8" runat="server" width="150px">Canceled:</asp:label></td>
		<td colspan="2"><asp:textbox id="canceledTextBox" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:label id="Label9" runat="server" width="150px">Comments:</asp:label></td>
		<td colspan="2"><asp:textbox id="commentsTextBox" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:label id="Label10" runat="server" width="150px">Customer Last Name:</asp:label></td>
		<td colspan="2"><asp:textbox id="tbLast" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:label id="Label19" runat="server" width="150px">Customer First Name:</asp:label></td>
		<td colspan="2"><asp:textbox id="tbFirst" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:label id="Label11" runat="server" width="150px">Shipping Address1:</asp:label></td>
		<td colspan="2"><asp:textbox id="shippingAddressTextBox" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:label id="Label3" runat="server" width="150px">Shipping Address2:</asp:label></td>
		<td colspan="2"><asp:textbox id="tbAdd2" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:label id="Label13" runat="server">City:</asp:label></td>
		<td colspan="2"><asp:textbox id="tbCity" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:label id="Label14" runat="server">State:</asp:label></td>
		<td colspan="2"><asp:textbox id="tbState" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:label id="Label15" runat="server">Zip Code:</asp:label></td>
		<td colspan="2"><asp:textbox id="tbZip" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:label id="Label16" runat="server">Country:</asp:label></td>
		<td colspan="2"><asp:textbox id="tbCountry" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:label id="Label17" runat="server">Province:</asp:label></td>
		<td colspan="2"><asp:textbox id="tbProvince" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:label id="Label18" runat="server">Postal Code:</asp:label></td>
		<td colspan="2"><asp:textbox id="tbPostalCode" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:label id="Label12" runat="server" width="150px">Customer Email:</asp:label></td>
		<td colspan="2"><asp:textbox id="txtEmail" runat="server" width="400px"></asp:textbox></td>
	</tr>
	<tr>
		<td align="center" colspan="3"><asp:button id="updateButton" runat="server" width="100px" Text="Update" onclick="updateButton_Click" CssClass="btnBox"></asp:button></td>
	</tr>
	<tr>
		<td align="center" colspan="3"><asp:button id="markAsCompletedButton" runat="server" width="347px" Text="Mark this order as completed (send email to customer)" CssClass="btnBox" onclick="markAsCompletedButton_Click"></asp:button></td>
	</tr>
	<tr>
		<td colspan="3" align="center">
			<asp:Button id="markAsCanceledButton" runat="server" Text="Cancel This Order" width="302px" CssClass="btnBox"></asp:Button>
		</td>
	</tr>
	<tr>
		<td colspan="3" align="center">
			<asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="false" AutoGenerateDeleteButton="true"
                Width="100%" ShowFooter="true" DataKeyNames="GN_ID">
            <AlternatingRowStyle BackColor="WhiteSmoke" />
            <HeaderStyle BackColor="WhiteSmoke" Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" />
            <RowStyle Font-Size="X-Small" Font-Names="Verdana" BackColor="White" />		
		    <Columns>
				    <asp:BoundField DataField="FULL_NAME" HeaderText="Name"></asp:BoundField>
				    <asp:TemplateField HeaderText="Record Type">
                        <ItemTemplate>
                            <%# GetRecordType(Convert.ToInt32(Eval("GN_RECORD_TYPE_CD")), Eval("GN_COUNTY").ToString()) %>
                        </ItemTemplate>
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="Date of Record">
                        <ItemTemplate>
                            <%#	GetDateofRecord(Convert.ToInt32(Eval("GN_ID")), Convert.ToInt32(Eval("GN_RECORD_TYPE_CD")), Eval("N_ABBR").ToString(), Eval("GN_DATE_OF_RECORD").ToString())%>
                        </ItemTemplate>                    
                        <FooterTemplate>
                            <%# GetOrderTotal() %>
                        </FooterTemplate>
                        <FooterStyle Font-Bold="true" Font-Size="Small" />                    
                    </asp:TemplateField>
                <asp:BoundField DataField="LOCATION" HeaderText="Location"></asp:BoundField>
				    <asp:TemplateField HeaderText="Location" >
                    <ItemTemplate>
                        <%# GetLocation(Convert.ToInt32(Eval("GN_RECORD_TYPE_CD")), Eval("LOCATION").ToString(), Eval("GN_ID").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                
		    </Columns>		
        </asp:GridView>
		</td>
	</tr>
</table>
	</div>
</asp:Content>