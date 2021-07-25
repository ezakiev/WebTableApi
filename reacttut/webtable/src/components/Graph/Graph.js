import Plot from "react-plotly.js";

var data = [
  {
    x: ["giraffes", "orangutans", "monkeys"],
    y: [20, 14, 23],
    type: "bar",
  },
];

const Graph = () => {
  return (
    <div>
      <Plot
        data={[
          {
            type: "bar",
            x: ["0-20", "20-40", "40-60"],
            y: [10,20,30],
            // displayModeBar: false,
          },
        ]}
        config={{
          displayModeBar: false,
          responsive: true,
        }}
        layout={{
        //   xaxis: {
        //     type: "date",
        //   },
        }}
        style={{ width: "80%", margin: "0 auto" }}
      />
    </div>
  );
};

export default Graph
