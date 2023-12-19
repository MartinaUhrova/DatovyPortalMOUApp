
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
                    hoverinfo: 'none',
                };
                var data = [values];                

                if (document.getElementById('Graph').getAttribute('data-ci') == true) {
                    var lowerLimit = {
                        x: [1, 2, 3, 4],
                        y: [13, 18, 15, 18],
                        mode: "lines",
                        name: "95% IS",
                        line: {
                            color: "#284B63",
                            dash: "dot",
                        },
                        hoverinfo: 'none',
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
                        hoverinfo: 'none',
                    };
                    var data = [values, lowerLimit, upperLimit];
                }

                var layout = {
                    width: 1200,
                    height: 600,
                    title: "Nazev indikatoru",                    
                    xaxis: {
                        title: "popisek osy x",
                        fixedrange:true,
                    },
                    yaxis: {
                        title: "Hodnota",
                        fixedrange: true,
                    },
                };

                var colors = ['black', 'red', 'blue', 'green', '#284B63'];
                var i = 0;

                var config = {
                    modeBarButtonsToRemove: ['zoom2d', 'pan2d', 'zoomin2d', 'zoomout2d', 'autoScale2d', 'resetScale2d'],
                    responsive:true,
                    displaylogo: false,                    
                    scrollZoom: false,
                    editable: true,
                    displayModeBar: true,
                    modeBarButtonsToAdd: [
                        {
                            name: 'Color toggler',
                            icon: Plotly.Icons.pencil,
                            direction: 'up',
                            click: function (gd) {
                                var newColor = colors[i % 5]
                                i++
                                Plotly.restyle(gd, 'line.color', newColor)
                            }
                        }],
                };              

                Plotly.newPlot("Graph", data, layout, config);
            }
        });
    });

});

document.getElementById("GraphOutputRB1_1").addEventListener('change', function () {
    if (document.getElementById("GraphOutputRB1_1").checked == true) {
        document.getElementById("GraphOutputSelectDiagnosis").classList.add("hidden");
        document.getElementById("GraphOutputSelectStadium").classList.remove("hidden");
        document.getElementById("GraphOutputSelectRegion").classList.remove("hidden");
        document.getElementById("GraphOutputSelectPeriod").classList.remove("hidden");

        document.getElementById("GraphOutputCheckDiagnosis").classList.remove("hidden");
        document.getElementById("GraphOutputCheckStadium").classList.add("hidden");
        document.getElementById("GraphOutputCheckRegion").classList.add("hidden");
        document.getElementById("GraphOutputCheckPeriod").classList.add("hidden");
    } else {
        document.getElementById("GraphOutputSelectDiagnosis").classList.remove("hidden");
        document.getElementById("GraphOutputCheckDiagnosis").classList.add("hidden");
    }
});
document.getElementById("GraphOutputRB1_2").addEventListener('change', function () {
    if (document.getElementById("GraphOutputRB1_2").checked == true) {
        document.getElementById("GraphOutputSelectDiagnosis").classList.remove("hidden");
        document.getElementById("GraphOutputSelectStadium").classList.add("hidden");
        document.getElementById("GraphOutputSelectRegion").classList.remove("hidden");
        document.getElementById("GraphOutputSelectPeriod").classList.remove("hidden");

        document.getElementById("GraphOutputCheckDiagnosis").classList.add("hidden");
        document.getElementById("GraphOutputCheckStadium").classList.remove("hidden");
        document.getElementById("GraphOutputCheckRegion").classList.add("hidden");
        document.getElementById("GraphOutputCheckPeriod").classList.add("hidden");
    } else {
        document.getElementById("GraphOutputSelectStadium").classList.remove("hidden");
        document.getElementById("GraphOutputCheckStadium").classList.add("hidden");
    }
});
document.getElementById("GraphOutputRB1_3").addEventListener('change', function () {
    if (document.getElementById("GraphOutputRB1_3").checked == true) {
        document.getElementById("GraphOutputSelectDiagnosis").classList.remove("hidden");
        document.getElementById("GraphOutputSelectStadium").classList.remove("hidden");
        document.getElementById("GraphOutputSelectRegion").classList.add("hidden");
        document.getElementById("GraphOutputSelectPeriod").classList.remove("hidden");

        document.getElementById("GraphOutputCheckDiagnosis").classList.add("hidden");
        document.getElementById("GraphOutputCheckStadium").classList.add("hidden");
        document.getElementById("GraphOutputCheckRegion").classList.remove("hidden");
        document.getElementById("GraphOutputCheckPeriod").classList.add("hidden");
    } else {
        document.getElementById("GraphOutputSelectRegion").classList.remove("hidden");
        document.getElementById("GraphOutputCheckRegion").classList.add("hidden");
    }
});
document.getElementById("GraphOutputRB1_4").addEventListener('change', function () {
    if (document.getElementById("GraphOutputRB1_4").checked == true) {
        document.getElementById("GraphOutputSelectDiagnosis").classList.remove("hidden");
        document.getElementById("GraphOutputSelectStadium").classList.remove("hidden");
        document.getElementById("GraphOutputSelectRegion").classList.remove("hidden");
        document.getElementById("GraphOutputSelectPeriod").classList.add("hidden");

        document.getElementById("GraphOutputCheckDiagnosis").classList.add("hidden");
        document.getElementById("GraphOutputCheckStadium").classList.add("hidden");
        document.getElementById("GraphOutputCheckRegion").classList.add("hidden");
        document.getElementById("GraphOutputCheckPeriod").classList.remove("hidden");
    } else {
        document.getElementById("GraphOutputSelectPeriod").classList.remove("hidden");
        document.getElementById("GraphOutputCheckPeriod").classList.add("hidden");
    }
});
