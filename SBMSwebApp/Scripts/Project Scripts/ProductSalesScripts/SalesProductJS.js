
//Show customer loyalty point Js Start
$("#CustomerId").change(function () {
    var customerId = $("#CustomerId").val();
    
    $.ajax({
        url: "/Sales/ShowCustomerLoyaltyPoint",
        type: "POST",
        data: { customerId: customerId },
        success: function (response) {
            var loyaltyPoint = response.LoyaltyPoint;
            $("#LoyaltyPoint").val(loyaltyPoint);
            //Show Discount Parcent
            var discountParcent = loyaltyPoint / 10;
            $("#DiscountParcent").val(discountParcent);
            //Show Discount Amount
            var grandTotal = $("#GrandTotal").val();
            var discountAmount = (grandTotal * discountParcent) / 100;
            $("#DiscountAmount").val(discountAmount);
            //Show Payable Amount
            var payableAmount = grandTotal - discountAmount;
            $("#PayableAmount").val(payableAmount);
        }
    })


})
//Show customer loyalty point Js End

//Show Product Records Js Start
$("#ProductId").change(function () {
    var productId = $("#ProductId").val();
    
    $.ajax({
        url: "/Sales/ShowProductRecords",
        type: "POST",
        data: { productId: productId },
        success: function (response) {
            var productName = response.ProductName;
            var reorderLevel = response.ReorderLevel;
            var availableQuantity = response.AvailabelQuantity;
            var unitPrice = response.UnitPrice;
            $("#ProductName").val(productName);
            $("#AvailabelQuantity").val(availableQuantity);
            $("#UnitPrice").val(unitPrice);
            $("#reorderLevel").val(reorderLevel);
        }
    })
})
//Show Product Records Js End

//Generate Product Details Table Row js Start
$("#AddButton").click(function () {
    GenerateRow();
    //Get GrandTotal
    var val = 0;
    $(".table tbody tr").each(function () {
        
        //var grandTotal = $(this).find("#totalCell").html();
        var grandTotal = $(this).find("#totalCell").text();
        val += parseFloat(grandTotal);
    })
    $("#GrandTotal").val(val);
    //Show Discount Amount
    var discountParcent = $("#DiscountParcent").val();
    var discountAmount = (val * discountParcent) / 100;
    $("#DiscountAmount").val(discountAmount);
    //Show Payable Amount
    var payableAmount = val - discountAmount;
    $("#PayableAmount").val(payableAmount);
})

function GenerateRow() {
    var values = GetValues();
    
    //Check Reorder Level Start
    var availableQuantity = $("#AvailabelQuantity").val();
    var availableQuantity = parseInt(availableQuantity);
    var quantity = $("#Quantity").val();
    var quantity = parseInt(quantity);
    var totalQuantity = 0;
    $(".table tbody tr").each(function () {
        
        var quantity = $(this).find("#product" + values.ProductId + "").text();
        
        totalQuantity += parseInt(quantity);
    })
    if ((totalQuantity + quantity) > availableQuantity) {
        alert("Insufficient Product!");
        return;
    }
    //Check Reorder Level End

    var index = $("#tableBody").children("tr").length;
    var sl = index;
    var indexCell = "<td style='display:none'><input type='hidden' id='index" + index + "' name='SalesDetails.index' value='" + index + "'/></td>";
    var productIdCell = "<td style='display:none'><input type='hidden' id='productId" + index + "' name='SalesDetails[" + index + "].ProductId' value='" + values.ProductId + "' /></td>";
    var slCell = "<td>" + (++sl) + "</td>";
    var productNameCell = "<td>" + values.ProductName + "</td>";
    var quantityCell = "<td id='product" + values.ProductId + "'><input type='hidden' id='quantity" + index + "' name='SalesDetails[" + index + "].Quantity' value='" + values.Quantity + "' />" + values.Quantity + "</td>";
    var unitPriceeCell = "<td><input type='hidden' id='unitPrice" + index + "' name='SalesDetails[" + index + "].UnitPrice' value='" + values.UnitPrice + "' />" + values.UnitPrice + "</td>";
    var totalPriceCell = "<td id='totalCell'><input type='hidden' id='totalPrice" + index + "' name='SalesDetails[" + index + "].TotalPrice' value='" + values.TotalPrice + "' />" + values.TotalPrice + "</td>";
    var deleteCell = "<td><a href='#'id='deleteCell' class='btn btn-danger'><i class='glyphicon glyphicon-trash'></i></a></td>";
    var row = "<tr>" + indexCell + productIdCell + slCell + productNameCell + quantityCell + unitPriceeCell + totalPriceCell + deleteCell + "</tr>";
    $("#tableBody").append(row);
    $("#SalesSubmitButton").prop('disabled', false);
}

function GetValues() {
    var productId = $("#ProductId").val();
    var productName = $("#ProductName").val();
    var unitPrice = $("#UnitPrice").val();
    var quantity = $("#Quantity").val();
    var totalPrice = parseFloat(unitPrice) * parseFloat(quantity);

    if (productId === undefined || productId.length == 0) {
        alert("Please Select Your Product!");
        return;
    }
    if (quantity === undefined || quantity.length == 0) {
        alert("Please Enter Product Quantity!");
        return;
    }

    //Check Reorder Level Start
    $("#alert").hide();
    var reorderLevel = $("#reorderLevel").val();
    var availableQuantity = $("#AvailabelQuantity").val();
    if (parseInt(quantity) > parseInt(availableQuantity)) {
        alert("Insufficient Product!");
        return;
    }
    if (parseInt(availableQuantity) - parseInt(reorderLevel) <= parseInt(quantity)) {
        $("#alert").show();
    }
    //Check Reorder Level End
    var product = {
        "ProductId": productId,
        "ProductName": productName,
        "Quantity": quantity,
        "UnitPrice": unitPrice,
        "TotalPrice": totalPrice
    }
    return product;
}
//Generate Product Details Table Row js End

//Check Product Reorder Level Alert Js Start
$("#Quantity").keyup(function () {
    
    $("#alert").hide();
    var reorderLevel = $("#reorderLevel").val();
    var availableQuantity = $("#AvailabelQuantity").val();
    var quantity = $("#Quantity").val();

    if (parseInt(quantity) > parseInt(availableQuantity)) {
        alert("Insufficient Product!");
        return;
    }
    if (parseInt(availableQuantity) - parseInt(reorderLevel) <= parseInt(quantity)) {
        $("#alert").show();
        return;
    }
})
//Check Product Reorder Level Alert Js End

//Remove Table Row Js Start
$(".table tbody").on('click', '#deleteCell', function () {
    $(this).closest('tr').remove();
    //Get GrandTotal
    var val = 0;
    $(".table tbody tr").each(function () {
        
        var grandTotal = $(this).find("#totalCell").text();
        val += parseFloat(grandTotal);
    })
    $("#GrandTotal").val(val);
    //Show Discount Amount
    var discountParcent = $("#DiscountParcent").val();
    var discountAmount = (val * discountParcent) / 100;
    $("#DiscountAmount").val(discountAmount);
    //Show Payable Amount
    var payableAmount = val - discountAmount;
    $("#PayableAmount").val(payableAmount);
    //Check Exist Table Row
    var row = $("#tableBody").children('tr').length;
    if (row > 0) {
        $("#SalesSubmitButton").prop('disabled', false);
    }
    else {
        $("#SalesSubmitButton").prop('disabled', true);
    }
})
//Remove Table Row Js End

//Get Discount Parcent,Amount,Payable Amount Js Start
$("#DiscountParcent").keyup(function () {
    //Show Discount Amount
    var discountParcent = $("#DiscountParcent").val();
    var grandTotal = $("#GrandTotal").val();
    var discountAmount = (grandTotal * discountParcent) / 100;
    $("#DiscountAmount").val(discountAmount);
    //Show Payable Amount
    var payableAmount = grandTotal - discountAmount;
    $("#PayableAmount").val(payableAmount);
})
//Get Discount Parcent,Amount,Payable Amount Js End