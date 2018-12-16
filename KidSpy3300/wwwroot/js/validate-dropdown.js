var dropdown = $("#dropdown-to-validate");
var dropdownValidation = $("#dropdown-validate-text");

dropdown.change(function() {
    validateDropdown();
});

function validateDropdown() {
    if (dropdown.children("option:selected").val() < 0) {
        dropdownValidation.text("Required field");
        return false;
    } else {
        dropdownValidation.text("");
        return true;
    }
}