$(function() {
    $("#paragraf").hide();
    $("p").hide();
    $(".cls1").hide();


    $("#showAlert").click(function(){
        alert("ta da dam");
        $("#result").text(4 * 6);
        $("#paragraf").hide();
    });

    $("#animateSquare").click(function(){
        $("#square").animate({
            left: '250px',
            opacity: '0.8',
            height: '150px',
            width: '150px'
        });
    });

    $("#calculate").click(function(){
        var a = parseInt($("#inptA").val());
        var b = parseInt($("#inptB").val());
        var x = a - b;
        $("#resultMath").text(x);
        $(this).attr("style","background:green");
    });

    $("#appendHeading").click(function(){
        var heading = $("#pageTitle").val();
        var htmlHeading = "<h1 class='headingFromJS'>" + heading + "</h1>";
        $("body").append(htmlHeading);
        $("#deleteAllAppendedTitles").removeAttr("disabled");
        $("#deleteAllAppendedTitles").addClass("greenBck");
    });

    $("#deleteAllAppendedTitles").click(function(){
        $(".headingFromJS").remove();
        // $("#deleteAllAppendedTitles").Attr("disabled","");
    });
});

