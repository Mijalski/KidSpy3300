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

    if ($("#add-assignment").length) {
        var showNotGradedA = $("#show-assign-not");
        var showGradedA = $("#show-assign");
        var notGradedA = $("#assign-not-graded");
        var gradedA = $("#assign-graded");
        
        gradedA.hide();

        showGradedA.click(function() {
            showNotGradedA.removeClass("font-weight-bold");
            showGradedA.addClass("font-weight-bold");
            notGradedA.hide();
            gradedA.show();
        });
    
        showNotGradedA.click(function() {
            showNotGradedA.addClass("font-weight-bold");
            showGradedA.removeClass("font-weight-bold");
            notGradedA.show();
            gradedA.hide();
        });
    }
})();

