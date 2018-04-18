<%@ Page Language="C#" MasterPageFile="~/addins_app/app_child.master" AutoEventWireup="True" CodeFile="Login.aspx.cs" Inherits="Login" %>
 
 <asp:Content id="DefaultHead" ContentPlaceHolderID="ContentPlaceHolderDefaultHead" runat="server">
     <link rel="stylesheet" href="assets/css/default.css" media="screen" type="text/css" />
 </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="headerPlaceHolder" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="mainContent">
			<p>
				<asp:Label id="lblError" runat="server"></asp:Label></p>
			<p>
				<asp:Label id="usernameLabel" runat="server"><b>User Name: </b></asp:Label>&nbsp;
				<asp:TextBox id="txtUserName" runat="server" CssClass="txtBox"></asp:TextBox></p>
			<p>
				<asp:Label id="passwordLabel" runat="server"><b>Password: </b></asp:Label>&nbsp;&nbsp;&nbsp;
			    <asp:TextBox id="txtPassword" runat="server" TextMode="Password" CssClass="txtBox"></asp:TextBox><br/>&nbsp;&nbsp;&nbsp;
				<asp:CheckBox id="persistCheckBox" runat="server" Text="Persist Security Info"></asp:CheckBox></p>
			<p>
				<asp:Button id="loginButton" runat="server" Text="Login" onclick="loginButton_Click" CssClass="btnBox"></asp:Button></p>
</div>
</asp:Content>