google.charts.load('current', { packages: ['corechart', 'line'] });
google.charts.setOnLoadCallback(drawLineColors);

function drawLineColors() {
    var data = new google.visualization.DataTable();
    data.addColumn('number', 'X');
    data.addColumn('number', 'StudentData');


    data.addRows([
        [0.00, 0], [0.05, 10], [0.10, 20], [0.15, 30], [0.20, 40], [0.25, 50],
        [0.30, 55], [0.35, 50], [0.40, 45], [0.45, 40], [0.50, 35], [0.55, 30],
        [0.60, 35], [0.65, 40], [0.70, 45], [0.75, 50], [0.80, 55], [0.85, 60],
        [0.90, 65], [0.95, 70], [1.00, 75], [1.05, 80],
    ]);

    var options = {
        hAxis: {
            title: 'Time (0.05 seconds)'
        },
        vAxis: {
            title: 'LevelofUnderstanding (%)'
        },
        colors: ['#a52714', '#097138']
    };

    var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
    chart.draw(data, options);
};