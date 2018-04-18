<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LibArchivesPage.aspx.cs" Inherits="LibArchivesPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" type="text/css" href="/assets/css/mainV5.css" />
    <link rel="stylesheet" type="text/css" href="/assets/css/archivesLayout.css" />
    <link rel="stylesheet" type="text/css" href="/assets/css/archivesLayoutMobile.css" />
    <!--[if lt IE 9]>
	<link rel="stylesheet" type="text/css" href="/assets/css/archivesLayoutLtIE8.css" />
    <![endif]-->
    
    <script type="text/javascript" src="/assets/scripts/archivesLayout.js"></script> 
</head>
<body>
<form name="LibArchivesPageForm" runat="server">

<!-- ribbon -->
<div id="ribbonBackground">
	<div id="s4-ribbonrow" class="s4-pr s4-ribbonrowhidetitle">
		<!-- trim the ribbon from any user who does not have permission to add list items -->	
	</div>
</div><!-- #ribbonBackground -->
<!-- /ribbon -->

<div id="bodyContainer">
<!-- ===== Start Branding Bar ===== -->
<div id="UWSPbarContainer">
	<div id="UWSPbar">
					<a id="brandingLogo" title="UWSP Home" href="http://www.uwsp.edu/">
						<img id="logo" src="/SiteAssets/images/Homepage/colorLogoHome.png" alt="University of Wisconsin - Stevens Point">
						
					</a>
					
					<div id="brandingContent">
						<nav id="resourcesNav">
							<ul>
								<!-- If editing these links, please leave them in one line to avoid uneven spacing due to the returns. -->
								<a href="/foundation"><li>Giving</li></a><a href="/landing/Pages/directory.aspx"><li>Directory</li></a><a href="/landing/Pages/siteIndex.aspx"><li>Site Index</li></a><a href="https://mypoint.uwsp.edu/" onclick="that=this;_gaq.push(['_trackEvent','Outbound Links','click',that.href]);setTimeout(function() { location.href=that.href }, 200);return false;"><li class="newLine">myPoint</li></a><a href="/d2l"><li>D2L</li></a><a href="https://email.uwsp.edu/" onclick="that=this;_gaq.push(['_trackEvent','Outbound Links','click',that.href]);setTimeout(function() { location.href=that.href }, 200);return false;"><li class="lastItem">Web Email</li></a>			
							</ul>
						</nav>
						
						<div id="sharepointTools">
							<div id="login" class="s4-trc-container-menu">
								
<a id="ctl00_IdWelcome_ExplicitLogin" class="s4-signInLink" href="http://www.uwsp.edu/library/archives/_layouts/Authenticate.aspx?Source=%2Flibrary%2Farchives%2FPages%2Fdefault%2Easpx" style="display:inline;">Sign In</a>

								


							</div>
							<div id="search" class="s4-notdlg" role="search">
								
									<table class="s4-wpTopTable" border="0" cellpadding="0" cellspacing="0" width="100%">
	<tbody><tr>
		<td valign="top"><div webpartid="00000000-0000-0000-0000-000000000000" haspers="true" id="WebPartWPQ1" width="100%" class="noindex" onlyformepart="true" allowdelete="false" style=""><div id="SRSB"> <div>
			<table class="ms-sbtable ms-sbtable-ex s4-search" cellpadding="0" cellspacing="0" border="0">
				<tbody><tr class="ms-sbrow">
					<td class="ms-sbcell"><input name="InputKeywords" type="text" value="Search this site..." maxlength="200" id="ctl00_PlaceHolderSearchArea_ctl01_S3031AEBB_InputKeywords" accesskey="S" title="Search..." class="ms-sbplain s4-searchbox-QueryPrompt" alt="Search..." onkeypress="javascript: return S3031AEBB_OSBEK(event);" onfocus="if (document.getElementById('ctl00_PlaceHolderSearchArea_ctl01_ctl03').value =='0') {this.value=''; if (this.className == 's4-searchbox-QueryPrompt') this.className = ''; else this.className = this.className.replace(' s4-searchbox-QueryPrompt',''); document.getElementById('ctl00_PlaceHolderSearchArea_ctl01_ctl03').value=1;}" onblur="if (this.value =='') {this.value='Search this site...'; if (this.className.indexOf('s4-searchbox-QueryPrompt') == -1) this.className += this.className?' s4-searchbox-QueryPrompt':'s4-searchbox-QueryPrompt'; document.getElementById('ctl00_PlaceHolderSearchArea_ctl01_ctl03').value = '0'} else {document.getElementById('ctl00_PlaceHolderSearchArea_ctl01_ctl03').value='1';}" style="width:170px;"></td><td class="ms-sbgo ms-sbcell"><a id="ctl00_PlaceHolderSearchArea_ctl01_S3031AEBB_go" title="Search" href="javascript:S3031AEBB_Submit()"><img title="Search" onmouseover="this.src='\u002f_layouts\u002fimages\u002fgosearchhover15.png'" onmouseout="this.src='\u002f_layouts\u002fimages\u002fgosearch15.png'" class="srch-gosearchimg" alt="Search" src="/_layouts/images/gosearch15.png" style="border-width:0px;"></a></td><td class="ms-sbLastcell"></td>
				</tr>
			</tbody></table><input name="ctl00$PlaceHolderSearchArea$ctl01$ctl03" type="hidden" id="ctl00_PlaceHolderSearchArea_ctl01_ctl03" value="0">
		</div></div></div></td>
	</tr>
</tbody></table>
								
							</div>
						</div>
							
							
						<div id="brandingMobile">
							<div id="universityNavIcon">
								<select id="universityNavMobile" onchange="location = this.options[this.selectedIndex].value;">
									<option selected="selected"></option>
									<option value="/admissions">Admissions</option>
									<option value="/landing/pages/academics.aspx">Academics</option>
									<option value="http://athletics.uwsp.edu/">Athletics</option>
									<option value="/alumni">Alumni</option>
									<option value="http://www.uwsp.edu/landing/Pages/campusLife.aspx">Campus Life</option>
									<option value="//www.uwsp.edu/thrivingcommunities/Pages/default.aspx">Community</option>
									<option value="//www.uwsp.edu/landing/Pages/about.aspx">About</option>
									<option value="/foundation">Giving</option>
									<option value="/landing/Pages/directory.aspx">Directory</option>
									<option value="/landing/Pages/siteIndex.aspx">Site Index</option>
									<option value="https://mobilepoint.uwsp.edu/">myPoint</option>
									<option value="/d2l">D2L</option>
									<option value="https://email.uwsp.edu/">Web Email</option>
								</select>
							</div>
			 
							<div id="searchMobile">
								<a href="http://search.uwsp.edu/">
									<img src="/SiteAssets/images/v5/Search.png" alt="Search UWSP.edu" id="defaultSearchIcon">
								</a>
							</div>
						</div>
					</div>
				</div>
			 
				<nav id="universityNav">
					<ul>
						<a href="//www.uwsp.edu/admissions"><li>Admissions</li></a>
						<a href="//www.uwsp.edu/landing/pages/academics.aspx"><li>Academics</li></a>
						<a href="//athletics.uwsp.edu/" onclick="that=this;_gaq.push(['_trackEvent','Outbound Links','click',that.href]);setTimeout(function() { location.href=that.href }, 200);return false;"><li>Athletics</li></a>
						<a href="//www.uwsp.edu/alumni"><li>Alumni</li></a>
						<a href="//www.uwsp.edu/landing/Pages/campusLife.aspx"><li>Campus Life</li></a>
						<a href="//www.uwsp.edu/thrivingcommunities/Pages/default.aspx"><li>Community</li></a>
					</ul>
				</nav>
			</div>
<!-- ===== End Branding Bar ===== -->
<div id="containerBG">
<div id="contentWrapper" style="height: 1141px;">
    <div id="bannerWrapper"><!-- Used to hide these images if requested. Needed to make IE 8 Compat. view work. -->
						<!-- Dynamically create site banner images and wrap it in a link to the home page. Mobile site banner is not wrapped. 	-->					
							<a id="homeLink" href="
							/library/archives/
							">
							
							<img id="siteBanner" src="
							/library/archives/SiteAssets/images/siteBanner.png
							">
																	
							</a>
						</div>					
    <div id="siteTitleMobile">
							<a href="#" onclick="toggleSiteNav()" id="mobileSiteMenu">
								<img src="/SiteAssets/images/v5/siteNav.png" alt="Open Site Menu" id="siteMenu"></a>
								<h1 id="siteTitle">
									Archives &amp; Area Research Center
								</h1>
						</div>
	<div id="contentContainer1">
	    <nav id="siteNav" role="navigation"><a href="#" class="" "="" onclick="toggleItem('heading1'); return false"><div id="toggleButtonheading1" class="toggleButton toggleButtonOpen"></div><h1>Archives</h1></a><ul class="expanded" id="heading1"><a href="http://www.uwsp.edu/library/archives" class=""><li>Home</li></a><a href="http://www.uwsp.edu/library/archives/Pages/digitalCollections.aspx" class=""><li>Digital Collections</li></a><a href="http://www.uwsp.edu/library/archives/Pages/recordsManagement.aspx" class=""><li>Records Management</li></a><a href="http://www.uwsp.edu/library/archives/Pages/researchGuides.aspx" class=""><li>Research Guides</li></a><a href="http://www.uwsp.edu/library/archives/Pages/researchRequests.aspx" class=""><li>Research Requests</li></a><a href="http://www.uwsp.edu/library/Pages/specialCollections.aspx" target="_blank" class=""><li>Special Collections</li></a></ul><a href="#" class="" "="" onclick="toggleItem('heading2'); return false"><div id="toggleButtonheading2" class="toggleButton toggleButtonOpen"></div><h1>Archives Indexes</h1></a><ul class="expanded" id="heading2"><a href="http://www.uwsp.edu/library/archives/Pages/cemeteryLocator.aspx" class=""><li>Cemetery Locator</li></a><a href="http://mypoint.uwsp.edu/Library/gen_index/" target="_blank" class=""><li>Central Wisconsin Genealogy Index</li></a><a href="http://www.uwsp.edu/library/archives/Pages/indexCampusNewspaper.aspx" class=""><li>UWSP Campus Newspaper Index</li></a><a href="http://www.uwsp.edu/library/archives/Pages/indexSPJournal.aspx" class=""><li>Stevens Point Journal Index</li></a><a href="http://www.uwsp.edu/library/archives/Pages/collectionsIndexes.aspx" class=""><li>Select Collection Content &amp; Indexes</li></a></ul><div id="extraNavContent" class="noMobile"></div></nav>
	<div id="innerContainerWrapper">
	    <div id="innerContainer">
<!-- page content goes here-->
	    </div><!-- #innerContainer -->
	    
	    <div id="socialMediaIcons"><div class="socIcon"><a href="http://www.facebook.com/pages/UWSP-Archives-and-Area-Research-Center/1473921516198575" title="UWSP Archives Facebook Page"><img src="http://www.uwsp.edu/library/PublishingImages/icons/facebookIcon.png" alt="Facebook Icon"></a></div></div>
	</div><!-- #innerContainerWrapper -->
	
	</div><!-- #contentContainer1 -->
	<div id="footerWrapper" class="s4-notdlg" role="contentinfo">
								<footer id="footer">
									<div id="footerContent"><div class="ExternalClassF3EBFC472F064F32B525F803EDB0F2C8"><p>
	<a href="/library/archives" title="Archives &amp; Area Research Center">Archives &amp; Area Research Center</a> at the <a href="/library" title="University Library">University Library</a><br>
	520 LRC, 900 Reserve Street Stevens Point, WI 54481-3897<br>
	Phone: 715-346-2586 • Email: <a href="mailto:archives@uwsp.edu" title="Email the Archives">archives@uwsp.edu</a></p>
<p>
	<a href="/library/Pages/siteIndex.aspx" title="Library Site Index">Library Site Index</a> • <a href="/library/Pages/accessibility.aspx" title="Library Accessibility Statement">Library Accessibility Statement</a></p>
</div></div><!-- #footerContent -->
									<div id="nonDiscStatement">©1993-2015 <a href="http://www.uwsp.edu" title="University of Wisconsin-Stevens Point">University of Wisconsin-Stevens Point</a> | <a href="http://www.uwsp.edu/equity/Pages/default.aspx" title="Nondiscrimination Statement">Nondiscrimination Statement</a></div>
									<div id="viewFullSite"><br><a href="javascript:viewFullSite();">Tap here for desktop version.</a><br></div>

								</footer><!-- footer -->
							</div><!-- #footerWrapper -->
</div><!-- #contentWrapper -->
</div><!-- #containerBG -->
</div><!-- #bodyContainer -->


</form>
</body>
</html>
