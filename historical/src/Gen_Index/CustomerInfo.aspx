<%@ Page Language="C#" MasterPageFile="~/addins_app/app_child.master" CodeFile="CustomerInfo.aspx.cs" AutoEventWireup="True" Inherits="CustomerInfo" %>

<asp:Content id="DefaultHead" ContentPlaceHolderID="ContentPlaceHolderDefaultHead" runat="server">
   <link rel="stylesheet" href="assets/css/default.css" media="screen" type="text/css" />
 </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="headerPlaceHolder" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="mainContent">
			<table id="Table1" style="WIDTH: 747px; cellspacing="0" cellPadding="0" border="0">
				<tr>
				    <td vAlign="top" width="15%" style="padding-left: 40px;">
						<IMG height="108" alt="A Joint Project of the UWSP Library and the Portage County Public Library" hspace="0" src="Images/pcmapsmall2.gif" width="103" align="left" border="0">
					</td>
					<td vAlign="middle" noWrap><em><strong><font face="Bookman Old Style" size="5">Central Wisconsin Genealogy Index</font></strong></em>
						<hr style="WIDTH: 99.68%; HEIGHT: 5px" align="left" width="99.68%" noShade SIZE="5">
                    </td>
				</tr>
				<tr>
					<td align="center" colSpan="2"><asp:label id="Label9" runat="server" Width="460px" Font-Bold="True" Font-Size="Large">Step 1 - Name and Address Information</asp:label></td>
				</tr>
				<tr>
					<td align="center" colSpan="2">
						<asp:Label id="Label16" runat="server" ForeColor="Red">***Fields in red are required***</asp:Label></td>
				</tr>
				<tr>
					<td colSpan="3"></td>
					</tr>
					</table>
				<table id="Table2" style="WIDTH: 747px; mso-cellspacing="0" cellPadding="0" border="0">
				<tr>
					<td style="padding-left: 40px;"><asp:label id="Label1" runat="server" ForeColor="Red">First Name:</asp:label></td>
					<td><asp:textbox id="txtFirst" runat="server" BackColor="#FFFFC0" CssClass="txtBox" Width="230px"></asp:textbox>&nbsp;&nbsp; 
					<asp:Label runat="server" ID="lblFNameErr" ForeColor="Red" Text="First name is required." Visible="False"></asp:Label></td>
				</tr>
				<tr>
					<td style="padding-left: 40px;"><asp:label id="Label8" runat="server" ForeColor="Red">Last Name:</asp:label></td>
					<td><asp:textbox id="txtLast" runat="server" BackColor="#FFFFC0" CssClass="txtBox" Width="230px"></asp:textbox> &nbsp;&nbsp; 
					<asp:Label runat="server" ID="lblLNameErr" ForeColor="Red" Text="Last name is required." Visible="False"></asp:Label></td>
				</tr>
				<tr>
					<td style="padding-left: 40px;"><asp:label id="Label2" runat="server" ForeColor="Red">Shipping Address Line 1:</asp:label></td>
					<td><asp:textbox id="txtAdd1" runat="server" BackColor="#FFFFC0" CssClass="txtBox"  Width="230px"></asp:textbox>&nbsp;&nbsp;  
					<asp:Label runat="server" ID="lblAddrErr" ForeColor="Red" Text="Address is required." Visible="False"></asp:Label></td>					
				</tr>
				<tr>
					<td style="padding-left: 40px;"><asp:label id="Label5" runat="server">Shipping Address Line 2:</asp:label></td>
					<td><asp:textbox id="txtAdd2" runat="server" BackColor="#FFFFC0" CssClass="txtBox" Width="230px"></asp:textbox></td>
				
				</tr>
				<tr>
					<td style="padding-left: 40px;"><asp:label id="Label3" runat="server" ForeColor="Red">City:</asp:label></td>
					<td><asp:textbox id="txtCity" runat="server" BackColor="#FFFFC0" CssClass="txtBox" Width="230px"></asp:textbox>&nbsp;&nbsp;  
					<asp:Label runat="server" ID="lblCityErr" ForeColor="Red" Text="City is required." Visible="False"></asp:Label></td>					
				</tr>
				<tr>
					<td style="padding-left: 40px;"><asp:label id="Label6" runat="server" ForeColor="Red">State:</asp:label></td>
					<td><asp:dropdownlist id="ddlState" runat="server" BackColor="#FFFFC0" CssClass="countyDdl">
					        <asp:ListItem Value="AK - Alaska">AK - Alaska</asp:ListItem>
							<asp:ListItem Value="AL - Alabama">AL - Alabama</asp:ListItem>
							<asp:ListItem Value="AR - Arkansas">AR - Arkansas</asp:ListItem>
							<asp:ListItem Value="AZ - Arizona">AZ - Arizona</asp:ListItem>
							<asp:ListItem Value="CA - California">CA - California</asp:ListItem>
							<asp:ListItem Value="CT - Connecticut">CT - Connecticut</asp:ListItem>
							<asp:ListItem Value="CO - Colorado">CO - Colorado</asp:ListItem>
							<asp:ListItem Value="DC - District of Columbia">DC - District of Columbia</asp:ListItem>
							<asp:ListItem Value="DE - Delaware">DE - Delaware</asp:ListItem>
							<asp:ListItem Value="FL - Florida">FL - Florida</asp:ListItem>
							<asp:ListItem Value="GA - Georgia">GA - Georgia</asp:ListItem>
							<asp:ListItem Value="HI - Hawaii">HI - Hawaii</asp:ListItem>
							<asp:ListItem Value="IA - Iowa">IA - Iowa</asp:ListItem>
							<asp:ListItem Value="ID - Idaho">ID - Idaho</asp:ListItem>
							<asp:ListItem Value="IN - Indiana">IN - Indiana</asp:ListItem>
							<asp:ListItem Value="IL - Illinois">IL - Illinois</asp:ListItem>
							<asp:ListItem Value="KS - Kansas">KS - Kansas</asp:ListItem>
							<asp:ListItem Value="KY - Kentucky">KY - Kentucky</asp:ListItem>
							<asp:ListItem Value="LA - Louisiana">LA - Louisiana</asp:ListItem>
							<asp:ListItem Value="MA - Massachusetts">MA - Massachusetts</asp:ListItem>
							<asp:ListItem Value="MD - Maryland">MD - Maryland</asp:ListItem>
							<asp:ListItem Value="ME - Maine">ME - Maine</asp:ListItem>
							<asp:ListItem Value="MI - Michigan">MI - Michigan</asp:ListItem>
							<asp:ListItem Value="MN - Minnesota">MN - Minnesota</asp:ListItem>
							<asp:ListItem Value="MO - Missouri">MO - Missouri</asp:ListItem>
							<asp:ListItem Value="MS - Mississippi">MS - Mississippi</asp:ListItem>
							<asp:ListItem Value="MT - Montana">MT - Montana</asp:ListItem>
							<asp:ListItem Value="NC - North Carolina">NC - North Carolina</asp:ListItem>
							<asp:ListItem Value="ND - North Dakota">ND - North Dakota</asp:ListItem>
							<asp:ListItem Value="NE - Nebraska">NE - Nebraska</asp:ListItem>
							<asp:ListItem Value="NH - New Hampshire">NH - New Hampshire</asp:ListItem>
							<asp:ListItem Value="NJ - New Jersey">NJ - New Jersey</asp:ListItem>
							<asp:ListItem Value="NM - New Mexico">NM - New Mexico</asp:ListItem>
							<asp:ListItem Value="NV - Nevada">NV - Nevada</asp:ListItem>
							<asp:ListItem Value="NY - New York">NY - New York</asp:ListItem>
							<asp:ListItem Value="OH - Ohio">OH - Ohio</asp:ListItem>
							<asp:ListItem Value="OK - Oklahoma">OK - Oklahoma</asp:ListItem>
							<asp:ListItem Value="OR - Oregon">OR - Oregon</asp:ListItem>
							<asp:ListItem Value="PA - Pennsylvania">PA - Pennsylvania</asp:ListItem>
							<asp:ListItem Value="RI - Rhode Island">RI - Rhode Island</asp:ListItem>
							<asp:ListItem Value="SC - South Carolina">SC - South Carolina</asp:ListItem>
							<asp:ListItem Value="SD - South Dakota">SD - South Dakota</asp:ListItem>
							<asp:ListItem Value="TN - Tennessee">TN - Tennessee</asp:ListItem>
							<asp:ListItem Value="TX - Texas">TX - Texas</asp:ListItem>
							<asp:ListItem Value="UT - Utah">UT - Utah</asp:ListItem>
							<asp:ListItem Value="VA - Virginia">VA - Virginia</asp:ListItem>
							<asp:ListItem Value="VT - Vermont">VT - Vermont</asp:ListItem>
							<asp:ListItem Value="WA - Washington">WA - Washington</asp:ListItem>
							<asp:ListItem Value="WI - Wisconsin" Selected="True">WI - Wisconsin</asp:ListItem>
							<asp:ListItem Value="WV - West Virginia">WV - West Virginia</asp:ListItem>
							<asp:ListItem Value="WY - Wyoming">WY - Wyoming</asp:ListItem>
							<asp:ListItem Value="NotInUS">Not In US</asp:ListItem>
						</asp:dropdownlist>&nbsp; &nbsp; 
					<asp:Label runat="server" ID="lblStateErr" ForeColor="Red" Text="Select 'Not In US' if country is not United States." Visible="False"></asp:Label></td>
	 
				</tr>
				<tr>
					<td style="padding-left: 40px;"><asp:label id="Label11" runat="server">Country:</asp:label></td>
					<td>
                        <asp:dropdownlist id="ddlCountry" runat="server" BackColor="#FFFFC0" Width="235px" CssClass="countyDdl">
							<asp:ListItem Value="Afghanistan">Afghanistan</asp:ListItem>
							<asp:ListItem Value="Albania">Albania</asp:ListItem>
							<asp:ListItem Value="Algeria">Algeria</asp:ListItem>
							<asp:ListItem Value="American Samoa">American Samoa</asp:ListItem>
							<asp:ListItem Value="Andorra">Andorra</asp:ListItem>
							<asp:ListItem Value="Angola">Angola</asp:ListItem>
							<asp:ListItem Value="Anguilla">Anguilla</asp:ListItem>
							<asp:ListItem Value="Antarctica">Antarctica</asp:ListItem>
							<asp:ListItem Value="Antigua and Barbuda">Antigua and Barbuda</asp:ListItem>
							<asp:ListItem Value="Argentina">Argentina</asp:ListItem>
							<asp:ListItem Value="Armenia">Armenia</asp:ListItem>
							<asp:ListItem Value="Aruba">Aruba</asp:ListItem>
							<asp:ListItem Value="Australia">Australia</asp:ListItem>
							<asp:ListItem Value="Austria">Austria</asp:ListItem>
							<asp:ListItem Value="Azerbaijan">Azerbaijan</asp:ListItem>
							<asp:ListItem Value="Bahamas">Bahamas</asp:ListItem>
							<asp:ListItem Value="Bahrain">Bahrain</asp:ListItem>
							<asp:ListItem Value="Bangladesh">Bangladesh</asp:ListItem>
							<asp:ListItem Value="Barbados">Barbados</asp:ListItem>
							<asp:ListItem Value="Belarus">Belarus</asp:ListItem>
							<asp:ListItem Value="Belgium">Belgium</asp:ListItem>
							<asp:ListItem Value="Belize">Belize</asp:ListItem>
							<asp:ListItem Value="Benin">Benin</asp:ListItem>
							<asp:ListItem Value="Bermuda">Bermuda</asp:ListItem>
							<asp:ListItem Value="Bhutan">Bhutan</asp:ListItem>
							<asp:ListItem Value="Bolivia">Bolivia</asp:ListItem>
							<asp:ListItem Value="Bosnia and Herzegovina">Bosnia and Herzegovina</asp:ListItem>
							<asp:ListItem Value="Botswana">Botswana</asp:ListItem>
							<asp:ListItem Value="Bouvet Island">Bouvet Island</asp:ListItem>
							<asp:ListItem Value="Brazil">Brazil</asp:ListItem>
							<asp:ListItem Value="British Indian Ocean Territory">British Indian Ocean Territory</asp:ListItem>
							<asp:ListItem Value="Brunei Darussalam">Brunei Darussalam</asp:ListItem>
							<asp:ListItem Value="Bulgaria">Bulgaria</asp:ListItem>
							<asp:ListItem Value="Burkina Faso">Burkina Faso</asp:ListItem>
							<asp:ListItem Value="Burundi">Burundi</asp:ListItem>
							<asp:ListItem Value="Cambodia">Cambodia</asp:ListItem>
							<asp:ListItem Value="Cameroon">Cameroon</asp:ListItem>
							<asp:ListItem Value="Canada">Canada</asp:ListItem>
							<asp:ListItem Value="Cape Verde">Cape Verde</asp:ListItem>
							<asp:ListItem Value="Cayman Islands">Cayman Islands</asp:ListItem>
							<asp:ListItem Value="Central African Republic">Central African Republic</asp:ListItem>
							<asp:ListItem Value="Chad">Chad</asp:ListItem>
							<asp:ListItem Value="Chile">Chile</asp:ListItem>
							<asp:ListItem Value="China">China</asp:ListItem>
							<asp:ListItem Value="Christmas Island">Christmas Island</asp:ListItem>
							<asp:ListItem Value="Cocos (Keeling Islands)">Cocos (Keeling Islands)</asp:ListItem>
							<asp:ListItem Value="Colombia">Colombia</asp:ListItem>
							<asp:ListItem Value="Comoros">Comoros</asp:ListItem>
							<asp:ListItem Value="Congo">Congo</asp:ListItem>
							<asp:ListItem Value="Cook Islands">Cook Islands</asp:ListItem>
							<asp:ListItem Value="Costa Rica">Costa Rica</asp:ListItem>
							<asp:ListItem Value="Cote D'Ivoire (Ivory Coast)">Cote D'Ivoire (Ivory Coast)</asp:ListItem>
							<asp:ListItem Value="Croatia (Hrvatska">Croatia (Hrvatska</asp:ListItem>
							<asp:ListItem Value="Cuba">Cuba</asp:ListItem>
							<asp:ListItem Value="Cyprus">Cyprus</asp:ListItem>
							<asp:ListItem Value="Czech Republic">Czech Republic</asp:ListItem>
							<asp:ListItem Value="Denmark">Denmark</asp:ListItem>
							<asp:ListItem Value="Djibouti">Djibouti</asp:ListItem>
							<asp:ListItem Value="Dominican Republic">Dominican Republic</asp:ListItem>
							<asp:ListItem Value="Dominica">Dominica</asp:ListItem>
							<asp:ListItem Value="East Timor">East Timor</asp:ListItem>
							<asp:ListItem Value="Ecuador">Ecuador</asp:ListItem>
							<asp:ListItem Value="Egypt">Egypt</asp:ListItem>
							<asp:ListItem Value="El Salvador">El Salvador</asp:ListItem>
							<asp:ListItem Value="Equatorial Guinea">Equatorial Guinea</asp:ListItem>
							<asp:ListItem Value="Eritrea">Eritrea</asp:ListItem>
							<asp:ListItem Value="Estonia">Estonia</asp:ListItem>
							<asp:ListItem Value="Ethiopia">Ethiopia</asp:ListItem>
							<asp:ListItem Value="Falkland Islands (Malvinas)">Falkland Islands (Malvinas)</asp:ListItem>
							<asp:ListItem Value="Faroe Islands">Faroe Islands</asp:ListItem>
							<asp:ListItem Value="Fiji">Fiji</asp:ListItem>
							<asp:ListItem Value="Finland">Finland</asp:ListItem>
							<asp:ListItem Value="France, Metropolitan">France, Metropolitan</asp:ListItem>
							<asp:ListItem Value="France">France</asp:ListItem>
							<asp:ListItem Value="French Guiana">French Guiana</asp:ListItem>
							<asp:ListItem Value="French Polynesia">French Polynesia</asp:ListItem>
							<asp:ListItem Value="French Southern Territories">French Southern Territories</asp:ListItem>
							<asp:ListItem Value="Gabon">Gabon</asp:ListItem>
							<asp:ListItem Value="Gambia">Gambia</asp:ListItem>
							<asp:ListItem Value="Georgia">Georgia</asp:ListItem>
							<asp:ListItem Value="Germany">Germany</asp:ListItem>
							<asp:ListItem Value="Ghana">Ghana</asp:ListItem>
							<asp:ListItem Value="Gibraltar">Gibraltar</asp:ListItem>
							<asp:ListItem Value="Greece">Greece</asp:ListItem>
							<asp:ListItem Value="Greenland">Greenland</asp:ListItem>
							<asp:ListItem Value="Grenada">Grenada</asp:ListItem>
							<asp:ListItem Value="Guadeloupe">Guadeloupe</asp:ListItem>
							<asp:ListItem Value="Guam">Guam</asp:ListItem>
							<asp:ListItem Value="Guatemala">Guatemala</asp:ListItem>
							<asp:ListItem Value="Guinea-Bissau">Guinea-Bissau</asp:ListItem>
							<asp:ListItem Value="Guinea">Guinea</asp:ListItem>
							<asp:ListItem Value="Guyana">Guyana</asp:ListItem>
							<asp:ListItem Value="Haiti">Haiti</asp:ListItem>
							<asp:ListItem Value="Heard and McDonald Islands">Heard and McDonald Islands</asp:ListItem>
							<asp:ListItem Value="Honduras">Honduras</asp:ListItem>
							<asp:ListItem Value="Hong Kong">Hong Kong</asp:ListItem>
							<asp:ListItem Value="Hungary">Hungary</asp:ListItem>
							<asp:ListItem Value="Iceland">Iceland</asp:ListItem>
							<asp:ListItem Value="India">India</asp:ListItem>
							<asp:ListItem Value="Indonesia">Indonesia</asp:ListItem>
							<asp:ListItem Value="Iran">Iran</asp:ListItem>
							<asp:ListItem Value="Iraq">Iraq</asp:ListItem>
							<asp:ListItem Value="Ireland">Ireland</asp:ListItem>
							<asp:ListItem Value="Israel">Israel</asp:ListItem>
							<asp:ListItem Value="Italy">Italy</asp:ListItem>
							<asp:ListItem Value="Jamaica">Jamaica</asp:ListItem>
							<asp:ListItem Value="Japan">Japan</asp:ListItem>
							<asp:ListItem Value="Jordan">Jordan</asp:ListItem>
							<asp:ListItem Value="Kazakhstan">Kazakhstan</asp:ListItem>
							<asp:ListItem Value="Kenya">Kenya</asp:ListItem>
							<asp:ListItem Value="Kiribati">Kiribati</asp:ListItem>
							<asp:ListItem Value="Korea (North)">Korea (North)</asp:ListItem>
							<asp:ListItem Value="Korea (South)">Korea (South)</asp:ListItem>
							<asp:ListItem Value="Kuwait">Kuwait</asp:ListItem>
							<asp:ListItem Value="Kyrgyzstan">Kyrgyzstan</asp:ListItem>
							<asp:ListItem Value="Laos">Laos</asp:ListItem>
							<asp:ListItem Value="Latvia">Latvia</asp:ListItem>
							<asp:ListItem Value="Lebanon">Lebanon</asp:ListItem>
							<asp:ListItem Value="Lesotho">Lesotho</asp:ListItem>
							<asp:ListItem Value="Liberia">Liberia</asp:ListItem>
							<asp:ListItem Value="Libya">Libya</asp:ListItem>
							<asp:ListItem Value="Liechtenstein">Liechtenstein</asp:ListItem>
							<asp:ListItem Value="Lithuania">Lithuania</asp:ListItem>
							<asp:ListItem Value="Luxembourg">Luxembourg</asp:ListItem>
							<asp:ListItem Value="Macau">Macau</asp:ListItem>
							<asp:ListItem Value="Macedonia">Macedonia</asp:ListItem>
							<asp:ListItem Value="Madagascar">Madagascar</asp:ListItem>
							<asp:ListItem Value="Malawi">Malawi</asp:ListItem>
							<asp:ListItem Value="Malaysia">Malaysia</asp:ListItem>
							<asp:ListItem Value="Maldives">Maldives</asp:ListItem>
							<asp:ListItem Value="Mali">Mali</asp:ListItem>
							<asp:ListItem Value="Malta">Malta</asp:ListItem>
							<asp:ListItem Value="Marshall Islands">Marshall Islands</asp:ListItem>
							<asp:ListItem Value="Martinique">Martinique</asp:ListItem>
							<asp:ListItem Value="Mauritania">Mauritania</asp:ListItem>
							<asp:ListItem Value="Mauritius">Mauritius</asp:ListItem>
							<asp:ListItem Value="Mayotte">Mayotte</asp:ListItem>
							<asp:ListItem Value="Mexico">Mexico</asp:ListItem>
							<asp:ListItem Value="Micronesia">Micronesia</asp:ListItem>
							<asp:ListItem Value="Moldova">Moldova</asp:ListItem>
							<asp:ListItem Value="Monaco">Monaco</asp:ListItem>
							<asp:ListItem Value="Mongolia">Mongolia</asp:ListItem>
							<asp:ListItem Value="Montserrat">Montserrat</asp:ListItem>
							<asp:ListItem Value="Morocco">Morocco</asp:ListItem>
							<asp:ListItem Value="Mozambique">Mozambique</asp:ListItem>
							<asp:ListItem Value="Myanmar">Myanmar</asp:ListItem>
							<asp:ListItem Value="Namibia">Namibia</asp:ListItem>
							<asp:ListItem Value="Nauru">Nauru</asp:ListItem>
							<asp:ListItem Value="Nepal">Nepal</asp:ListItem>
							<asp:ListItem Value="Netherlands Antilles">Netherlands Antilles</asp:ListItem>
							<asp:ListItem Value="Netherlands">Netherlands</asp:ListItem>
							<asp:ListItem Value="New Caledonia">New Caledonia</asp:ListItem>
							<asp:ListItem Value="New Zealand">New Zealand</asp:ListItem>
							<asp:ListItem Value="Nicaragua">Nicaragua</asp:ListItem>
							<asp:ListItem Value="Nigeria">Nigeria</asp:ListItem>
							<asp:ListItem Value="Niger">Niger</asp:ListItem>
							<asp:ListItem Value="Niue">Niue</asp:ListItem>
							<asp:ListItem Value="Norfolk Island">Norfolk Island</asp:ListItem>
							<asp:ListItem Value="Northern Mariana Islands">Northern Mariana Islands</asp:ListItem>
							<asp:ListItem Value="Norway">Norway</asp:ListItem>
							<asp:ListItem Value="Oman">Oman</asp:ListItem>
							<asp:ListItem Value="Pakistan">Pakistan</asp:ListItem>
							<asp:ListItem Value="Palau">Palau</asp:ListItem>
							<asp:ListItem Value="Panama">Panama</asp:ListItem>
							<asp:ListItem Value="Papua New Guinea">Papua New Guinea</asp:ListItem>
							<asp:ListItem Value="Paraguay">Paraguay</asp:ListItem>
							<asp:ListItem Value="Peru">Peru</asp:ListItem>
							<asp:ListItem Value="Philippines">Philippines</asp:ListItem>
							<asp:ListItem Value="Pitcairn">Pitcairn</asp:ListItem>
							<asp:ListItem Value="Poland">Poland</asp:ListItem>
							<asp:ListItem Value="Portugal">Portugal</asp:ListItem>
							<asp:ListItem Value="Puerto Rico">Puerto Rico</asp:ListItem>
							<asp:ListItem Value="Qatar">Qatar</asp:ListItem>
							<asp:ListItem Value="Reunion">Reunion</asp:ListItem>
							<asp:ListItem Value="Romania">Romania</asp:ListItem>
							<asp:ListItem Value="Russian Federation">Russian Federation</asp:ListItem>
							<asp:ListItem Value="Rwanda">Rwanda</asp:ListItem>
							<asp:ListItem Value="S. Georgia and S. Sandwich Isls.">S. Georgia and S. Sandwich Isls.</asp:ListItem>
							<asp:ListItem Value="Saint Kitts and Nevis">Saint Kitts and Nevis</asp:ListItem>
							<asp:ListItem Value="Saint Lucia">Saint Lucia</asp:ListItem>
							<asp:ListItem Value="Saint Vincent and The Grenadines">Saint Vincent and The Grenadines</asp:ListItem>
							<asp:ListItem Value="Samoa">Samoa</asp:ListItem>
							<asp:ListItem Value="San Marino">San Marino</asp:ListItem>
							<asp:ListItem Value="Sao Tome and Principe">Sao Tome and Principe</asp:ListItem>
							<asp:ListItem Value="Saudi Arabia">Saudi Arabia</asp:ListItem>
							<asp:ListItem Value="Senegal">Senegal</asp:ListItem>
							<asp:ListItem Value="Seychelles">Seychelles</asp:ListItem>
							<asp:ListItem Value="Sierra Leone">Sierra Leone</asp:ListItem>
							<asp:ListItem Value="Singapore">Singapore</asp:ListItem>
							<asp:ListItem Value="Slovak Republic">Slovak Republic</asp:ListItem>
							<asp:ListItem Value="Slovenia">Slovenia</asp:ListItem>
							<asp:ListItem Value="Solomon Islands">Solomon Islands</asp:ListItem>
							<asp:ListItem Value="Somalia">Somalia</asp:ListItem>
							<asp:ListItem Value="South Africa">South Africa</asp:ListItem>
							<asp:ListItem Value="Spain">Spain</asp:ListItem>
							<asp:ListItem Value="Sri Lanka">Sri Lanka</asp:ListItem>
							<asp:ListItem Value="St. Helena">St. Helena</asp:ListItem>
							<asp:ListItem Value="St. Pierre and Miquelon">St. Pierre and Miquelon</asp:ListItem>
							<asp:ListItem Value="Sudan">Sudan</asp:ListItem>
							<asp:ListItem Value="Suriname">Suriname</asp:ListItem>
							<asp:ListItem Value="Svalbard and Jan Mayen Islands">Svalbard and Jan Mayen Islands</asp:ListItem>
							<asp:ListItem Value="Swaziland">Swaziland</asp:ListItem>
							<asp:ListItem Value="Sweden">Sweden</asp:ListItem>
							<asp:ListItem Value="Switzerland">Switzerland</asp:ListItem>
							<asp:ListItem Value="Syria">Syria</asp:ListItem>
							<asp:ListItem Value="Taiwan">Taiwan</asp:ListItem>
							<asp:ListItem Value="Tajikistan">Tajikistan</asp:ListItem>
							<asp:ListItem Value="Tanzania">Tanzania</asp:ListItem>
							<asp:ListItem Value="Thailand">Thailand</asp:ListItem>
							<asp:ListItem Value="Togo">Togo</asp:ListItem>
							<asp:ListItem Value="Tokelau">Tokelau</asp:ListItem>
							<asp:ListItem Value="Tonga">Tonga</asp:ListItem>
							<asp:ListItem Value="Trinidad and Tobago">Trinidad and Tobago</asp:ListItem>
							<asp:ListItem Value="Tunisia">Tunisia</asp:ListItem>
							<asp:ListItem Value="Turkey">Turkey</asp:ListItem>
							<asp:ListItem Value="Turkmenistan">Turkmenistan</asp:ListItem>
							<asp:ListItem Value="Turks and Caicos Islands">Turks and Caicos Islands</asp:ListItem>
							<asp:ListItem Value="Tuvalu">Tuvalu</asp:ListItem>
							<asp:ListItem Value="US Minor Outlying Islands">US Minor Outlying Islands</asp:ListItem>
							<asp:ListItem Value="Uganda">Uganda</asp:ListItem>
							<asp:ListItem Value="Ukraine">Ukraine</asp:ListItem>
							<asp:ListItem Value="United Arab Emirates">United Arab Emirates</asp:ListItem>
							<asp:ListItem Value="United Kingdom">United Kingdom</asp:ListItem>
							<asp:ListItem Value="United States" Selected="True">United States</asp:ListItem>
							<asp:ListItem Value="Uruguay">Uruguay</asp:ListItem>
							<asp:ListItem Value="Uzbekistan">Uzbekistan</asp:ListItem>
							<asp:ListItem Value="Vanuatu">Vanuatu</asp:ListItem>
							<asp:ListItem Value="Vatican City State">Vatican City State</asp:ListItem>
							<asp:ListItem Value="Venezuela">Venezuela</asp:ListItem>
							<asp:ListItem Value="Viet Nam">Viet Nam</asp:ListItem>
							<asp:ListItem Value="Virgin Islands (British)">Virgin Islands (British)</asp:ListItem>
							<asp:ListItem Value="Virgin Islands (US)">Virgin Islands (US)</asp:ListItem>
							<asp:ListItem Value="Wallis and Futuna Islands">Wallis and Futuna Islands</asp:ListItem>
							<asp:ListItem Value="Western Sahara">Western Sahara</asp:ListItem>
							<asp:ListItem Value="Yemen">Yemen</asp:ListItem>
							<asp:ListItem Value="Yugoslavia">Yugoslavia</asp:ListItem>
							<asp:ListItem Value="Zaire">Zaire</asp:ListItem>
							<asp:ListItem Value="Zambia">Zambia</asp:ListItem>
							<asp:ListItem Value="Zimbabwe">Zimbabwe</asp:ListItem>
						</asp:dropdownlist></td>
					 
				</tr>
				<tr>
					<td style="padding-left: 40px;"><asp:label id="Label7" runat="server" ForeColor="Red">Zip Code:</asp:label></td>
					<td><asp:textbox id="txtZip" runat="server" BackColor="#FFFFC0" CssClass="txtBox"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
					<asp:Label runat="server" ID="lblZipErr" ForeColor="Red" Text="     Zip code is required." Visible="False"></asp:Label></td>					
				</tr>
				<tr>
					<td style="padding-left: 40px;"><asp:label id="Label12" runat="server">Province (if not U.S.):</asp:label></td>
					<td><asp:textbox id="txtProvince" runat="server" BackColor="#FFFFC0" CssClass="txtBox" Height="22px" Width="230px"></asp:textbox>&nbsp;&nbsp; 
					 <asp:label id="lblProvinceErr" runat="server" ForeColor="Red" Visible="False">  Province is required.</asp:label></td>
				</tr>
				<tr>
					<td style="padding-left: 40px;"><asp:label id="Label13" runat="server">Postal Code (if not U.S.): &nbsp;&nbsp;</asp:label></td>
					<td><asp:textbox id="txtPostalCode" runat="server" BackColor="#FFFFC0" CssClass="txtBox"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
					 <asp:label id="lblPostalCodeErr" runat="server" ForeColor="Red" Visible="False">  Postal code is required.</asp:label></td>
				</tr>
				<tr>
				    <td style="padding-left: 40px;"><asp:label id="Label4" runat="server" Text="Email" />&nbsp;<asp:label id="Label10" runat="server" Width="105px" Font-Size="Small" ForeColor="Red" Text=" (recommended)" Height="16px" /><asp:label id="Label14" runat="server" Width="105px" Font-Size="Small" Text=":  " Height="16px" /></td>
					<td><asp:textbox id="txtEmail" runat="server" BackColor="#FFFFC0" CssClass="txtBox" Height="20px" Width="228px"></asp:textbox>&nbsp;&nbsp;
					<asp:Label runat="server" ID="lblEmailErr" ForeColor="Red" Text="Enter valid email address." Visible="False"></asp:Label></td>
				</tr>
				<tr>
					<td style="padding-left: 40px;"><asp:label id="Label20" runat="server">Do you agree to the<br/> <a href="termsofservice.aspx" target="_blank"><u>terms of service</u></a>?</asp:label></td>
					<td>
					    <asp:label id="lblTermsErr" runat="server" Width="406px" ForeColor="Red" Visible="False" Height="19px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    You must agree to continue.</asp:label>
					   <asp:RadioButtonList id="rblAgree" runat="server" RepeatDirection="Horizontal" 
                            Height="16px" Width="138px"><asp:ListItem>Yes</asp:ListItem><asp:ListItem selected="true" >No</asp:ListItem></asp:RadioButtonList>
					</td>
					</tr>
				<tr>
					<td colspan="2"><asp:label id="lblReview" runat="server" Font-Bold="True">Please review your order below.  </asp:label></td>
				</tr>
					<tr>
					<td colspan="2">
						<asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="false" 
						    AutoGenerateDeleteButton="true" OnRowDeleting="gvCart_OnRowDeleteing"  
                            OnRowDataBound="gvCart_OnRowDataBound" Width="98%" 
						    ShowFooter="true" DataKeyNames="GN_ID">
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
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="No. of Copies">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQuantity" runat="server" Width="20px" style="text-align:center"></asp:TextBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="btnUpdateQuantity" Text="Update Quantity" Font-Size="Small" 
                                        runat="server" OnClick="btnUpdateQuantity_OnClick" CausesValidation="false"  />
                                </FooterTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Price">
                                <ItemTemplate><%# GetDollarSign(Eval("SUBTOTAL").ToString()) %></ItemTemplate>
                                <FooterTemplate><%# GetOrderTotal() %></FooterTemplate>
                                <FooterStyle Font-Bold="true" Font-Size="Small" />
                            </asp:TemplateField>
		                </Columns>		
                        </asp:GridView>
                    </td>

				</tr>

				<tr>
					<td >&nbsp;</td>
				</tr>
				<tr>
					<td align="left">
					    <asp:Button ID="btnSubmit" onclick="btnSubmit_Click" runat="server" ToolTip="Go to Step 2 (Enter credit card)>>>"
					        Text="Checkout" CssClass="btnBox" /> 
					</td>
				    <td align="right">
				        <asp:button id="btnCancel" CausesValidation="false" runat="server" Font-Bold="True" Text="Continue Searching" OnClick="btnCancel_Click" CssClass="btnBox"></asp:button>
				    </td>
				</tr>				
			</table>


	</div>
</asp:Content>
