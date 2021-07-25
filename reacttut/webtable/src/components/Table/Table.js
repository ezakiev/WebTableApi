import React, { Component, useState } from "react";
import { BootstrapTable, TableHeaderColumn } from "react-bootstrap-table";
import Graph from "../Graph/Graph"
import "./Table.css";

let saveData = [];
const saveResults = async () => {
  fetch("https://localhost:5001/api/Members/MultipleUpdate", {
    method: "PUT",
    mode: "cors",
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(saveData),
  }).then(res => console.log(res))
  saveData = [];
};

const Table = ({data}) => {
  const [graphActive, setGraphActive] = useState(false)
  const onAfterSaveCell = (row, cellName, cellValue) => {
    let checkId = saveData.filter((el) => el.Id === row.Id);
    if (checkId.length === 0) saveData.push(row);
  };

  const cellEditProp = {
    mode: "click",
    blurToSave: true,
    afterSaveCell: onAfterSaveCell,
  };
  console.log(data)
  return (
    <div>
      <BootstrapTable
        data={data}
        cellEdit={cellEditProp}
      >
        <TableHeaderColumn isKey dataField="Id">
          MemberID
        </TableHeaderColumn>
        <TableHeaderColumn dataField="RegistrationDate">RegistrationDate</TableHeaderColumn>
        <TableHeaderColumn dataField="LastActivityDate">
          LastActivityDate
        </TableHeaderColumn>
      </BootstrapTable>
      <div className="btns_container">
        <button className="btns_container__btn" onClick={saveResults}>
          Save
        </button>
        <button className="btns_container__btn" onClick={() => setGraphActive(!graphActive)}>Calculate</button>
      </div>
      {graphActive ? <Graph></Graph> : null}
      </div>
  );
};

export default Table;
