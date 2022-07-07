function updateStock(id) {
    $.ajax(
        {
            type: 'POST',
            dataType: 'JSON',
            url: '/Home/UpdateStockUsingMerchantProductNo',
            data: { merchantProductNo: id },
            success:
                function (response) {
                    alert(response.message);
                },
            error:
                function (response) {
                    alert("An error occurred while updating record!")
                }
        });
}