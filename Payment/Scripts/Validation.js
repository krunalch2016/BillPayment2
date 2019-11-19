function PasswordValidation(password, labelpassword) {
    var Password = password.value;
    var Result;
    var PasswordPattern = "(?=.*[0-9])(?=.*[!@#$%^&*+-/])(?=.*[a-z])(?=.*[A-Z])";
    if (Password.match(PasswordPattern)) {
        labelpassword.innerHTML = " ";
        Result = true;
    }
    else {
        labelpassword.innerHTML = "Give proper password";
        Result = false;
    }
    return Result;
}
function UserNameValidation(username, labelusername) {
    var UserName = username.value;
    var Result;
    var UserNamePattern = "^[a-zA-Z]*$";
    //var Regex = new Regex(UserNamePattern); 
    if (UserName.match(UserNamePattern)) {
        labelusername.innerHTML = " ";
        Result = true;
    }
    else {
        labelusername.innerHTML = "(Only Alphabet)";
        Result = false;
    }
    return Result;
}
function AccountHolderNameValidation(accountholdername, labelaccountholdername) {
    var AccountHolderName = accountholdername.value;
    var Result;
    var AccountHolderNamePattern = "^[a-zA-Z]*$";
    //var Regex = new Regex(UserNamePattern); 
    if (AccountHolderName.match(AccountHolderNamePattern)) {
        labelaccountholdername.innerHTML = " ";
        Result = true;
    }
    else {
        labelaccountholdername = "AccountHolderName(Only Alphabet)";
        Result = false;
    }
    return Result;
}
function MobileNumberValidation(mobilenumber, labelmobilenumber) {
    var contact = mobilenumber.value;
    var Result;
    var contactPattern = "^[0-9]*$";
    if (contact.match(contactPattern) && (contact.length == 10)) {
        labelmobilenumber.innerHTML = " ";
        Result = true;
    }
    else {
        labelmobilenumber.innerHTML = "Should be 10 Numbers";
        Result = false;
    }
    return Result;
}
function CardNumberValidation(cardnumber, labelcardnumber) {

    var CardNumber = cardnumber.value;
    var Result;
    var contactPattern = "^[0-9]*$";
    if (CardNumber.match(contactPattern) && (CardNumber.length == 16)) {
        labelcardnumber.innerHTML = " ";
        Result = true;
    }
    else {
        labelcardnumber.innerHTML = "Should be 16 Numbers";
        Result = false;
    }
    return Result;
}

function CvvNumberValidation(cvvnumber, labelcvvnumber) {
    var CvvNumber = cvvnumber.value;
    var Result;
    var CvvNumberPattern = "^[0-9]*$";
    if (CvvNumber.match(CvvNumberPattern) && (CvvNumber.length == 3)) {
        labelcvvnumber.innerHTML = " ";
        Result = true;
    }
    else {
        labelcvvnumber.innerHTML = "Should be 3 Numbers";
        Result = false;
    }
    return Result;
}
function AmountValidation(amount, labelamount) {
    var Amount = amount.value;
    var Result;
    var AmountPattern = "^[0-9]*$";
    if (Amount.match(AmountPattern)) {
        labelamount.innerHTML = " ";
        Result = true;
    }
    else {
        labelamount.innerHTML = "Invalid Amount";
        Result = false;
    }
    return Result;
}
function ExpiryDateValidation(expirydate, labelexpirydate) {
    var ExpiryDate = expirydate.value;
    var Result;
    var ExpiryDatePattern = "(?=.*[0-9])(?=.*[0-9])(?=.*[/])(?=.*[0-9])(?=.*[0-9]).{5,}";
    if (ExpiryDate.match(ExpiryDatePattern)) {
        labelexpirydate.innerHTML = " ";
        Result = true;
    }
    else {
        labelexpirydate.innerHTML = "Invalid ExpiryDate";
        Result = false;
    }
    return Result;
}

function SecurityAnswerValidation(securityanswer, labelsecurityanswer) {
    var SecurityAnswer = securityanswer.value;
    var Result;
    var UserNamePattern = "^[a-zA-Z]*$";
    //var Regex = new Regex(UserNamePattern); 
    if (SecurityAnswer.match(UserNamePattern)) {
        labelsecurityanswer.innerHTML = " ";
        Result = true;
    }
    else {
        labelsecurityanswer.innerHTML = "Only Alphabet";
        Result = false;
    }
    return Result;
}


function EmailIDValidation(email, labelemail) {
    var EmailID = email.value;
    var Result;
    var EmailIDPattern = "(?=.*[@])(?=.*[.])(?=.*[c])(?=.*[o])(?=.*[m])";
    //var Regex = new Regex(UserNamePattern); 
    if (EmailID.match(EmailIDPattern)) {
        labelemail.innerHTML = " ";
        Result = true;
    }
    else {
        labelemail.innerHTML = "Invalid EmailID";
        Result = false;
    }
    return Result;
}

function ConfirmPasswordValidation(password, confirmpassword) {
    var Password = password.value;
    var ConfirmPassword = confirmpassword.value;
    if (Password != ConfirmPassword) {
        alert("Password doesn't match");
        return false;
    }
    return true;
}

function RegisterValidation(username, lblusername, mobilenumber, lblmobilenumber, email, lblemail, securityanswer, lblsecurityanswer, password, lblpassword) {
    var UserName = username.value;
    var Password = password.value;
    var EmailID = email.value;
    var MobileNumber = mobilenumber.value;
    var SecurityAnswer = securityanswer.value;
    var Result;
    if (UserName !== "" && Password !== "" && EmailID !== "" && MobileNumber !== "" && SecurityAnswer !== "") {
        Result = true;
    }
    else {
        if (UserName == "") {
            lblusername.innerHTML = "*required"
            //alert("UserName Required")
            Result = false;
        }
        else {
            lblusername.innerHTML = ""
            Result = true;
        }

        if (MobileNumber == "") {
            lblmobilenumber.innerHTML = "*required"
            //alert("UserName Required")
            Result = false;
        }
        else {
            lblmobilenumber.innerHTML = ""
            Result = true;
        }
        if (EmailID == "") {
            lblemail.innerHTML = "*required"
            //alert("UserName Required")
            Result = false;
        }
        else {
            lblemail.innerHTML = ""
            Result = true;
        }
        if (SecurityAnswer == "") {
            lblsecurityanswer.innerHTML = "*required"
            //alert("UserName Required")
            Result = false;
        }
        else {
            lblsecurityanswer.innerHTML = ""
            Result = true;
        }
        if (Password == "") {
            lblpassword.innerHTML = "*required"
            //alert("Password Required")
            Result = false;
        }
        else {
            lblpassword.innerHTML = ""
            Result = true;
        }
    }
    return Result;
}

function CardDetailsValidation(cardnumber, lblcardnumber, cvvnumber, lblcvvnumber, expirydate, lblexpirydate, accountholdername, lblaccountholdername, amount, lblamount) {
    var CardNumber = cardnumber.value;
    var CvvNumber = cvvnumber.value;
    var ExpiryDate = expirydate.value;
    var AccountHolderName = accountholdername.value;
    var Amount = amount.value;
    var Result;
    if (CardNumber !== "" && CvvNumber !== "" && ExpiryDate !== "" && AccountHolderName !== "" && Amount !== "") {
        Result = true;
    }
    else {
        if (CardNumber == "") {
            lblcardnumber.innerHTML = "CardNumber required"
            Result = false;
        }
        else {
            lblcardnumber.innerHTML = ""
            Result = true;
        }
        if (CvvNumber == "") {
            lblcvvnumber.innerHTML = "CvvNumber required"
            Result = false;
        }
        else {
            lblcvvnumber.innerHTML = ""
            Result = true;
        }
        if (ExpiryDate == "") {
            lblexpirydate.innerHTML = "ExpiryDate required"
            Result = false;
        }
        else {
            lblexpirydate.innerHTML = ""
            Result = true;
        }
        if (AccountHolderName == "") {
            lblaccountholdername.innerHTML = "AccountHolderName required"
            Result = false;
        }
        else {
            lblaccountholdername.innerHTML = ""
            Result = true;
        }
        if (Amount == "") {
            lblamount.innerHTML = "Amount required"
            Result = false;
        }
        else {
            lblamount.innerHTML = ""
            Result = true;
        }
    }
    return Result;
}

function PostpaidValidation(mobilenumber, lblmobilenumber) {
    var MobileNumber = mobilenumber.value;
   

    var Result;
    if (MobileNumber !== "") {
        Result = true;
    }
    else {
        if (MobileNumber == "") {
            lblmobilenumber.innerHTML = "MobileNumber required"
            //alert("UserName Required")
            Result = false;
        }
        else {
            lblmobilenumber.innerHTML = ""
            Result = true;
        }
      
    }
    return Result;
}

function PrepaidValidation(mobileTxt, mobileLBL) {
    // var MobileNumber = document.getElementById("mobileTxt");

    var Result;
    if (mobileTxt !== "") {
        Result = true;
    }
    else if (mobileTxt == "") {
        //if (MobileNumber == "") {
        //    alert("hello");
        document.getElementById('mobileLBL').innerHTML = "* Required"
        //alert("UserName Required")
        Result = false;
        //}
        //else {
        //    document.getElementById('lblMobileNumber').innerHTML = ""
        //    Result = true;
        //}
    }
    return Result;
}
function IBValidation(UserID, lblUserID, password, lblpassword, bankname, lblbankname, Amount, lblAmount) {
    var Userid = UserID.value;
    var Password = password.value;
    var Bankname = bankname.value;
    var amount = Amount.value;

    var Result;
    if (Userid !== "" && Password !== "" && Bankname !== "" && amount !== "") {
        Result = true;
    }
    else {
        if (Userid == "") {
            lblUserID.innerHTML = "UserID required"
            Result = false;
        }
        else {
            lblUserID.innerHTML = ""
            Result = true;
        }
        if (Password == "") {
            lblpassword.innerHTML = "Password required"
            Result = false;
        }
        else {
            lblpassword.innerHTML = ""
            Result = true;
        }
        if (Bankname == "") {
            lblbankname.innerHTML = "BankName required"
            Result = false;
        }
        else {
            lblbankname.innerHTML = ""
            Result = true;
        }
        if (amount == "") {
            lblAmount.innerHTML = "Amount required"
            Result = false;
        }
        else {
            lblAmount.innerHTML = ""
            Result = true;
        }

    }
    return Result;
}

function ForgotPasswordValidation(mobilenumber, lblMobileNumber, securityanswer, lblSecurityAnswer, password, lblpassword, confirmpassword, lblConfirmPassword) {
    var MobileNumber = mobilenumber.value;
    var SecurityAnswer = securityanswer.value;
    var Password = password.value;
    var ConfirmPassword = confirmpassword.value;

    var Result;
    if (MobileNumber !== "" && SecurityAnswer !== "" && Password !== "" && ConfirmPassword !== "") {
        Result = true;
    }
    else {
        if (MobileNumber == "") {
            lblMobileNumber.innerHTML = "MobileNumber required"
            Result = false;
        }
        else {
            lblMobileNumber.innerHTML = ""
            Result = true;
        }
        if (SecurityAnswer == "") {
            lblSecurityAnswer.innerHTML = "SecurityAnswer required"
            Result = false;
        }
        else {
            lblSecurityAnswer.innerHTML = ""
            Result = true;
        }
        if (Password == "") {
            lblpassword.innerHTML = "Password required"
            Result = false;
        }
        else {
            lblpassword.innerHTML = ""
            Result = true;
        }
        if (ConfirmPassword == "") {
            lblConfirmPassword.innerHTML = "ConfirmPassword required"
            Result = false;
        }
        else {
            lblConfirmPassword.innerHTML = ""
            Result = true;
        }

    }
    return Result;
}

function LoginValidation(mobilenumber, lblmobilenumber, password, lblpassword) {
    // sessionStorage.setItem("mobile",lbl.value);
    var MobileNumber = mobilenumber.value;
    var Password = password.value;
    var Result;
    if (Password != "" && MobileNumber != "") {
        Result = true;
    }
    else {
        if (Password == "") {
            lblpassword.innerHTML = "Password Required"
            //alert("Password Required")
            Result = false;
        }
        else {
            lblpassword.innerHTML = ""
            Result = true;
        }
        if (MobileNumber == "") {
            lblmobilenumber.innerHTML = "MobileNumber Required"
            //alert("contact Required")
            Result = false;
        }
        else {
            lblmobilenumber.innerHTML = ""
            Result = true;
        }
    }
    return Result;
}









