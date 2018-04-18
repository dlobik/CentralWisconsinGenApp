<%@ Page Language="C#" MasterPageFile="~/addins_app/app_child.master" AutoEventWireup="true"  CodeFile="Search.aspx.cs" Inherits="Search" %>


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
     <br/><br/> 
     <div>  
        <table width="100%"><tr><td align="center" class="style1" valign="middle"> 
            <asp:Label ID="Label5" Text="Central Wisconsin Genealogy Index" Font-Bold="True" runat="server" 
            CssClass="ClassHeading"></asp:Label>
            </td></tr> 
            <tr><td align="center" class="style1" valign="middle"> 
            <asp:Label ID="Label12" Text="Search" Font-Bold="True" runat="server" 
            CssClass="ClassHeading"></asp:Label>
            </td></tr> 
        </table>
     </div>
     <div>
           <table width="100%">
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Last Name:" CssClass="searchLabels"></asp:Label></td>
                <td><asp:TextBox ID="txtLast" runat="server" CssClass="txtBox" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label2" runat="server" Text="First Name:" CssClass="searchLabels"></asp:Label></td>
                <td><asp:TextBox ID="txtFirst" runat="server" CssClass="txtBox"/></td>
            </tr>
            <tr>
                <td><asp:Label runat="server" Text="County:" CssClass="searchLabels"></asp:Label></td>
                <td><asp:DropDownList ID="ddlCounty" runat="server" CssClass="countyDdl">
                        <asp:ListItem Text=" Search All Counties " Selected="True" Value="All"></asp:ListItem>
                        <asp:ListItem Text=" Portage County      " Value="Portage"></asp:ListItem>
                        <asp:ListItem Text=" Waupaca County      " Value="Waupaca"></asp:ListItem>
                    </asp:DropDownList>&nbsp;&nbsp;&nbsp;
                    <a href="Images/state_county.gif" target="_blank" title="County Map" class="countyMap">County Map</a></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label3" runat="server" Text="<b>Date obituary was published,</b><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;not date of death (14 Apr 2007):" CssClass="searchLabels2"></asp:Label></td>
                <td><asp:TextBox ID="txtDate" runat="server" CssClass="txtBox"/>
                <asp:CustomValidator runat="server" ID="validateDateObit" ControlToValidate="txtDate" EnableClientScript="False" OnServerValidate="ValidateDateObit" ErrorMessage="Please enter a valid date." Display="Dynamic" SetFocusOnError="True" ValidateEmptyText="True" />
                </td>
                <ajaxToolkit:CalendarExtender ID="calExtenderDateObitPub" TargetControlID="txtDate" Format="d MMM yyyy" runat="server" Enabled="True"/>
            </tr>
            <tr>
                <td><asp:Label ID="Label4" runat="server" Text="Event Year:" CssClass="searchLabels"></asp:Label></td>
                <td><asp:TextBox ID="txtYear" runat="server" CssClass="txtBox"/>
                <asp:RegularExpressionValidator runat="server" ID="regExpressValYear" ControlToValidate="txtYear" ErrorMessage="Please enter a four digit year." SetFocusOnError="True" ValidationExpression="^[0-9]{4}$" Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td><asp:Label runat="server" Text="Record Types:" CssClass="searchLabels"></asp:Label></td>
                <td><asp:CheckBox ID="cbObits" runat="server" Text=" Obituaries" Checked="True" /><br/>
                    <asp:CheckBox ID="cbCensus" runat="server" Text=" Census" Checked="True" /><br/>
                    <asp:CheckBox ID="cbNatural" runat="server" Text=" Naturalization" 
                        Checked="True" />
                </td>
            </tr>
            <tr><td><br/><br/></td></tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_OnClick" Text="Search" CssClass="btnBox" />&nbsp;&nbsp;
                    <asp:Button ID="btnClear" runat="server" OnClick="btnClear_OnClick" Text="Clear Fields" CssClass="btnBox" />                
                </td>    
            </tr>
            </table>
            </div>
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
    </div>
</asp:Content>