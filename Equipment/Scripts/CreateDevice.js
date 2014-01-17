$(document).ready(function () {
   /* $.ajax({
        type: "POST",
        url: "/BusinessLogic/TestClass.cs/foo",
        
    })
  .done(function (msg) {
      alert("Data Saved: " + msg);
  }); */
    $(function () {
        $("#datepicker").datepicker();
    });
    $("#UserClick").click(function () {
        var id = $('#UserName').val();
        foo(id);
    });
    function foo(value) {
        $("#DeviceUser").val(value);
    };
})

