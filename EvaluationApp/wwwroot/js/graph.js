google.charts.load('current', { packages: ['corechart', 'line'] });
google.charts.setOnLoadCallback(GetDataPoints);

function drawLineColors(dataFromServer) {
    var data = new google.visualization.DataTable();
    data.addColumn('number', 'X');
    data.addColumn('number', 'StudentData');

    //console.log('got here')

    data.addRows(dataFromServer);

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
        url: '/api/Data?id=1', 
        type: 'GET',
        dataType: 'json',
        success: function (dataFromServer) {
            drawLineColors(dataFromServer);
        },
        error: function (x, y) {
            alert(x + '\n' + y + '\n');
        }
    });
}