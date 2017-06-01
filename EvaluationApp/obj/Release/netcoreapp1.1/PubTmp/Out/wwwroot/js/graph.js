google.charts.load('current', { packages: ['corechart', 'line'] });
google.charts.setOnLoadCallback(GetDataPoints);
var graphData = [];

function drawLineColors(dataFromServer) {
    var data = new google.visualization.DataTable();
    data.addColumn('number', 'X');
    data.addColumn('number', 'Average Student Reported Understanding');
    graphData.push(dataFromServer);
    data.addRows(graphData);

    var options = {
        vAxis: {
            format: '##',
            minValue: 0,
            maxValue: 100,
            title: 'Level of Understanding (%)'
        },
        hAxis: {
            title: 'Time (0.05 seconds)',
            format: 'scientific', 
            //units: {
            //    seconds: { format: ['hh:mm:ss a', 'ss'] }
            //},    
        },
        colors: ['#1c91c0', '#097138'],
        lineWidth: 5,
        gridlines: { count: -1 },
        //title: 'Lecture Level of Understanding Graph',
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
