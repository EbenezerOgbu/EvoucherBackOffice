
function BasketDetailViewModel() {
    //var self = this;
    //self.fName = ko.observable("John Fame");
    //self.lName = ko.observable("Smith");
    //self.isBasketJustLanded = ko.observable(true);
    //self.deliveryId = ko.observable();
    ////self.noProduct = ko.observable(false);
    ////self.checkBox = ko.observable();
    ////self.disallowUpdates = ko.observable(false);


    $(document).on('click', '#decreaseItem', function () {
        //var itemVal = $(this).siblings("input").val();
        var itemVal = document.getElementById("displayQuantity").value;
        if (itemVal == 0) {
            $(this).prop("disabled", true);
            return;
        }
        itemVal--;
        if (itemVal == 0) {
            $(this).prop("disabled", true);
        }
        document.getElementById("displayQuantity").value = itemVal;
    });

    $(document).on('click', '#increaseItem', function () {
        //var itemVal = $(this).siblings("input").val();
        var itemVal = document.getElementById("displayQuantity").value;
        if (itemVal == 0) {
            $(this).siblings('#decreaseItem').prop("disabled", false);
        }
        itemVal++;
        document.getElementById("displayQuantity").value = itemVal;
    });


    ////Becuase dynamically generated mark-up does not support event calls
    ////this script is used to provide such functionality
    //$(document).on('click', '.itemToRemove', function () {
    //    var showme = $(this).attr("value");
    //    self.removeItem(showme);
    //});

    //self.removeItem = function (productId) {
    //    var postRef = parseInt(productId);
    //    var postData = { ProductId: postRef };
    //    //showOverlay("overlay", "main");
    //    //showOverlay("smoverlay", "basketSummary");
    //    $.ajax({
    //        url: "/Basket/RemoveItem",
    //        type: 'POST',
    //        dataType: 'json',
    //        data: postData,
    //        success: function (basketDetailView) {
    //            self.updateBasket(basketDetailView);
    //        }
    //    });
    //};

    //$(document).on('click', '.itemsToUpdate', function () {

    //    self.updateItemQtys();
    //});
    //self.updateItemQtys = function () {
    //    //showOverlay("overlay", "main");
    //    //showOverlay("smoverlay", "basketSummary");
    //    var postData;
    //    var postArr = [];
    //    var index = 0;
    //    $("[id^='Qty-']").each(function () {
    //        itemElementId = $(this).attr('id');
    //        var productId = 0;
    //        productId = itemElementId.replace("Qty-", "");
    //        postArr[index] = { ProductId: productId, Qty: $(this).val() }
    //        index++;
    //    });
    //    postData = { Items: postArr };
    //    var jsonData = JSON.stringify(postData);
    //    $.ajax({
    //        url: "/Basket/UpdateItems",
    //        type: 'POST',
    //        dataType: 'json',
    //        data: jsonData,
    //        success: function (basketDetailView) {
    //            self.updateBasket(basketDetailView);
    //        }
    //    });
    //};

    //$(document).on('change', '.item-sortdropdown', function () {
    //    var showme = $(this).val();
    //    self.updateShippingService(showme);
    //});


    //self.updateShippingService = function (ddlShippingService) {
    //    var postData = { shippingServiceId: ddlShippingService };
    //    //showOverlay("overlay", "main");
    //    //showOverlay("smoverlay", "basketSummary");
    //    $.ajax({
    //        url: "/Basket/UpdateShipping",
    //        type: 'POST',
    //        dataType: 'json',
    //        data: postData,
    //        success: function (basketDetailView) {

    //            self.updateBasket(basketDetailView);
    //        }
    //    });

    //};
    //self.updateBasket = function (basketDetailView) {
    //    if (basketDetailView.BasketSummary.NumberOfItems == 0) {
    //        $("#basketDisplay").text("You have no items in your basket.");
    //    }
    //    else {
    //        $("#basketDisplay").empty();
    //        $("#basketDisplay").setTemplate($("#basketTemplate").html());
    //        $("#basketDisplay").processTemplate(basketDetailView);
    //    }
    //    updateBasketSummary(basketDetailView.BasketSummary);
    //    //hideOverlay("overlay");
    //    //hideOverlay("smoverlay");
    //};
};


$("#BasketDetail").each(function () {
    ko.applyBindings(new BasketDetailViewModel());
});

