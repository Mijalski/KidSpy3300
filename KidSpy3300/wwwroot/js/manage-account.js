(function () {
    var showIn = $("#show-in");
    var showOut = $("#show-out");
    var msgIn = $("#msg-in");
    var msgOut = $("#msg-out");

    msgOut.hide();

    showOut.click(function() {
        showIn.removeClass("font-weight-bold");
        showOut.addClass("font-weight-bold");
        msgIn.hide();
        msgOut.show();
    });
    
    showIn.click(function() {
        showIn.addClass("font-weight-bold");
        showOut.removeClass("font-weight-bold");
        msgIn.show();
        msgOut.hide();
    });

})();

