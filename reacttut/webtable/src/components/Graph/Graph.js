import { useEffect, useState } from "react";
import Plot from "react-plotly.js";
import axios from "axios";
import "./Graph.css"


const Graph = () => {
  const [param, setParams] = useState(0)
  const [histData, setHistData] = useState({x: [], y: []})
  useEffect(async () => {
    const result = await axios("http://localhost:5000/api/Members/GetMetrics");
    await setParams(result.data)
  }, [param])

  useEffect(() => {
    fetch("http://localhost:5000/api/Members/GetHistogramData").then(res => res.json()).then(data =>{
      let x = Object.keys(data);
      let y = [];
      for (let key of x) y.push(data[key]);
      setHistData({x,y})
    })
  }, [])
  return (
    <div className="container">
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
        style={{ width: "80%", margin: "5rem auto" }}
      />
       
    </div>
  );
};

export default Graph
