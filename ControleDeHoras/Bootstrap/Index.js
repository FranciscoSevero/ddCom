$(document).ready(function () {
    $('#txtValor').priceFormat({
        prefix: 'R$ ',
        centsSeparator: ',',
        thousandsSeparator: '.'
    });
});
