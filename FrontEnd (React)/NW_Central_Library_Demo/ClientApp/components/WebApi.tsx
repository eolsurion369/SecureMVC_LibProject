import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class WebApi extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Web API</h1>
            <p>Brief summary</p>
            <ul>
                <li>CORS (Cross Origin Resource Sharing) </li>
                <li>Fetch Data preview</li>
                <li>Postman demo of post(create) and put(update) methods</li>
            </ul>
        </div>;
    }
}
