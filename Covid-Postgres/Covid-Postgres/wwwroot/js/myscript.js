
    
$(document).ready(function () {

    $(".clickk").click(function () {
        var personiddata = parseInt($(this).attr("data-PersonId"));
        $.ajax(
            {
                type: "POST",
                url: "/Home/GetPerson",
                data: {
                    PersonId: personiddata
                },
                success: function (result) {
                    $(".field2").html(result);
                }
            });
    });
});

$(document).ready(function () {

    $("#search").click(function () {
        var personid = $("#searchval").val();
        $.ajax(
            {
                type: "POST",
                url: "/Home/SearchPerson",
                data: {
                    personid: personid
                },
                success: function (result) {
                    $(".fullfield").html(result);
                }
            });
    });
});


$(document).ready(function () {

    $("#orderByName").click(function () {
        $.ajax(
            {
                type: "POST",
                url: "/Home/OrderByName",
                data: {
                },
                success: function (result) {
                    Swal.fire({
                        showDenyButton: true,

                        text: 'Sắp xếp theo tên ',
                        icon: 'warning',
                    })
                    $(".field3").html(result);
                }
            });
    });
});

$(document).ready(function () {

    $("#orderByCreated").click(function () {
        $.ajax(
            {
                type: "POST",
                url: "/Home/OrderByCreateDate",
                data: {
                },
                success: function (result) {
                    Swal.fire({
                        showDenyButton: true,

                        text: 'Sắp xếp theo ngày nhập viên ',
                        icon: 'warning',
                    })
                    $(".field3").html(result);
                }
            });
    });
});



