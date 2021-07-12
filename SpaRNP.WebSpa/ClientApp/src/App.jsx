import React from 'react'
import { Switch, Route } from 'react-router'
import Home from './components/Home'
import './custom.css'

const App = () => {
    return (
      <Switch>
        <Route exact path='/' component={Home} />
      </Switch>
    );  
}
export default App
