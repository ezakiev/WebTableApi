import { useEffect, useState } from "react";
import Plot from "react-plotly.js";
import axios from "axios";
import "./Graph.css"


const Graph = () => {
  const [param, setParams] = useState(0)
  const [histData, setHistData] = useState({x: [], y: []})
  useEffect(async () => {
    const result = await axios("https://localhost:5001/api/Members/GetMetrics");
    await setParams(result.data)
  }, [param])

  useEffect(() => {
    fetch("https://localhost:5001/api/Members/GetHistogramData").then(res => res.json()).then(data =>{
      let x = Object.keys(data);
      let y = [];
      for (let key of x) y.push(data[key]);
      setHistData({x,y})
    })
  }, [])
  return (
    <div>
      <div className="container__metric">
         <h2>Rolling Retention 7 Day = {param}% </h2>
      </div>
      <Plot
        data={[
          {
            type: "bar",
            x: histData.x,
            y: histData.y,
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
