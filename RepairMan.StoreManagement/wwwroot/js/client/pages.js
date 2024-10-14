//#region Parts
window.partFormatter = function (id) {
    return "<button class='btn btn-sm btn-outline-dark m-1 usePart' data-id='" + id + "'>استفاده</button>";
}

window.partEvents = {
    'click button.usePart': function (row) {
        var $this, url;
        $this = $(this);
        url = $('table[data-toggle=table]').data("useUrl");

        $.ajax({
            url: url,
            type: "POST",
            cache: false,
            data: {
                id: $this.data("id")
            }
        }).done(function (data, textStatus, jqXHR) {
            if (!data.data) {
                toastr["error"]((_ref1 = data.message) != null ? _ref1 : resource.exception.editError);
                return;
            }

            toastr["success"](resource.message.saveSuccess);

            window.$table.bootstrapTable("refresh", {
                silent: true,
                pageNumber: 1
            });
        }).fail(function (msg) {
            toastr["error"](msg.status === 403 ? resource.exception.forbidden : resource.exception.serverError);
        });
    }
}

window.partsAdditionalParams = function () {

    return {
        Brand: $(".part-list #Brand").val(),
        Category: $(".part-list #Category").val(),
        Model: $(".part-list #Model").val(),
        Availability: $(".part-list #Availability").val()
    };
}

//#endregion

//#region Phones
window.phoneFormatter = function (id) {
    return "<button class='btn btn-sm btn-outline-dark m-1 usePhone' data-id='" + id + "'>استفاده</button>";
}

window.phoneEvents = {
    'click button.usePhone': function (row) {
        var $this, url;
        $this = $(this);
        url = $('table[data-toggle=table]').data("useUrl");

        $.ajax({
            url: url,
            type: "POST",
            cache: false,
            data: {
                id: $this.data("id")
            }
        }).done(function (data, textStatus, jqXHR) {
            if (!data.data) {
                toastr["error"]((_ref1 = data.message) != null ? _ref1 : resource.exception.editError);
                return;
            }

            toastr["success"](resource.message.saveSuccess);

            window.$table.bootstrapTable("refresh", {
                silent: true,
                pageNumber: 1
            });
        }).fail(function (msg) {
            toastr["error"](msg.status === 403 ? resource.exception.forbidden : resource.exception.serverError);
        });
    }
}

window.phonesAdditionalParams = function () {

    return {
        Brand: $(".phone-list #Brand").val(),
        Model: $(".phone-list #Model").val(),
        Availability: $(".phone-list #Availability").val()
    };
}

//#endregion

//#region Expense

window.expensesAdditionalParams = function () {

    return {
        Title: $(".expense-list #Title").val(),
        PurchaseDateLocal: $(".expense-list #PurchaseDateLocal").val()
    };
}

//#endregion

//#region Repair

window.repairsAdditionalParams = function () {

    return {
        Brand: $(".repair-list #Brand").val(),
        Model: $(".repair-list #Model").val(),
        RepairDateLocal: $(".repair-list #RepairDateLocal").val()
    };
}

$(document).on("keyup", "input[type=text].repairPrice", function () {
    var value = parseInt($(this).val());

    $(".repairPriceValue").html((value / 10).toFixed(0).num2persian() + " " + "تومان");
});

$(document).on("keyup", "input[type=text].storePrice", function () {
    var value = parseInt($(this).val());

    $(".storePriceValue").html((value / 10).toFixed(0).num2persian() + " " + "تومان");
});

$(document).on("keyup", "#RepairCost," + "#StoreShareCost", function () {
    var repairPrice = $("#RepairCost");
    var storePrice = $("#StoreShareCost");
    var totalCost = $("#TotalCost");

    var repairPriceValue = $(".repairCostValue");
    var storePriceValue = $(".storeCostValue");
    var totalCostValue = $(".totalCostValue");



    repairPriceValue.html((parseInt(repairPrice.val()) / 10).toFixed(0).num2persian() + " " + "تومان");
    storePriceValue.html((parseInt(storePrice.val()) / 10).toFixed(0).num2persian() + " " + "تومان");

    totalCost.val(parseInt(repairPrice.val()) + parseInt(storePrice.val()));
    totalCostValue.html((parseInt(totalCost.val()) / 10).toFixed(0).num2persian() + " " + "تومان");
});

//#endregion 