function validateAllFields() {
    var isValid = validateUserName();
    if (isValid == true)
        isValid = validatePassword();
    return isValid;
}

function validateUserName() {
    var length = idUserName.value.length;
    if (length >= 2)
        return true;
    else {
        idUserNameErr.innerHTML = "Username should be more than 2";
        return false;
    }
}

function validatePassword() {
    var length = idPassword.value.length;
    if (length >= 5)
        return true;
    else {
        idPasswordErr.innerHTML = "Password should be more than 5";
        return false;
    }
}