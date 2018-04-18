$(document).ready(function() {

    //IE8 and Lower Calls

    ie8OrLess();

    // IE Call

    ieRender();

    // General Calls

    setInterval(correctHeight, 0);
    setInterval(fixIEShadow, 0);

    // Yearbooks Calls

    setInterval(correctTables, 0);

    // Main Street Calls

    swapColspan();

    // Archives Layout Tabs Calls

    subTitleSlide();
    slideTabs();
    expandCollapsed();
    samePageHash();

    // Pointer List Calls

    pointerList();
    setInterval(pointerListVisible, 0);

    // Forms Calls 

    archivesForms();

});

// IE8 and Lower Functions

function ie8OrLess() {
    $("#uwspNewspaperList li:nth-child(n+60)").addClass("ie8BtmHalf");
    $("#uwspNewspaperList li:nth-child(4n+1)").each(function() {
        $(this).addClass("ie8Col1");
    });
    $("#uwspNewspaperList li:nth-child(4n+2)").each(function() {
        $(this).addClass("ie8Col2");
    });
    $("#uwspNewspaperList li:nth-child(4n+3)").each(function() {
        $(this).addClass("ie8Col3");
    });
    $("#uwspNewspaperList li:nth-child(4n+4)").each(function() {
        $(this).addClass("ie8Col4");
    });

}

// Force IE to Render Correctly

function ieRender() {
    var ieEdge = "<meta http-equiv='X-UA-Compatible' content='IE=edge'>";
    jQuery("head").append(ieEdge);
}

// General Functions

function correctHeight() {
    var siteNavH = $("#siteNav").height();
    var innerContH = siteNavH - 50;

    $("#innerContainer").css("min-height", innerContH);
}

function fixIEShadow() {
    var bannerH = $("#bannerWrapper").height();
    var contentH = $("#contentContainer1").height();
    var footerH = $("#footerWrapper").height();
    var allH = bannerH + contentH + footerH;

    $("#contentWrapper").height(allH);
}

// Yearbooks Functions

function correctTables() {
    var innerContW = $("#innerContainer").width();
    var innerContW4D = innerContW / 4;

    $(".yearbooks, .yearbooks tbody, .yearbooks tbody tr").width(innerContW);
    $(".yearbooks tbody tr td").width(innerContW4D);
}

// Main Street Functions

function swapColspan() {

    setInterval(function() {
        var screenSize = $(document).width();

        if (screenSize < 960 && screenSize > 479) {
            $(".galleryTable tbody tr td.galleryTxt").attr("colspan", "2");
            $(".galleryTable tbody tr td.galleryImg").attr("colspan", "2");
            $(".galleryTable tbody tr td a img").css("width", "90%");
            $(".galleryTable tbody tr td").css("padding", "5% 3%");
        }
        else if (screenSize < 480) {
            $(".galleryTable tbody tr td.galleryTxt").attr("colspan", "3");
            $(".galleryTable tbody tr td.galleryImg").attr("colspan", "1");
            $(".galleryTable tbody tr td a img").css("width", "93%");
            $(".galleryTable tbody tr td.galleryTxt").css("padding", "5% 3%");
            $(".galleryTable tbody tr td.galleryImg").css("padding", "5% 0");
        }
        else if (screenSize > 959) {
            $(".galleryTable tbody tr td.galleryTxt").attr("colspan", "3");
            $(".galleryTable tbody tr td.galleryImg").attr("colspan", "1");
            $(".galleryTable tbody tr td.galleryTxt").css("padding", "2% 3%");
            $(".galleryTable tbody tr td.galleryImg").css("padding", "2% 0");

        }
    }, 0);



}


// Archives Layout Tabs Functions

function subTitleSlide() {
    $("#innerContainer div.slider div").slideUp(0);
    $("#innerContainer div.slider h2").click(function() {
        $(this).parent("div.slider").children("div").slideToggle(250, function() {
            if ($(this).is(":visible")) {
                $(this).parent(".slider").children("h2").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
            }
            else {
                $(this).parent(".slider").children("h2").css("background-image", "url('/library/archives/SiteAssets/images/arrowUp.png')");
            }
        });
    });
}

function slideTabs() {
    $("#archivesCenter div table tbody tr td table tbody tr:nth-child(2) td div").slideUp(0);

    $("#archivesCenter div table tbody tr").each(function() {
        var tab = $(this).children("td").children("table").children("tbody").children("tr").children("td").children("table").children("tbody").children("tr").children("td:nth-child(2)").children("h3").children("nobr");
        var par = $(this).children("td").children("table").children("tbody").children("tr:nth-child(2)").children("td").children("div");
        var titleTxt = $(this).children("td").children("table").children("tbody").children("tr").children("td").children("table").children("tbody").children("tr").children("td:nth-child(2)").children("h3").text();
        var titleTxt2 = titleTxt + " - Click to View Content";
        var titleRpl = $(this).children("td").children("table").children("tbody").children("tr").children("td").children("table").children("tbody").children("tr").children("td:nth-child(2)");

        titleRpl.attr("title", titleTxt2);
        tab.click(function() {
            par.slideToggle(250, function() {
                if ($(this).is(":visible")) {
                    tab.css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
                }
                else {
                    tab.css("background-image", "url('/library/archives/SiteAssets/images/arrowUp.png')");
                }
            });
        });
    });
}

function expandCollapsed() {
    var whichIs = window.location.hash;
    if (whichIs == "#census") {
        var thisPos = $("#archivesCenter div table tbody tr:first-child").offset();
        var fromTop = thisPos.top;
        var fromTop2 = fromTop - 50;
        var contentTop = "<p>" + fromTop + "</p>";

        setTimeout(function() { $(document).scrollTop(fromTop2); }, 500);

        $("#archivesCenter div table tbody tr:first-child td table tbody tr:nth-child(2) td div").slideDown(250, function() {
            $("#archivesCenter div table tbody tr:first-child td table tbody tr td table tbody tr td:nth-child(2) h3 nobr").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
        });
    }

    else if (whichIs == "#hist") {
        var thisPos = $("#archivesCenter div table tbody tr:nth-child(2)").offset();
        var fromTop = thisPos.top;
        var fromTop2 = fromTop + 33;
        var contentTop = "<p>" + fromTop + "</p>";

        setTimeout(function() { $(document).scrollTop(fromTop2); }, 500);

        $("#archivesCenter div table tbody tr:nth-child(3) td table tbody tr:nth-child(2) td div").slideDown(250, function() {
            $("#archivesCenter div table tbody tr:nth-child(3) td table tbody tr td table tbody tr td:nth-child(2) h3 nobr").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
        });
    }

    else if (whichIs == "#nat") {
        var thisPos = $("#archivesCenter div table tbody tr:nth-child(2)").offset();
        var fromTop = thisPos.top;
        var fromTop2 = fromTop + 76;
        var contentTop = "<p>" + fromTop + "</p>";

        setTimeout(function() { $(document).scrollTop(fromTop2); }, 500);

        $("#archivesCenter div table tbody tr:nth-child(4) td table tbody tr:nth-child(2) td div").slideDown(250, function() {
            $("#archivesCenter div table tbody tr:nth-child(4) td table tbody tr td table tbody tr td:nth-child(2) h3 nobr").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
        });
    }

    else if (whichIs == "#obit") {
        var thisPos = $("#archivesCenter div table tbody tr:nth-child(2)").offset();
        var fromTop = thisPos.top;
        var fromTop2 = fromTop + 119;
        var contentTop = "<p>" + fromTop + "</p>";

        setTimeout(function() { $(document).scrollTop(fromTop2); }, 500);

        $("#archivesCenter div table tbody tr:nth-child(5) td table tbody tr:nth-child(2) td div").slideDown(250, function() {
            $("#archivesCenter div table tbody tr:nth-child(5) td table tbody tr td table tbody tr td:nth-child(2) h3 nobr").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
        });
    }

    else if (whichIs == "#pres") {
        var thisPos = $("#archivesCenter div table tbody tr:nth-child(2)").offset();
        var fromTop = thisPos.top;
        var fromTop2 = fromTop + 172;
        var contentTop = "<p>" + fromTop + "</p>";

        setTimeout(function() { $(document).scrollTop(fromTop2); }, 500);

        $("#archivesCenter div table tbody tr:nth-child(6) td table tbody tr:nth-child(2) td div").slideDown(250, function() {
            $("#archivesCenter div table tbody tr:nth-child(6) td table tbody tr td table tbody tr td:nth-child(2) h3 nobr").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
        });
    }

    else if (whichIs == "#vital") {
        var thisPos = $("#archivesCenter div table tbody tr:nth-child(2)").offset();
        var fromTop = thisPos.top;
        var fromTop2 = fromTop + 235;
        var contentTop = "<p>" + fromTop + "</p>";

        setTimeout(function() { $(document).scrollTop(fromTop2); }, 500);

        $("#archivesCenter div table tbody tr:nth-child(7) td table tbody tr:nth-child(2) td div").slideDown(250, function() {
            $("#archivesCenter div table tbody tr:nth-child(7) td table tbody tr td table tbody tr td:nth-child(2) h3 nobr").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
        });
    }

    else if (whichIs == "#rda") {
        var thisPos = $("#archivesCenter div table tbody tr:first-child").offset();
        var fromTop = thisPos.top;
        var fromTop2 = fromTop - 50;
        var contentTop = "<p>" + fromTop + "</p>";

        setTimeout(function() { $(document).scrollTop(fromTop); }, 500);

        $("#archivesCenter div table tbody tr:first-child td table tbody tr:nth-child(2) td div:first-child").slideDown(250, function() {
            $("#archivesCenter div table tbody tr:first-child td table tbody tr td table tbody tr td:nth-child(2) h3 nobr").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
            $("#archivesCenter div table tbody tr:first-child td table tbody tr:nth-child(2) td div:first-child div.slider:first-child div").slideDown(250, function() {
                $("#archivesCenter div table tbody tr:first-child td table tbody tr:nth-child(2) td div:first-child div.slider:first-child h2").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
            });
        });
    }

    else if (whichIs == "#conds") {
        var thisPos = $("#archivesCenter div table tbody tr:first-child").offset();
        var fromTop = thisPos.top;
        var fromTop2 = fromTop + 110;
        var contentTop = "<p>" + fromTop + "</p>";

        setTimeout(function() { $(document).scrollTop(fromTop2); }, 500);

        $("#archivesCenter div table tbody tr:first-child td table tbody tr:nth-child(2) td div:first-child").slideDown(250, function() {
            $("#archivesCenter div table tbody tr:first-child td table tbody tr td table tbody tr td:nth-child(2) h3 nobr").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
            $("#archivesCenter div table tbody tr:first-child td table tbody tr:nth-child(2) td div:first-child div.slider:nth-child(3) div").slideDown(250, function() {
                $("#archivesCenter div table tbody tr:first-child td table tbody tr:nth-child(2) td div:first-child div.slider:nth-child(3) h2").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
            });
        });
    }

    else if (whichIs == "#sscr") {
        var thisPos = $("#archivesCenter div table tbody tr:nth-child(2)").offset();
        var fromTop = thisPos.top;
        var fromTop2 = fromTop - 50;
        var contentTop = "<p>" + fromTop + "</p>";

        setTimeout(function() { $(document).scrollTop(fromTop); }, 500);

        $("#archivesCenter div table tbody tr:nth-child(2) td table tbody tr:nth-child(2) td div:first-child").slideDown(250, function() {
            $("#archivesCenter div table tbody tr:nth-child(2) td table tbody tr td table tbody tr td:nth-child(2) h3 nobr").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
            $("#archivesCenter div table tbody tr:nth-child(2) td table tbody tr:nth-child(2) td div:first-child div.slider:first-child div").slideDown(250, function() {
                $("#archivesCenter div table tbody tr:nth-child(2) td table tbody tr:nth-child(2) td div:first-child div.slider:first-child h2").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
            });
        });
    }

    else if (whichIs == "#stud") {
        var thisPos = $("#archivesCenter div table tbody tr:nth-child(2)").offset();
        var fromTop = thisPos.top;
        var fromTop2 = fromTop + 55;
        var contentTop = "<p>" + fromTop + "</p>";

        setTimeout(function() { $(document).scrollTop(fromTop2); }, 500);

        $("#archivesCenter div table tbody tr:nth-child(2) td table tbody tr:nth-child(2) td div:first-child").slideDown(250, function() {
            $("#archivesCenter div table tbody tr:nth-child(2) td table tbody tr td table tbody tr td:nth-child(2) h3 nobr").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
            $("#archivesCenter div table tbody tr:nth-child(2) td table tbody tr:nth-child(2) td div:first-child div.slider:nth-child(2) div").slideDown(250, function() {
                $("#archivesCenter div table tbody tr:nth-child(2) td table tbody tr:nth-child(2) td div:first-child div.slider:nth-child(2) h2").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
            });
        });
    }

    else if (whichIs == "#procs") {
        var thisPos = $("#archivesCenter div table tbody tr:nth-child(3)").offset();
        var fromTop = thisPos.top;
        var fromTop2 = fromTop - 50;
        var contentTop = "<p>" + fromTop + "</p>";

        setTimeout(function() { $(document).scrollTop(fromTop); }, 500);

        $("#archivesCenter div table tbody tr:nth-child(3) td table tbody tr:nth-child(2) td div:first-child").slideDown(250, function() {
            $("#archivesCenter div table tbody tr:nth-child(3) td table tbody tr td table tbody tr td:nth-child(2) h3 nobr").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
            $("#archivesCenter div table tbody tr:nth-child(3) td table tbody tr:nth-child(2) td div:first-child div.slider:first-child div").slideDown(250, function() {
                $("#archivesCenter div table tbody tr:nth-child(3) td table tbody tr:nth-child(2) td div:first-child div.slider:first-child h2").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
            });
        });
    }

    else if (whichIs == "#portageCoCensuses") {


        var thisPos = $("#archivesCenter div table tbody tr:nth-child(2)").offset();
        var fromTop = thisPos.top;
        var fromTop2 = fromTop - 50;
        var contentTop = "<p>" + fromTop + "</p>";

        setTimeout(function() { $(document).scrollTop(fromTop2); }, 500);

        $("#archivesCenter div table tbody tr:nth-child(2) td table tbody tr:nth-child(2) td div").not("#archivesCenter div table tbody tr:nth-child(2) td table tbody tr:nth-child(2) td div div").slideDown(250, function() {
            $("#archivesCenter div table tbody tr:nth-child(2) td table tbody tr td table tbody tr td:nth-child(2) h3 nobr").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
        });
    }

    else if (whichIs == "#cWisLinks") {

        var thisPos = $("#archivesCenter div table tbody tr:nth-child(2)").offset();
        var fromTop = thisPos.top;
        var fromTop2 = fromTop + 290;
        var contentTop = "<p>" + fromTop + "</p>";

        setTimeout(function() { $(document).scrollTop(fromTop2); }, 500);


        $("#archivesCenter div table tbody tr:nth-child(8) td table tbody tr:nth-child(2) td div:first-child").slideDown(250, function() {
            $("#archivesCenter div table tbody tr:nth-child(8) td table tbody tr td table tbody tr td:nth-child(2) h3 nobr").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
            $("#archivesCenter div table tbody tr:nth-child(8) td table tbody tr:nth-child(2) td div:first-child div.slider:nth-child(3) div").slideDown(250, function() {
                $("#archivesCenter div table tbody tr:nth-child(8) td table tbody tr:nth-child(2) td div:first-child div.slider:nth-child(3) h2").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
            });
        });
    }

    else if (whichIs == "#WCAGP") {
        var thisPos = $("#archivesCenter div table tbody tr:first-child").offset();
        var fromTop = thisPos.top;
        var fromTop2 = fromTop + 110;
        var contentTop = "<p>" + fromTop + "</p>";

        setTimeout(function() { $(document).scrollTop(fromTop2); }, 500);

        $("#archivesCenter div table tbody tr:nth-child(3) td table tbody tr:nth-child(2) td div:first-child").slideDown(250, function() {
            $("#archivesCenter div table tbody tr:nth-child(3) td table tbody tr td table tbody tr td:nth-child(2) h3 nobr").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
            $("#archivesCenter div table tbody tr:nth-child(3) td table tbody tr:nth-child(2) td div:first-child div.slider:nth-child(3) div").slideDown(250, function() {
                $("#archivesCenter div table tbody tr:nth-child(3) td table tbody tr:nth-child(2) td div:first-child div.slider:nth-child(3) h2").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
            });
        });
    }


}


function samePageHash() {

    $("#samePage").click(function() {
        var thisPos = $("#archivesCenter div table tbody tr:nth-child(2)").offset();
        var fromTop = thisPos.top;
        var fromTop2 = fromTop - 50;
        var contentTop = "<p>" + fromTop + "</p>";

        setTimeout(function() { $(document).scrollTop(fromTop2); }, 500);

        $("#archivesCenter div table tbody tr:nth-child(2) td table tbody tr:nth-child(2) td div").not("#archivesCenter div table tbody tr:nth-child(2) td table tbody tr:nth-child(2) td div div").slideDown(250, function() {
            $("#archivesCenter div table tbody tr:nth-child(2) td table tbody tr td table tbody tr td:nth-child(2) h3 nobr").css("background-image", "url('/library/archives/SiteAssets/images/arrowDown.png')");
        });

    });

}


// Pointer List Functions

function pointerList() {
    $("#uwspNewspaperList").each(function() {
        $(this).attr("class", "shownNewsItem");
    });

    $("#uwspNewspaperList li ul").each(function() {
        $(this).attr("class", "shownNewsItem2");
    });

    $("#uwspNewspaperList li").click(function() {
        $(this).children("ul").slideToggle();
        $(this).toggleClass("shownNewsItem3");
    });

    $("#uwspNewspaperList li").click(function() {
        var holdNum = $("#holdNumber").val();
        holdNum1 = parseInt(holdNum);
        holdNum2 = parseInt(holdNum1 + 1);
        $("#holdNumber").val(holdNum2);
        $(this).children("ul").css("z-index", holdNum2);
    });

    $("#uwspNewspaperList li ul li a").each(function() {
        var aTxt = $(this).text();
        $(this).attr("target", "_blank");
        $(this).attr("title", aTxt);
    });
}

function pointerListVisible() {
    if ($("#uwspNewspaperList li ul").is(":visible")) {
        $("#uwspNewspaperList").attr("class", "hiddenNewsItem");
        $("#innerContainer").attr("class", "hiddenNewsItem");
    }

    else {
        $("#uwspNewspaperList").attr("class", "shownNewsItem");
        $("#innerContainer").attr("class", "shownNewsItem");
    }

    var arcTop = $("#archivesTop").height();
    $("#innerContainer").height(arcTop + 20);
}

// Forms Functions

function archivesForms() {
    var cemFormContent = "<form action='http://library.uwsp.edu/depts/archives/cemetery/asp/cresult6.asp'><input type='hidden' name='NEW' value='1'/><table id='clTable' style='float: left;'><tr><td><input type='text' name='Value' id='clSearch'/></td><td style='vertical-align: bottom; text-align: right; display: none;'><b>Search in:</b></td><td style='vertical-align: bottom; text-align: center; display: none;'><select name='Field' id='clSelect'><option value='All'>All Fields</option><option value='Author'>Author</option><option value='Title'>Article Title</option><option value='Notes'>Notes</option><option value='Descriptors'>Descriptors</option><option value='Date'>Date</option></select></td></tr></table><table id='clTable2'><tr><td id='cnewsTable2Col1' style='display: none;'><b>Search with:</b></td><td id='cnewsTable2Col2' style='display: none;'><input type='radio' checked='checked' name='Method' value='AND' id='cnewsAnd'/></td><td id='cnewsTable2Col3' style='display: none;'>All Words (AND)</td><td id='cnewsTable2Col4' style='display: none;'><input type='radio' name='Method' value='OR' id='cnewsOr'/></td><td id='cnewsTable2Col5' style='display: none;'>Any Words (OR)</td><td id='cnewsTable2Col6' style='display: none;'><input type='radio' name='Method' value='Browse' id='cnewsBrowse'/></td><td id='cnewsTable2Col7' style='display: none;'>Browse All Records <span class='uwspFontColorRed'></span></td></tr></table><table id='clTable3' style='float: left;'><tr><td><input type='submit' name='B3' value='Search' id='clSubmit'/></td></tr></table><div style='clear: left;'>&nbsp;</div></form>";
    $("#cemeteryLocatorForm").html(cemFormContent);

    var campusNewsContent = "<form action='http://library.uwsp.edu/depts/archives/pointer/presult6.asp'><input type='hidden' name='NEW' value='1'/><table id='cnewsTable'><tr><td><input type='text' name='Value' id='cnewsSearch'/></td><td style='vertical-align: bottom; text-align: right;'><b>Search in:</b></td><td style='vertical-align: bottom; text-align: center;'><select name='Field' id='cnewsSelect'><option value='All'>All Fields</option><option value='Author'>Author</option><option value='Title'>Article Title</option><option value='Notes'>Notes</option><option value='Descriptors'>Descriptors</option><option value='Date'>Date</option></select></td></tr></table><table id='cnewsTable2'><tr><td id='cnewsTable2Col1'><b>Search with:</b></td><td id='cnewsTable2Col2'><input type='radio' checked='checked' name='Method' value='AND' id='cnewsAnd'/></td><td id='cnewsTable2Col3'>All Words (AND)</td><td id='cnewsTable2Col4'><input type='radio' name='Method' value='OR' id='cnewsOr'/></td><td id='cnewsTable2Col5'>Any Words (OR)</td><td id='cnewsTable2Col6'><input type='radio' name='Method' value='Browse' id='cnewsBrowse'/></td><td id='cnewsTable2Col7'>Browse All Records <span class='uwspFontColorRed'>(leave search box blank)</span></td></tr></table><table id='cnewsTable3'><tr><td><input type='submit' name='B3' value='Search' id='cnewsSubmit'/></td></tr></table></form>";
    $("#campusNewspaperForm").html(campusNewsContent);

    var spJournalContent = "<form action='http://library.uwsp.edu/depts/archives/spj/exe/presult2.asp'><input type='hidden' name='NEW' value='1'/><table id='spjTable'><tr><td><input type='text' name='Value' id='spjSearch'/></td><td style='vertical-align: bottom; text-align: right;'><b>Search in:</b></td><td style='vertical-align: bottom; text-align: center;'><select name='Field' id='spjSelect'><option value='All'>All Fields</option><option value='Author'>Author</option><option value='Title'>Article Title</option><option value='Notes'>Notes</option><option value='Descriptors'>Descriptors</option><option value='Date'>Date</option></select></td></tr></table><table id='spjTable2'><tr><td id='spjTable2Col1'><b>Search with:</b></td><td id='spjTable2Col2'><input type='radio' checked='checked' name='Method' value='AND' id='spjAnd'/></td><td id='spjTable2Col3'>All Words (AND)</td><td id='spjTable2Col4'><input type='radio' name='Method' value='OR' id='spjOr'/></td><td id='spjTable2Col5'>Any Words (OR)</td><td id='spjTable2Col6'><input type='radio' name='Method' value='Browse' id='spjBrowse'/></td><td id='spjTable2Col7'>Browse All Records <span class='uwspFontColorRed'>(leave search box blank)</span></td></tr></table><table id='spjTable3'><tr><td><input type='submit' name='B1' value='Search' id='spjSubmit'/></td></tr></table></form>";
    $("#spJournalForm").html(spJournalContent);
}
