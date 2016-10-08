$(document).ready(function (e) {

    $('.ValidateFirstName').focus();

    $('.ValidateDate').datepicker();

    $('.SaveButton').click(function () {
        return ValidateInstructor();
    })


});

function ValidateInstructor() {
    var returnValue = true;
    var nonDateValid = true;


    //==||  VALIDATE FIRST-NAME INPUT-BOX  ||==\\
    if ($('.ValidateFirstName').val().trim().length <= 0) {
        $('#ValidationMessageFirstName').show();
        returnValue = false;
        nonDateValid = false;
    } else {
        $('#ValidationMessageFirstName').hide();
    }

    //==||  VALIDATE LAST-NAME INPUT-BOX  ||==\\
    if ($('.ValidateLastName').val().trim().length <= 0) {
        $('#ValidationMessageLastName').show();
        returnValue = false;
        nonDateValid = false;

        $('.ValidateLastName').focus();
    } else {
        $('#ValidationMessageLastName').hide();
    }

    //==||  VALIDATE DATE INPUT BOXES  ||==\\

    var dateFieldObject;

    $(".ValidateDate").each(function (index) {

        if ($(this).val().trim().length >= 0) {

            var checkDate = $(this).val();
            if (IsDate(checkDate)) {
                $("#" + $(this).data("messageId")).hide();
            }
            else {
                $("#" + $(this).data('messageId')).show();

                if (nonDateValid) {
                    if (dateFieldObject === undefined) {
                        dateFieldObject = $(this);
                        $(this).focus();
                    }
                }

                returnValue = false;
            }
        }
        else {
            $('#' + $(this).data('messageId')).hide();
        }
    });

    return returnValue;
}


//==||  VALIDATE DATE INPUT  ||==\\
function IsDate(DateValue) {
    var currVal = DateValue;
    if (currVal == '') {
        return false;
    }

    var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
    var dtArray = currVal.match(rxDatePattern);

    if (dtArray == null) {
        return false;
    }

    dtMonth = dtArray[1];
    dtDay = dtArray[3];
    dtArray = dtArray[5];

    if (dtMonth < 1 || dtMonth > 12) {
        return false;
    } else if (dtDay < 1 || dtDay > 31) {
        return false;
    } else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
        return false;
    } else if (dtMonth == 2) {
        var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
        if (dtDay > 29 || (dtDay == 29 && !isLeap)) {
            return false;
        }
    }
    return true;
}