// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    // Připojte obslužnou rutinu k formuláři
    $("#FormValuesOutput").submit(function (e) {
        e.preventDefault(); // Zabrání přirozenému odeslání formuláře

        // Odešlete formulář pomocí AJAX
        $.ajax({
            url: $(this).attr("action"),
            type: $(this).attr("method"),
            data: $(this).serialize(),
            success: function (result) {
                // Vložte aktualizovaný obsah partial view do kontejneru
                $("#partialContainer").html(result);
            }
        });
    });
});