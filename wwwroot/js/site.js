
document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("FormValuesOutput").addEventListener('submit', function (e) {
        e.preventDefault(); // Zabrání přirozenému odeslání formuláře

        // Odešlete formulář pomocí AJAX
        $.ajax({
            url: $(this).attr("action"),
            type: $(this).attr("method"),
            data: $(this).serialize(),
            success: function (result) {
                // Vloží aktualizovaný obsah partial view do kontejneru
                $("#ValuesOutput").html(result);                
            }
        });
    });

    document.getElementById("FormGraphOutput").addEventListener('submit', function (e) {
        e.preventDefault();

        $.ajax({
            url: $(this).attr("action"),
            type: $(this).attr("method"),
            data: $(this).serialize(),
            success: function (result) {
                $("#GraphOutput").html(result);
                var values = {
                    x: JSON.parse(document.getElementById('Graph').getAttribute('data-xdata')),
                    y: JSON.parse(document.getElementById('Graph').getAttribute('data-ydata')),
                    mode: "lines",
                    name: "Průměr",
                    line: {
                        color: "#284B63",
                        width: 3,
                    },
                };

                var lowerLimit = {
                    x: [1, 2, 3, 4],
                    y: [13, 18, 15, 18],
                    mode: "lines",
                    name: "95% IS",
                    line: {
                        color: "#284B63",
                        dash: "dot",
                    },
                };

                var upperLimit = {
                    x: [1, 2, 3, 4],
                    y: [8, 12, 12, 15],
                    mode: "lines",
                    showlegend: false,
                    line: {
                        color: "#284B63",
                        dash: "dot",
                    },
                };

                var layout = {
                    width: 1000,
                    height: 400,
                    title: "Nazev indikatoru",
                    xaxis: {
                        title: "popisek osy x",
                    },
                    yaxis: {
                        title: "popisek osy y",
                    },
                };

                var data = [values, lowerLimit, upperLimit];

                Plotly.newPlot("Graph", data, layout);                
            }
        });
    });

});

document.getElementById("GraphOutput_RB_1_1").addEventListener('change', function () {
    if (document.getElementById("GraphOutput_RB_1_1").checked == true) {
        document.getElementById("GraphOutput_Select_1").disabled=true;
        document.getElementById("GraphOutput_Select_2").disabled = false;
        document.getElementById("GraphOutput_Select_3").disabled = false;
        document.getElementById("GraphOutput_Select_4").disabled = false;
    } else {
        document.getElementById("GraphOutput_Select_1").disabled = false;
    }
});
document.getElementById("GraphOutput_RB_1_2").addEventListener('change', function () {
    if (document.getElementById("GraphOutput_RB_1_2").checked == true) {
        document.getElementById("GraphOutput_Select_2").disabled = true;
        document.getElementById("GraphOutput_Select_1").disabled = false;
        document.getElementById("GraphOutput_Select_3").disabled = false;
        document.getElementById("GraphOutput_Select_4").disabled = false;
    } else {
        document.getElementById("GraphOutput_Select_2").disabled = false;
    }
});
document.getElementById("GraphOutput_RB_1_3").addEventListener('change', function () {
    if (document.getElementById("GraphOutput_RB_1_3").checked == true) {
        document.getElementById("GraphOutput_Select_3").disabled = true;
        document.getElementById("GraphOutput_Select_1").disabled = false;
        document.getElementById("GraphOutput_Select_2").disabled = false;
        document.getElementById("GraphOutput_Select_4").disabled = false;
    } else {
        document.getElementById("GraphOutput_Select_3").disabled = false;
    }
});
document.getElementById("GraphOutput_RB_1_4").addEventListener('change', function () {
    if (document.getElementById("GraphOutput_RB_1_4").checked == true) {
        document.getElementById("GraphOutput_Select_4").disabled = true;
        document.getElementById("GraphOutput_Select_1").disabled = false;
        document.getElementById("GraphOutput_Select_3").disabled = false;
        document.getElementById("GraphOutput_Select_2").disabled = false;
    } else {
        document.getElementById("GraphOutput_Select_4").disabled = false;
    }
});
