var dateTimeRegex = new RegExp(/([0-9]){1,2}\.([0-9]){1,2}\.([0-9]){4}/);


var dateTime = $("#date-time-to-validate");
var dateTimeValidation = $("#date-time-validation-text");

function validateDateTime() {
    if (dateTime.val().length === 0) {
        dateTimeValidation.text("Required field");
        return false;
    } else if (!dateTimeRegex.test(dateTime.val())) {
        dateTimeValidation.text("Not a correct date format");
        return false;
    } else {
        return true;
    }
}