<%@ Page Language="C#" MasterPageFile="~/addins_app/app_child.master" AutoEventWireup="true" CodeFile="OrdersAdmin.aspx.cs" Inherits="OrdersAdmin" %>

<asp:Content id="DefaultHead" ContentPlaceHolderID="ContentPlaceHolderDefaultHead" runat="server">
   <link rel="stylesheet" href="assets/css/default.css" media="screen" type="text/css" />
 </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="headerPlaceHolder" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="mainContent">
    <strong><font face="Arial" size="5">Orders Admin Page</font> <font face="Arial" size="2">
					(go back to the <a href="default.aspx">Main Search Page</a> or
					<asp:LinkButton ID="btnLogout" Runat="server" Text="logout" OnClick="btnLogout_Click" />) </font>
			</strong>			
            <p><asp:Label ID="Label1" runat="server" Text="Show the most recent" />
	<asp:TextBox ID="recordCountTextBox" runat="server" Width="35px" Text="20" CssClass="txtBox"/>
	<asp:Label ID="Label2" runat="server" Text="records" />
	<asp:Button ID="btnMostRecent" runat="server" Text="Go!" OnClick="btnMostRecent_OnClick" CssClass="btnBox"/></p>
	<p><asp:Label ID="Label3" runat="server" Text="Show all records created between" />
<asp:TextBox ID="txtStartDate" runat="server" Width="70px" CssClass="txtBox"/>
<asp:Label ID="Label4" runat="server" Text="and" />
<asp:TextBox ID="txtEndDate" runat="server" Width="70px" CssClass="txtBox"/>
<asp:Button ID="btnBetweenDates" runat="server" Text="Go!" OnClick="btnBetweenDates_OnClick" CssClass="btnBox"/></p>
<p><asp:Label ID="Label6" runat="server" Text="Show all payment verified orders that are not completed (we need to ship to them)" />
<asp:Button ID="btnVerifiedOrders" runat="server" Text="Go!" OnClick="btnVerifiedOrders_OnClick" CssClass="btnBox"/></P>
<p><asp:Label ID="Label5" runat="server" Text="Search by Customer Name" />
	<asp:TextBox ID="txtCust" runat="server" CssClass="txtBox"/><asp:Button ID="btnCust" runat="server" Text="Search" OnClick="btnCust_OnClick" CssClass="btnBox"/></P>
<p><asp:Label ID="lblError" runat="server" Width="74px" /></p>

	<asp:DataGrid ID="dgOrders" runat="server" AutoGenerateColumns="False"	
            OnSelectedIndexChanged="dgOrders_SelectedIndexChanged" Width="747px">
		<AlternatingItemStyle BackColor="Silver"></AlternatingItemStyle>
		<ItemStyle Font-Size="X-Small" Font-Names="Verdana" BackColor="White"></ItemStyle>
		<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="White" BackColor="Purple"></HeaderStyle>
		<Columns>
			<asp:BoundColumn DataField="OrderID" HeaderText="Order ID"></asp:BoundColumn>
			<asp:BoundColumn DataField="DateCreated" HeaderText="Date Created"></asp:BoundColumn>
			<asp:BoundColumn DataField="DateShipped" HeaderText="Date Shipped"></asp:BoundColumn>
			<asp:BoundColumn DataField="Verified" HeaderText="Payment Verified"></asp:BoundColumn>
			<asp:BoundColumn DataField="Completed" HeaderText="Completed"></asp:BoundColumn>
			<asp:BoundColumn DataField="Canceled" HeaderText="Canceled"></asp:BoundColumn>
			<asp:BoundColumn DataField="CustomerName" HeaderText="Customer"></asp:BoundColumn>
			<asp:ButtonColumn Text="View Details" ButtonType="PushButton" CommandName="Select" ItemStyle-CssClass="btnBox"></asp:ButtonColumn>
		</Columns>
	</asp:DataGrid>
	</div>
</asp:Content>
