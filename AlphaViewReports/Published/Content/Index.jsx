
$(document).ready(function () {
    var dp = $("#txtDataInicial");
    dp.datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: "dd/mm/yy",
        language: "tr"
    });
});


$(document).ready(function () {
    var dp = $("#txtDataFinal");
    dp.datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: "dd/mm/yy",
        language: "tr"
    });
});
