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
  }).catch(err => console.log(err))
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
  return (
    <div>
       <div className="table_styles">
      <BootstrapTable
        data={data}
        cellEdit={cellEditProp}
        bordered={false}
      >
        <TableHeaderColumn isKey dataField="Id" dataAlign="center" headerAlign="center" width="10%" thStyle={{color: '#3C5AA8', opacity: '0.4'}} >
          MemberID
        </TableHeaderColumn>
        <TableHeaderColumn dataField="RegistrationDate" dataAlign="center" headerAlign="center" width="45%" thStyle={{color: '#3C5AA8', opacity: '0.4'}}>RegistrationDate</TableHeaderColumn>
        <TableHeaderColumn dataField="LastActivityDate" dataAlign="center" headerAlign="center" width="45%" thStyle={{color: '#3C5AA8',opacity: '0.4'}}>
          LastActivityDate
        </TableHeaderColumn>
      </BootstrapTable>
      </div>
      <div className="btns_container">
        <button className="btns_container__el" onClick={saveResults}>
          Save
        </button>
        <button className="btns_container__el" onClick={() => setGraphActive(!graphActive)}>Calculate</button>
      </div>
      <div>
      {graphActive ? <Graph></Graph> : null}
      </div>
    </div>
   
  );
};

export default Table;
