//#region Parts
window.partFormatter = function (id) {
    var res;
    res += "<button class='btn btn-sm btn-info m-1 usePart' data-id='" + id + "'>استفاده</button>";
    res += "<button class='btn btn-sm btn-info m-1 addDescription' data-id='" + id + "'>افزودن به توضیحات</button>";

    return res;
}
window.partsAdditionalParams = function () {

    return {
        Brand: $(".part-list #Brand").val(),
        Model: $(".part-list #Model").val()
    };
}

//#endregion

//#region Phones

window.phonesAdditionalParams = function () {

    return {
        Brand: $(".phone-list #Brand").val(),
        Model: $(".phone-list #Model").val()
    };
}

//#endregion
