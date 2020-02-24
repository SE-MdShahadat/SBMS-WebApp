



////Show Product Code Start
$("#ProductId").change(function () {
    
    var productId = $("#ProductId").val();

    $.ajax({
        url: "/Purchase/GetProductHistory",
        type: "POST",
        data: { productId: productId },
        success: function (model) {
            //var productCodeString = model.ProductCode;
            $("#ProductCode").val(model.ProductCode);
            $("#PreviousCostPrice").val(model.PreviousCostPrice);
            $("#PreviousMRP").val(model.PreviousMRP);
        }
    })

})
////Show Product Code End

////Show Total Quantity JS Code Start
$("#UnitPrice").keyup(function () {

    var quantity = $("#Quantity").val();
    if (quantity !== undefined || quantity.length == 0) {
        var unitPrice = $("#UnitPrice").val();
        var totalPrice = unitPrice * quantity;
        $("#TotalPrice").val(totalPrice);

        //Show New MRP 25%of unit price
        var costingAmount = (unitPrice * 25) / 100;
        var newMRP = parseFloat(unitPrice) + parseFloat(costingAmount);
        $("#NewMRP").val(newMRP);

    }
})

$("#Quantity").keyup(function () {
    var unitPrice = $("#UnitPrice").val();
    if (unitPrice !== undefined || quantity.length == 0) {
        var quantity = $("#Quantity").val();
        var totalPrice = unitPrice * quantity;
        $("#TotalPrice").val(totalPrice);
    }
})
////Show Total Quantity JS Code End


////Table JS Code Start
$("#AddButton").click(function () {
    addProductsInList();
});

function addProductsInList() {

    var getProducts = getProductsFromTextBox();

    var index = $("#productTableBody").children("tr").length;

    var sl = index;
    var indexCell = "<td style='display:none'><input type='hidden' id='index" + index + "' name='PurchaseDetails.index' value='" + index + "' /></td>";
    var slCell = "<td>" + (++sl) + "</td>";
    var productCell = "<td style='display:none'><input type='hidden' id='product" + index + "' name='PurchaseDetails[" + index + "].ProductId' value='" + getProducts.ProductId + "'/></td>";
    var productCodeCell = "<td>" + getProducts.ProductCode + "</td>";
    var manufactureDateCell = "<td><input type='hidden' id='manufactureDate" + index + "' name='PurchaseDetails[" + index + "].ManufactureDate' value='" + getProducts.ManufactureDate + "' />" + getProducts.ManufactureDate + "</td>";
    var expireDateCell = "<td><input type='hidden' id='expireDate" + index + "' name='PurchaseDetails[" + index + "].ExpireDate' value='" + getProducts.ExpireDate + "' />" + getProducts.ExpireDate + "</td>";
    var quantityCell = "<td><input type='hidden' id='quantity" + index + "' name='PurchaseDetails[" + index + "].Quantity' value='" + getProducts.Quantity + "' />" + getProducts.Quantity + "</td>";
    var unitPriceCell = "<td><input type='hidden' id='unitPrice" + index + "' name='PurchaseDetails[" + index + "].UnitPrice' value='" + getProducts.UnitPrice + "' />" + getProducts.UnitPrice + "</td>";
    var totalPriceCell = "<td><input type='hidden' id='totalPrice" + index + "' name='PurchaseDetails[" + index + "].TotalPrice' value='" + getProducts.TotalPrice + "' />" + getProducts.TotalPrice + "</td>";
    var newMrpCell = "<td><input type='hidden' id='newMRP" + index + "' name='PurchaseDetails[" + index + "].NewMRP' value='" + getProducts.NewMRP + "' />" + getProducts.NewMRP + "</td>";
    var remarkCell = "<td><input type='hidden' id='remark" + index + "' name='PurchaseDetails[" + index + "].Remark' value='" + getProducts.Remark + "' />" + getProducts.Remark + "</td>";
    //var editCell = "<td><button type='button' id='removeButton" + index + "' class='btn'>Edit</button></td>";
    var deleteCell = "<td><a id='deleteCell' class='btn btn-danger'><i class='glyphicon glyphicon-trash'></i></a></td>";

    //var createRow = "<tr id='row" + index + "'>" + indexCell + slCell + productCell + productCodeCell + manufactureDateCell + expireDateCell + quantityCell + unitPriceCell + totalPriceCell + newMrpCell + remarkCell + removeCell + "</tr>";
    var createRow = "<tr>" + indexCell + slCell + productCell + productCodeCell + manufactureDateCell + expireDateCell + quantityCell + unitPriceCell + totalPriceCell + newMrpCell + remarkCell + deleteCell + "</tr>";
    $("#productTableBody").append(createRow);
    $("#PurchaseSubmitButton").prop('disabled', false);

    //    //Clear elements

    //    ////$("#ProductId").val("Select");    
    //    //$("#ProductCode").val("");
    //    //$("#Quantity").val("");
    //    //$("#UnitPrice").val("");
    //    //$("#TotalPrice").val("");
    //    //$("#NewMRP").val("");
    //    //$("#Remark").val("");
    //    //$("#ManufactureDate").val("");
    //    //$("#ExpireDate").val("");
    //    //$("#PreviousMRP").val("");
    //    //$("#PreviousCost").val("");

}

function getProductsFromTextBox() {

    var productId = $("#ProductId").val();
    var productCode = $("#ProductCode").val();
    var quantity = $("#Quantity").val();
    var unitPrice = $("#UnitPrice").val();
    var totalPrice = $("#TotalPrice").val();
    var manufactureDate = $("#ManufactureDate").val();
    var expireDate = $("#ExpireDate").val();
    var remark = $("#Remark").val();
    var newMRP = $("#NewMRP").val();



    if (productId === undefined || productId.length == 0) {
        alert('Please select your product!');
        return;
    }
    if (quantity === undefined || quantity.length == 0) {
        alert('Please enter product quantity!');
        return;
    }
    if (unitPrice === undefined || unitPrice.length == 0) {
        alert('Please enter product unit price!');
        return;
    }
    //if (manufactureDate === undefined || manufactureDate.length == 0) {
    //    manufactureDate = "--";
    //}
    //if (expireDate === undefined || expireDate.length == 0) {
    //    expireDate = "--";
    //}
    //if (remark === undefined || remark.length == 0) {
    //    remark = "--";
    //}

    var product = {

        "ProductId": productId,
        "ProductCode": productCode,
        "Quantity": quantity,
        "UnitPrice": unitPrice,
        "TotalPrice": totalPrice,
        "ManufactureDate": manufactureDate,
        "ExpireDate": expireDate,
        "Remark": remark,
        "NewMRP": newMRP
    }
    return product;
}
////Table JS Code End

//Table edit/delete/ action js code start here

//Remove Table Row
$(".table tbody").on('click', '#deleteCell', function () {
    $(this).closest('tr').remove();
    //Check Exist Table Row
    var row = $("#productTableBody").children('tr').length;
    if (row > 0) {
        $("#PurchaseSubmitButton").prop('disabled', false);
    }
    else {
        $("#PurchaseSubmitButton").prop('disabled', true);
    }
})

//Table edit/delete/ action js code end here