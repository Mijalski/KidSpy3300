
var studentMarks = $(".student-mark");
studentMarks.find(".fa-edit").hide();

studentMarks.mouseenter(function() {
    $(this).find(".fa-edit").show();
});

studentMarks.mouseleave(function() {
    $(this).find(".fa-edit").hide();
});