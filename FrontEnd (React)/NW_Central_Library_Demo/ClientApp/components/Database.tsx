import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Database extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Database</h1>
            <p>Brief summary</p>
            <ul>
                <li>SqlElection - SQL Server Manamgement Studio (SSMS) </li>
                <li>Created datase using DDL (Data Defition Langage) scripts</li>
            </ul>
        </div>;
    }
}

