/*
 * to focous read code 2 times and check the console in browswe and see what we have there
 */

$(function () {
    console.log("its fine")
    $(document).on("click", ".edit-product-button", function () {
        console.log("you just click number" + $(this).val());
        // store the product id number
        var productID = $(this).val();
        $.ajax({
            type: "json",
            data: {
                "id": productID
            },
            url: "/Product/ShowDetailsJson",
            success: function (data) {
                console.log(data)
                // fill in the input fields in the modal
                $("#modal-input-id").val(data.id);
                $("#modal-input-name").val(data.name);
                $("#modal-input-price").val(data.price);
                $("#modal-input-info").val(data.info);




            }

        });
    });
    $("#save-button").click(function () {
        // get values from the input fields and create a json object to submit to the controller
        var Product = {
            "Id": $("#modal-input-id").val(),
            "Name": $("#modal-input-name").val(),
            "Price": $("#modal-input-price").val(),
            "Info": $("#modal-input-info").val()
        };
        console.log("Saved");
        console.log(Product);
        // save the updated product record in the database using controller.
        $.ajax({
            type: "json",
            data: Product,
            url: "/Product/ProcessEditReturnPartial",
            success: function (data) {
                console.log(data);
                // it will hide and apear after 1 sec
                $("#card-number-" + Product.Id).html(data).hide().fadeIn(1000);
            }


        });

    });
});