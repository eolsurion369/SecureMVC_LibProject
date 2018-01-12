import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { WebApi } from './components/WebApi';
import { MvcApp } from './components/MvcApp';
import { Database } from './components/Database';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/webapi' component={ WebApi } />
    <Route path='/fetchdata' component={ FetchData } />
    <Route path='/mvcapp' component={ MvcApp } />
    <Route path='/database' component={ Database } />
</Layout>;
