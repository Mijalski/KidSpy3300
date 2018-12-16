
var aInProgress = $("#show-assignment-progress");
var aInDone = $("#show-assignment-done");

var aListDone = $("#assign-graded");
var aListProgress = $("#assign-not-graded");

$(document).ready(function() {

    aInDone.click(function() {
        aListDone.toggleClass("d-none");
        aInDone.toggleClass("rotated-180");
    });

    aInProgress.click(function() {
        aListProgress.toggleClass("d-none");
        aInProgress.toggleClass("rotated-180");
    });

    $(document).ready(function() {
        $(".show-grades-student").click(function() {
            var holder = $(this).next();
            $(this).toggleClass("rotated-180");
            if (!$(this).hasClass("rotated-180")) {
                holder.empty();
                return;
            } else {

                $.ajax({
                    type: 'GET',
                    url: '../api/Students/' + $(this).data("id"),
                    dataType: 'json',
                    success: function(data) {
                        holder.empty();
                        $.each(data,
                            function(index, val) {
                                var grade = changeNumberToMark(val.item1);
                                var description = val.item2 || "";
                                holder.append('<div class="border-bottom student-mark">' +
                                    '<i class="float-right mt-2">' +
                                    val.item3 +
                                    '</i>' +
                                    '<span class="mark-big-size mark-color-' +
                                    grade +
                                    '">' +
                                    grade +
                                    '</span><div>' +
                                    description +
                                    '</div></div>');
                            });
                    }
                });
            }
        });

    });
});

function changeNumberToMark(markValue) {
    if (markValue === 1) {
        return "A";
    } else if (markValue === 2) {
        return "B";
    } else if (markValue === 3) {
        return "C";
    } else if (markValue === 4) {
        return "D";
    } else if (markValue === 5) {
        return "E";
    } else {
        return markValue;
    }
}