(function () {
    if ($('input[type=radio][id=parent-register]').is(':checked')) {
        $("#class-select-register").attr('disabled', true);
    }
})();



$('input[type=radio][name=userAccountStatus]').change(function() {
    var isParent = $('input[type=radio][id=parent-register]').is(':checked');
    var classDropdown = $("#class-select-register");
    if (isParent === false) {
        classDropdown.removeAttr('disabled');
    } else {
        classDropdown.attr('disabled', true);
    }
});
