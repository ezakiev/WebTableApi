import { useEffect, useState } from "react";
import "./App.css";
import Table from "./components/Table/Table";
import axios from "axios";


// let data = [
//   { id: 1, name: "Gob", value: "2" },
//   { id: 2, name: "Buster", value: "5" },
//   { id: 3, name: "George Michael", value: "4" },
// ];



const App = () => {
  const [data, setData] = useState([]);
  const [metric, setMetric] = useState(23)
  useEffect(async() => {
    const result = await axios("https://localhost:5001/api/Members/GetDates");
    setData(result.data)
  }, [])
  return (
    <div className="container">
      <Table data={data}/>
      <div className="container__metric">
        <h3>Rolling Retention 7 Day:</h3>
        <p>{metric}</p>
      </div>
    </div>
  );
};

export default App;
