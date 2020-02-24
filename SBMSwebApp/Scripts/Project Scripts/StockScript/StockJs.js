

//Load Products By Category JS Start
$("#CategoryId").change(function () {

    var categoryId = $("#CategoryId").val();

    $.ajax({
        url: "/Stock/GetProductsByCategory",
        type: "POST",
        data: { categoryId: categoryId },
        success: function (response) {

            if (response === undefined || response.length == 0) {
                $("#ProductId").empty();
                $("#ProductId").append("<option value=''>No Products Found!</option>");
                return;
            }
            $("#ProductId").empty();
            $("#ProductId").append("<option value=''>--Select--</option>");
            $.each(response, function (i, item) {
                $("#ProductId").append("<option value='" + item.ProductId + "'>" + item.ProductName + "</option>");
            })
        }
    })
})
//Load Products By Category JS End