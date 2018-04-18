<%@ Page Language="c#" MasterPageFile="~/addins_app/app_child.master" AutoEventWireup="True" CodeFile="TermsofService.aspx.cs" Inherits="TermsofService" %>

<asp:Content id="DefaultHead" ContentPlaceHolderID="ContentPlaceHolderDefaultHead" runat="server">
    <link rel="stylesheet" href="assets/css/default.css" media="screen" type="text/css" />
 </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="headerPlaceHolder" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="mainContent" class="centerDiv">
    <div class="setMargin">
      <p>
         <asp:button id="btnClose" runat="server" Text="Return to Previous Window" onclick="btnClose_Click" CssClass="btnBox" Width="194px"></asp:button>
      </p>
      <div class="tosTitle1">
          <asp:Label runat="server" ID="tosTitle" Text="TERMS OF SERVICE"></asp:Label>
      </div>  
      <div class="tosTitle2">
          <asp:Label runat="server" ID="Label1" Text="The Central Wisconsin Genealogy Index"></asp:Label>
      </div>
      <p>&nbsp;</p>
      <p><asp:Label runat="server" ID="lblGtos" CssClass="tosTitle3" Text="General Terms of Service"></asp:Label></p>
	  <ol>
		 <li>
			<p class="setFont">Online Payments can only be done using <span class="emText">VISA</span> or <span class="emText">MasterCard</span>.  
			<span class="emText"><i>We cannot fill orders submitted by email or phone</i></span>.<br/></p>
		 </li>
		 <li>
			<p class="setFont">If you <span class="emText">do not have a credit card</span> and wish to request information from the index, 
			please make your request by filling out our online mail order form and sending it to the address below.</p>
		 	
			<ol>
				<li style="LIST-STYLE-TYPE: none">
				    <p class="setFont">University of Wisconsin-Stevens Point<br/>
					   Library / Archives<br/>
					   900 Reserve Street<br/>
					   Stevens Point, WI 54481</p>
				</li>
			</ol>
		</li>
		<li>
			<p class="setFont">Payment of <span class="emText">the fee is for a search</span> based on the citations found in our index.  
			<p class="setFont"><span class="emText"><i>The fee does not guarantee that the information you requested can be found and sent to you.</i></span>
			<p class="setFont"> Payment of the fee only ensures that staff trained to do genealogical research will attempt to locate and 
			copy the obituary, naturalization record or census record for you as it was indexed. On rare occasions, due to a mistake made in
			indexing or possibly other unforeseen factors, an obituary, naturalization record or census record cannot be found as it is cited 
			in our indexes. If there appears to be a mistake in the index, our staff will try to locate the obituary by checking two to three days 
			before and after the date(s) cited in our index. For a census record we will check three pages before and after the date cited in our 
			index. For naturalization records, we will check the original paper indexes. Indexes are great tools for assisting you with your 
			research. However, people did the indexing, and people input the information into the database. Unfortunately, people make mistakes 
			and therefore there are some errors in the indexes, which are corrected as they are found.<br/></p></p></p>
		</li>
		<li>
			<p class="setFont">If we do not find the material you requested, we will send you the results of our efforts through regular mail.<br/></p>
		</li>
		<li>
			<p class="setFont">We will provide you with the best copy possible. The <span class="emText">quality (readability) of the copies sent to you may vary</span> greatly 
				depending on many variables. For example, the print in many of the census records faded by the time they were microfilmed. There is little we can do to 
				make the text readable accept darken the copy we make for you, which means the background on your copy may be anywhere from light to dark gray depending on 
				how poor the microfilm image is. In the case of the microfilmed newspapers that obituaries come from, many old newspapers turned yellow with age and the ink 
				faded. As with the census, we have few options for enhancing the image we send you.<br/></p>
		</li>
		<li>
	        <p class="setFont">Wisconsin state and local sales taxes are included in each order.<br/> </p>
		</li>
		<li>
	       <p>First class shipping by the U.S. Post Office is included in the cost of each request.<br/></p>
		</li>
		<li>
			<p class="setFont">Requests are answered on a first come, first served basis. They are processed as staff time permits. Depending on the backlog, the 
			    turn around time for receiving a response to your request ranges from <span class="emText">3 to 5 weeks</span>.<br/></p>
	    </li>
		<li>
			<p class="setFont"><span class="emText">Do not send duplicate requests</span>. We receive a large number of requests on a daily basis, and we do not check 
				our files for duplication. If you send a duplicate request, your credit card will be billed accordingly and no refund will be made.<br/></p>
		</li>
		<li>
	        <p class="setFont">There is no <span class="emText"><i>Rush Service</i></span>.<br/></p>
		</li>
		<li>
		    <p class="setFont"><span class="emText">No digital files</span> can be sent. Researchers must provide a <span class="emText">postal address</span> to which we can send paper copies.<br/></p>
		</li>
		<li>
	        <p class="setFont">All required fields must be completed on the order form.<br/></p>
	    </li>
		<li>
	      <p class="setFont">All information received during the order process is kept confidential. Credit card numbers are protected using 128bit SSL security.<br/></p>
		</li>
		<li>
		  <p class="setFont">If you provide us with an email address, a confirmation and receipt will be sent to your email account when we receive 
				your request and credit card payment.</p>
		</li>
	</ol>
	   <p><asp:Label runat="server" ID="lblFees" CssClass="tosTitle3" Text="Fees"></asp:Label></p>
	   <p class="setFont"><b>Obituaries:</b></p>
		<ul>
			<li>
				<p class="setFont">1 to 5 obituary requests for $10.00; 6 to 10 obituary requests are $20; 11 to 15 are $30; etc.</p>
			</li>
			<li>
				<p class="setFont">A request is defined as 1 name in our index. For example, if the index reads: </p>
				
				<p class="setFont indentPara">Smith, Jane - SPJ (Stevens Point Journal) - 1 FEB. 1900, 3 FEB., 4 FEB <br/>
				(This is 1 request even though 3 items are listed under SPJ.)</p>
			</li>
			<li>
				<p class="setFont">If there is another listing for Smith, Jane in the SPWJ (Stevens Point Weekly Journal) and you order it in addition to the SPJ 
								obituary; you are ordering <span class="emText">2</span> obituaries for $20.</p>
			</li>
		</ul>
		<p class="setFont"><b>Census:</b></p>
		<ul>
			<li>
				<p class="setFont">1 request is $10.00</p>
			</li>
			<li>
				<p class="setFont">1 family name for 1 year's census in the index is considered 1 request. For example if the index reads:</p>
					
			    <div class="indentPara">Family Name: Smith - 1870<br/>
			        Town of Grant<br/>
			        <table style="width: 24%;">
			            <tr>
			                <td>Name</td>
			                <td>Age</td>
			                <td>Page</td>
			            </tr>
			            <tr>
			                <td>John</td>
			                <td>34</td>
			                <td>96A</td>
			            </tr>
			             <tr>
			                <td>Mary</td>
			                <td>30</td>
			                <td>96A</td>
			            </tr>
			             <tr>
			                <td>Tom</td>
			                <td>10</td>
			                <td>96A</td>
			            </tr>
			             <tr>
			                <td>Mina</td>
			                <td>8</td>
			                <td>96A</td>
			            </tr>
			        </table>
			    </div>

				<p class="setFont indentPara">(This is 1 request.)</p>
			</li>
		</ul>
		<p class="setFont"><b>Naturalization / Citizenship Papers:</b></p>
		<ul>
		    <li>
			 <p class="setFont">1 request is $10.00</p>
			</li>
			<li>
                <div class="setFont">1 name is the equivalent of 1 request. If the index has all 3 steps of the process listed together <b>under one name</b>, this is 1 request 
                and you will receive documents for all 3 steps for $10.  Check the name <i>Timm, Joachim</i> in the index if you need a clearer example:
                
                <table style="width: 98%">
                    <tr>
                        <td style="font-size:7.2pt; font-family: Verdana;">Timm, Joachim</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Portage Naturalization,</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">1833</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Aug 1857</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Declaration of Intent, Petition &amp; Final Paper (Series: 17 Box: 13 Folder: 5)</td>
                    </tr>
                </table>
                </div><br/>
           </li>     
           <li>
               <div class="setFont">If there are multiple listings for a name in the index, such as Johnson, Andrew, you will be charged for each one you order. 
               For example, if you order all 7 Andrew Johnson declaration of intents the charge would be $70.&nbsp; Check the name Johnson, 
               Andrew in the index if you need a clearer example. 
                  <table style="width: 85%">
                    <tr>
                        <td style="font-size:7.2pt; font-family: Verdana;">Johnson, Andrew</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Portage Naturalization</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">1831</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">May 1870</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Declaration of Intent (Series: 17 Box: 5 Folder: 1)</td>
                    </tr>
                    <tr>
                        <td style="font-size:7.2pt; font-family: Verdana;">Johnson, Andrew</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Portage Naturalization</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">1848</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Aug 1870</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Declaration of Intent (Series: 17 Box: 5 Folder: 1)</td>
                    </tr>
                    <tr>
                        <td style="font-size:7.2pt; font-family: Verdana;">Johnson, Andrew</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Portage Naturalization</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">1843</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Jul 1871</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Declaration of Intent (Series: 17 Box: 5 Folder: 2)</td>
                    </tr>
                    <tr>
                        <td style="font-size:7.2pt; font-family: Verdana;">Johnson, Andrew</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Portage Naturalization</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">1847</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Apr 1869</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Declaration of Intent (Series: 17 Box: 5 Folder: 1)</td>
                    </tr>
                    <tr>
                        <td style="font-size:7.2pt; font-family: Verdana;">Johnson, Andrew</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Portage Naturalization</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">&nbsp;</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">&nbsp;</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Declaration of Intent (Series: 17 Box: 4 Folder: 2)</td>
                    </tr>
                    <tr>
                        <td style="font-size:7.2pt; font-family: Verdana;">Johnson, Andrew</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Portage Naturalization</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">1846</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">May 1871</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Declaration of Intent (Series: 17 Box: 5 Folder: 2)</td>
                    </tr>
                    <tr>
                        <td style="font-size:7.2pt; font-family: Verdana;">Johnson, Andrew</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Portage Naturalization</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">1846</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Jun 1867</td>
                        <td style="font-size:7.2pt; font-family: Verdana;">Declaration of Intent (Series: 17 Box: 4 Folder: 17)</td>
                    </tr>
                </table>
               </div> 
			</li>
		</ul>	
		<br/>
		<p><asp:Label runat="server" ID="Label2" CssClass="tosTitle3" Text="Refund Policy"></asp:Label></p>			 
		<ol>
			<li>
				<p class="setFont">There is <span class="emText">no guarantee</span> that a record can be found even if they are cited in the index. 
					<span class="emText"><i>You are paying for a search to be conducted, not for a record to be delivered to you.</i></span> Payment of the fee 
						only ensures that staff trained to do genealogical research will attempt to locate and copy the material for you as it was indexed. Staff 
						trained in genealogical research conducts your search. You will receive notification through U.S. Mail if we do not find the information you requested.</p>
				</li>
				<li>
					<p class="setFont"><span class="emText">No refunds</span> can be given on orders submitted with errors such as, but not limited to, a typo in 
						your mailing address or submitting the wrong name for us to search. Responsibility for providing correct information lies solely with you. We are 
						not responsible if you provide incorrect information.
					 </p>
				</li>
				<li>
					<p class="setFont"><span class="emText">Cancellations:</span> Once an order is entered into our system, it cannot be canceled under any circumstances.</p>
				</li>			
				<li>
					<p class="setFont">We will issue a refund only if you can provide written documentation that your credit card was used fraudulently.</p>
				</li>
				<li>
					<div class="setFont">We will only <span class="emText">redo a request</span> under limited circumstances:
                    <ol>
				        <li style="LIST-STYLE-POSITION: outside; LIST-STYLE-TYPE: lower-alpha">
					        <p class="setFont">If our staff has somehow made an error, we will gladly do the search a second time without charge.</p>
					    </li>
				        <li style="LIST-STYLE-POSITION: outside; LIST-STYLE-TYPE: lower-alpha">
				            <p class="setFont">If a package shipped from us with the correct address has miscarried, we will promptly send another copy without charge.<br/></p>
				        </li>
				     </ol>
				     </div>
				</li>
			<li>
				<p class="setFont">If you think you qualify to have your request redone or your fee refunded, please email us at <a href="mailto:archives@uwsp.edu">archives@uwsp.edu</a>
					and a staff member will reply promptly. <span class="emText">Please do not use this address to submit requests for materials. We will not 
					process requests emailed to this address.</span></p>
			</li>
			<li>
				<p class="setFont">The same fees and policies apply to <span class="emText">written requests. <i>Pre-payment is required.</i></span> If you 
					prefer not to pay by credit card, and wish to order material, please make your request by filling out our online mail order 
					form and sending it to the address below.</p>
				<ol>
			        <li style="LIST-STYLE-TYPE: none">
			            <p class="setFont">University of Wisconsin-Stevens Point<br/>
				        Library / Archives<br/>
				        900 Reserve St.<br/>
				        Stevens Point, WI 54481</p>
			        </li>
			    </ol>
			</li>
		</ol>
			<p>
			    <asp:button id="btnClose2" runat="server" Text="Return to Previous Window" onclick="btnClose2_Click" CssClass="btnBox" Width="194px"></asp:button>
			</p>
    </div>

    </div>

</asp:Content>
