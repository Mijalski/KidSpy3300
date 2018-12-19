var emailRegex = new RegExp(/(\S){3,}@(\S){2,}\.(\S){2,}/);

var email = $("#email-log-in");
var password = $("#password-log-in");
var emailValidation = $("#login-login-validation");
var passwordValidation = $("#login-password-validation");
var classSelect = $("#class-select-register");
var classValidation = $("#class-select-register-validation");


(function () {
    if ($('input[type=radio][id=parent-register]').is(':checked')) {
        classSelect.attr('disabled', true);
    }
})();

$('input[type=radio]').change(function() {
    var isParent = $('input[type=radio][id=parent-register]').is(':checked');
    if (isParent === false) {
        classSelect.removeAttr('disabled');
    } else {
        classSelect.attr('disabled', true);
    }
    
});

function validateLogin() {

    var isValid = true;
    if (email.val() === "") {
        emailValidation.text("Required field");
        isValid = false;
    } else if  (!emailRegex.test(email.val())) {
        emailValidation.text("Please enter a valid email address.");
        isValid = false;
    }
    if (password.val() === "") {
        passwordValidation.text("Required field");
        isValid = false;
    }else if  (password.val().length < 3) {
        passwordValidation.text("Password too short");
        isValid = false;
    }
    return isValid;
}
function validateEmail() {
    if (emailRegex.test(email.val())) {
        emailValidation.text("");
    }
}

function validatePassword() {
    if (password.val().length >= 3) {
        passwordValidation.text("");
    }
}

email.blur(function() {
    validateEmail();
});
email.keydown(function() {
    validateEmail();
});

password.blur(function() {
    validatePassword();
});
password.keydown(function() {
    validatePassword();
});

classSelect.change(function() {
    validateRegister();
});

function validateRegister() {
    if (classSelect.children("option:selected").val() < 0 && !$('input[type=radio][id=parent-register]').is(':checked')) {
        classValidation.text("Required field");
        return false;
    } else {
        classValidation.text("");
        return true;
    }
}