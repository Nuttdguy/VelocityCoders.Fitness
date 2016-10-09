
var _serviceBaseUrl = "http://service.fitness.com";


$(document).ready(function (e) {

    $('.ManageButton').button({
        classes: {
            "ui-button": "ui-corner-all"
        },
        icons: {
            primary: "ui-icon-gear"
        }
    });


    //==|| DISPLAY INSTRUCTOR NAME AND SET HIDDEN ID  ||==\\
    SetInstructorInfo();

    
    //==|| POPULATE DROP-DOWN ||==\\
    PopulateFitnessClassDropDown();


    //==|| DISPLAY LIST OF FITNESS CLASSES  ||==\\
    DisplayFitnessClassList();

})




//==||  POPULATES THE DROP-DOWN LIST FOR FITNESS CLASS  ||==\\
function PopulateFitnessClassDropDown() {

    $.ajax({
        type: "GET",
        url: _serviceBaseUrl + "/FitnessService/Class/List/",
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (data) {
        var dropDown = $('#drpFitnessClass');

        for (var x = 0; x < data.length; x++) {
            dropDown.append($('<option></option>').val(data[x].FitnessClassId).html(data[x].FitnessClassName));
        }

    }).fail(function (data) {
        //==|| SHOW MESSSAGE TO USR IF FAIL ||==\\
        DisplayMessage(true, 'There was an error loading the drop-down list.')

    }).always(function () {
        //==||  ALWAYS EXECUTES - PROVIDING NO RESULTS  ||==\\
    })

}


//==||  DISPLAYS ERROR MESSAGE  ||==\\
function DisplayMessage(showMessage, message, showButton, clearCurrentMessages) {
    if (showMessage) {

        //==||  CLEAR ANY CURRENT MESSAGES  ||==\\
        if (clearCurrentMessages)
            $('#MessageAreaList').empty();


        $('#MessageArea').show();

        $('#MessageAreaList').append('<li>' + message + '</li>');


        //==||  HIDE THE ASSOCIATE BUTTON  ||==\\
        if (showButton)
            $('.AssociateFitnessClassButton').show();
        else
            $('.AssociateFitnessClassButton').hide();
    }
    else {
        $('#MessageArea').hide();
        $('.AssociateFitnessClassButton').show();
    }
}


//==||  SETS THE INSTRUCTOR-ID  ||==\\
function SetInstructorInfo() {

    var instructorId = $('#InstructorId').val();

    if (instructorId > 0) {

        $.ajax({
            type: "GET",
            url: _serviceBaseUrl + "/InstructorService/Detail/" + instructorId,
            contentType: "application/json; charset=utf-8",
            dataType: "json"

        }).done(function (data) {

            $('#InstructorName').html(data.FirstName + ' ' + data.LastName);

        }).fail(function (data) {

            DisplayMessage(true, 'There was an error retrieving the Instructor');
        });
    }
    else
        DisplayMessage(true, "Instructor Id can not be resolved. Please contact an administrator");
}


//==|| VALIDATE FORM  ||==\\
function ValidateClientForm() {

    var dropDown = $('#drpFitnessClass');
    var instructorId = $('#InstructorId').val();
    var fitnessClassId = dropDown.val();

    if (fitnessClassId > 0) {
        $.ajax({
            type: "PUT",
            url: _serviceBaseUrl + "/InstructorService/Detail/" + instructorId,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: '"'+ fitnessClassId + '"'
        }).done(function (data) {
            var fitnessClassName = dropDown.children(':selected').text();

            //==||  SUCCESS - DISPLAY MESSAGE  ||==\\
            DisplayMessage(true, "Fitness Class " + fitnessClassName + " associated successfully.", true, true);

            //==|| CALL FUNCTION TO APPEND A RECORD TO THE TABLE  ||==\\
            AddToDisplayTable(data, fitnessClassName);

            //==||  SET THE UI DISPLAY AND EVENT HANDLER FOR THE DELETE BUTTON  ||==\\
            SetDeleteButtonProperties();

        }).fail(function (jqXHR, textStatus) {
            DisplayMessage(true, "There was an error with your submission.", true);
        })
    }
    else {
        DisplayMessage(true, "Please select a valid item from the Fitness class drop-down.", true);
    }

    //==||  RETURN FALSE SO THE BUTTON ON THE FRONT-END PAGE DOES NOT SUBMIT ||==\\
    return false;
}


//==||  DISPLAY FITNESS CLASS LIST FOR INSTRUCTOR  ||==\\

function DisplayFitnessClassList() {
    var instructorId = $('#InstructorId').val();

    $.ajax({
        type: "GET",
        url: _serviceBaseUrl + "/FitnessService/Class/List/" + instructorId,
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).done(function (data) {
        for (var x = 0; x < data.length; x++) {
            AddToDisplayTable(data[x].InstructorFitnessClassId, data[x].FitnessClassName);
        }

        SetDeleteButtonProperties();
    }).fail(function (data) {

        DisplayMessage(true, "There was an error loading the Fitness Class list.", true);

    }).always(function () {
        //==|| finally block
    })
}


//==||  UTILIZE TO APPEND TABLE ROW FOR EACH ITEM ITERATION  ||==\\

function AddToDisplayTable(instructorFitnessClassId, fitnessClassName) {
    var table = $('#FitnessClassTable');

    table.append('<tr><td class="CenterText"> <button class="DeleteButton" value="' + instructorFitnessClassId + '"></button></td><td>' + fitnessClassName + '</td></tr>');
}

//==||  SET UI STYLE FOR BUTTON AND JQUERY CLICK-HANDLER EVENT  ||==\\

function SetDeleteButtonProperties() {

    $('.DeleteButton').button({
        classes: {
            "ui-button": "ui-corner-all"
        },
        icons: {
            primary: "ui-icon-trash"
        }
    });

    $('.DeleteButton').click(function (e) {
        var instructorFitnessClassId = $(this).val();
        var trElement = $(this).closest('tr');

        //==||  CALL TO WEB-SERVICE TO DELETE ASSOCIATED RECORD  ||==\\
        DeleteInstructorFitnessClass(instructorFitnessClassId, trElement);

        e.preventDefault();
    });

}


//==||  DELETE INSTRUCTOR FITNESS CLASS  ||==\\

function DeleteInstructorFitnessClass(instructorFitnessClassId, trElement) {

    if (instructorFitnessClassId > 0) {
        if (confirm("Are you sure you want to Delete this Fitness Class?")) {
            $.ajax({
                type: "DELETE",
                url: _serviceBaseUrl + "/InstructorService/Detail/" + instructorFitnessClassId,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: '"' + instructorFitnessClassId + '"'

            }).done(function (data) {
                trElement.fadeOut();

            }).fail(function (jqXHR, textStatus) {
                DisplayMessage(true, "Fitness Class deletion failed.", true, true);

            });
        }
    }
    else
        DisplayMessage(true, "Deletion of Fitness Class Failed. Invalid Id: " + instructorFitnessClassId, true, true);
}


