import React,{Component} from 'react';
import {Table} from 'react-bootstrap';

export class Member extends Component{
    constructor(props){
        super(props);
        this.state={deps:[]}
    }

    refreshList(){
        fetch("https://localhost:5001/api/Members/GetDates")
        .then(response=>response.json())
        .then(data=>{
            this.setState({deps:data});
        })
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }

    render(){
        const {deps}=this.state;
            return(
                <div>
                    <Table className="mt-4" striped bordered hover size="sm">
                        <thead>
                            <tr>
                                <th>MemberID</th>
                                <th>RegistrationDate</th>
                                <th>LastActivityDate</th>
                            </tr>
                        </thead>
                        <tbody>
                            {deps.map(mem=>
                                <tr key={mem.Id}>
                                    <td>{mem.Id}</td>
                                    <td>{mem.RegistrationDate}</td>
                                    <td>{mem.LastActivityDate}</td>
                                    <td>Edit / Delete</td>
                                </tr>)}
                        </tbody>
                    </Table>
                </div>
            )
    }
}