google.charts.load('current', { packages: ['corechart', 'line'] });
google.charts.setOnLoadCallback(GetDataPoints);
var graphData = [];

function drawLineColors(dataFromServer) {
    var data = new google.visualization.DataTable();
    data.addColumn('number', 'X');
    data.addColumn('number', 'StudentData');
    graphData.push(dataFromServer);
    data.addRows(graphData);

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

function GetDataPoints() {
    jQuery.support.cors = true;
    $.ajax({
        url: '/api/Data?id=' + $("#LectureId").val(),
        type: 'GET',
        dataType: 'json',
        success: function (dataFromServer) {
            setTimeout(GetDataPoints, 1000)
            drawLineColors(dataFromServer);
        },
        error: function (x, y) {
            console.log(x, y);
        }
    });
};