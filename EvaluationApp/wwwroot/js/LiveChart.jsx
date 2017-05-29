var LiveChart = React.createClass({
    getInitialState() {
        // Connect this component to the back-end view model.
        this.vm = dotnetify.react.connect("LiveChartVM", this, { namespace: "ViewModels.React" });

        // The VM's initial state was generated server-side and included with the JSX.
        return window.vmStates.LiveChartVM;
    },
    componentWillUnmount() {
        this.vm.$destroy();
    },
    render() {
        return (
            {/* Using react-chartjs https://github.com/reactjs/react-chartjs */ }
            <div className= "row">
                    <LiveLineChart data={this.state.InitialLineData} nextData={this.state.NextLineData} />
            </div>
         );
       }
    });

const LiveLineChart = React.createClass({
    getInitialState() {
        // Build the ChartJS data parameter with initial data.
        var initialData = {
            labels: [],
            datasets: [{
                label: "",
                data: [],
                fillColor: "rgba(217,237,245,0.2)",
                strokeColor: "#9acfea",
                pointColor: "#9acfea",
                pointStrokeColor: "#fff"
            }]
        };
        this.props.data.map(data => {
            initialData.labels.push(data[0]);
            initialData.datasets[0].data.push(data[1]);
        });
        return { chartData: initialData };
    },
    render() {
        var chartData = this.state.chartData;
        const chartOptions = { responsive: true, animation: false };
        const updateData = data => {
            if (data) {
                chartData.labels.shift();
                chartData.labels.push(data[0]);
                chartData.datasets[0].data.shift();
                chartData.datasets[0].data.push(data[1]);
            }
        }
        return (
            <LineChart data={chartData} options={chartOptions}>{updateData(this.props.nextData)}</LineChart>
        );
    }
});