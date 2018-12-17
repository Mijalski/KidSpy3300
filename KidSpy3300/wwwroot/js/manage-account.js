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

    
    $(document).ready(function() {
        $("#show-more-out").click(ajaxMoreMessagesOut);

    });
    
    $(document).ready(function() {
        $("#show-more-in").click(ajaxMoreMessagesIn);

    });
})();

var ajaxMoreMessagesOut = function() {
    var messages = $(".message-box-out");
    var userId = $(this).data("id");
    var htmlButton = $(this).get(0).outerHTML;
    $(this).after("<span>Loading...</span>");
    $.ajax({
        type: 'GET',
        url: '../api/Messages?id='+userId+"&offset="+messages.length+"&inbound=false",
        dataType: 'json',
        //data: { offset : messages.length},
        success: function(data) {
            $("#show-more-out").next().remove();
            $("#show-more-out").remove();
            $.each(data,
                function(index, val) {
                    if (val.item1 !== -1) {
                        messages.last().after('<div class="message-box  message-box-out  border-top mt-2">' +
                            '<a class="msg-title" href="/ManageAccount/ShowMessage?messageId=' +
                            val.item1 +
                            '">' +
                            val.item2 +
                            '</a><div>To:' +
                            val.item3 +
                            ' </div></div>');
                    } else {
                        $("#show-more-out").next().remove();
                        $("#show-more-out").remove();
                        $(".message-box-out").last().after(htmlButton);
                        $("#show-more-out").click(ajaxMoreMessagesOut);
                    }
                });
        }
    });
}

var ajaxMoreMessagesIn = function() {
    var messages = $(".message-box-in");
    var userId = $(this).data("id");
    var htmlButton = $(this).get(0).outerHTML;
    $(this).after("<span>Loading...</span>");
    $.ajax({
        type: 'GET',
        url: '../api/Messages?id='+userId+"&offset="+messages.length+"&inbound=true",
        dataType: 'json',
        //data: { offset : messages.length},
        success: function(data) {
            $("#show-more-in").next().remove();
            $("#show-more-in").remove();
            $.each(data,
                function(index, val) {
                    if (val.item1 !== -1) {
                        messages.last().after('<div class="message-box  message-box-in  border-top mt-2">' +
                            '<a class="msg-title" href="/ManageAccount/ShowMessage?messageId=' +
                            val.item1 +
                            '">' +
                            val.item2 +
                            '</a><div>To:' +
                            val.item3 +
                            ' </div></div>');
                    } else {
                        $("#show-more-in").next().remove();
                        $("#show-more-in").remove();
                        $(".message-box-in").last().after(htmlButton);
                        $("#show-more-in").click(ajaxMoreMessagesIn);
                    }
                });
        }
    });
}



