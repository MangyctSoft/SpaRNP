import React, { Fragment } from 'react'
import Calculate from './Calculate'
import Table from './Table'
import EditingControls from './EditingControls'
import BarGraph from './BarGraph'

const Home = () => {
  return (
    <article>
      <Fragment>
        <Table></Table> 
        <EditingControls></EditingControls>
        <Calculate></Calculate>   
        <BarGraph></BarGraph>    
      </Fragment>
      </article>
    )
  }

export default Home
