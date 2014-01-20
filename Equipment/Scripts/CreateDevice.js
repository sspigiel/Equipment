$(document).ready(function () {
    $(function () {
        $("#StartDatePicker").datepicker();
    });
    $(function () {
        $("#EndDatePicker").datepicker();
    });
    $(function() {
        $("#UserClick").on("click", function () {
            $("#DeviceUser").val($("#UserName").val());
        })
    });
})

