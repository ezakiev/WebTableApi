import { useEffect, useState } from "react";
import "./App.css";
import Table from "./components/Table/Table";
import axios from "axios";

const App = () => {
  const [data, setData] = useState([]);
  useEffect(async() => {
    const result = await axios("https://localhost:5001/api/Members/GetDates");
    setData(result.data)
  }, [])
  return (
    <div className="container">
      <Table data={data}/>
    </div>
  );
};

export default App;
