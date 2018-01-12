import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Home extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Hello !!</h1>
            <p>Welcome to the demonstratino of our final project - NW Central Libary</p>
            <p>During the creation of our project we uitilezed the following technologies:</p>
            <ul>
                <li>Tech 1</li>
                <li>Tech 2</li>
                <li>Tech 3</li>
            </ul>
            <p>Please hold all your questions until the end of our demonstation at which time we will be happpy to answer them.</p>
        </div>;
    }
}
