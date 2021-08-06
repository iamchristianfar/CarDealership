


function selectClientFromAddTransaction(url) {
    var clientId = $("#clientSelect").find(":selected").val();
    $("#carSelect").empty();
    $.ajax({
        type: "POST",
        url: url,
        data: { clientId: clientId }
    }).done(function (result) {
        console.log(result);
        $.each(result, function (i, car) {
            $("#carSelect").append(new Option(car.carName, car.id));
        });
    });
}

