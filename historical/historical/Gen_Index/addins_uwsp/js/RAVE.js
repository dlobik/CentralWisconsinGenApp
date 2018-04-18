function setRAVE(html) {
    // waiting for the page to finish loading
    $(document).ready(function() {
        var raveTarget = document.getElementById('raveEmergency'); // ID of target element.
        raveTarget.className = 'active';
        raveTarget.innerHTML = html;
    });
}

(function() {
    var protocol = location.protocol;
    var raveURL = protocol + '//www.getrave.com/rss/uwsp/channel2'; // Location of RSS Feed
    var xmlFlagURL = protocol + '//www.uwsp.edu/pointeralerts/rave.xml'; // Location of the flag file

    function getRAVE() {
        // Add a random number ( date().getTime() ) to the url to avoid caching issues with the RSS feed.
        $.ajax({
            url: protocol + '//ajax.googleapis.com/ajax/services/feed/load?v=1.0&num=10&callback=?&q=' + encodeURIComponent(raveURL) + '?' + new Date().getTime(),
            dataType: 'json',
            success: function(data) {
                if (data.responseData.feed !== null)
                    displayRAVEMessage(data.responseData.feed);
            }
        });
    }

    function displayRAVEMessage(data) {
        if (data.entries.length > 0 && data.entries[0].content.indexOf('[TURNOFFPOINTERALERTS]') === -1) {
            var title = data.entries[0].title;
            var content = data.entries[0].content;
            var date = data.entries[0].publishedDate.substring(0, data.entries[0].publishedDate.indexOf('-')) + 'Central Time';

            setRAVE('<p>' + content + '</p>' + '<date>(' + date + ')</date>');
        }
    }

    function checkFlag() {
        $.ajax({
            type: 'GET',
            dataType: 'xml',
            url: xmlFlagURL,
            success: function(response) {
                $(response).find('active').each(function() {
                    if ($(this).text() === 'true')
                        getRAVE();
                });
            }
        });
    }

    checkFlag();
})();