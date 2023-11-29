
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
                //Grafy

                // Náhodná data pro příklad
                //var xData = [1, 2, 3, 4, 5];
                //var yData = [10, 15, 13, 17, 10];
                var xData = JSON.parse(document.getElementById('Graph1').getAttribute('data-xdata'));
                var yData = JSON.parse(document.getElementById('Graph1').getAttribute('data-ydata'));

                // Definování stopy grafu
                var trace = {
                    x: xData,
                    y: yData,
                    type: 'scatter'
                };

                // Definování rozložení grafu
                var layout = {
                    title: 'Můj první Plotly graf',
                    xaxis: {
                        title: 'X-Axis'
                    },
                    yaxis: {
                        title: 'Y-Axis'
                    }
                };

                // Vytvoření grafu
                Plotly.newPlot('Graph1', [trace], layout);
            }
        });
    });



});

