import React, { useContext, useEffect, useRef, useState } from "react";
import { CurrentUserContext } from "./UserContext";
import Chart from "chart.js";

const BarGraph = () => {
  const TITLE_CHART = "Rolling Retention 7 day";
  const COLOR_CHART = "rgba(104, 162, 235, 0.3)";
  const canvasRef = useRef(null);
  const [chartData, setChartData] = useState(0);
  const [currentUserState, setCurrentUserState] = useContext(
    CurrentUserContext
  );

  useEffect(() => {
    const ctx = canvasRef.current.getContext("2d");
    let data = {
      labels: [""],
      datasets: [
        {
          label: TITLE_CHART,
          data: [chartData],
          borderWidth: 2,
          backgroundColor: COLOR_CHART,
        },
      ],
    };

    let options = {
      data: data,
      options: {
        responsive: true,
        title: {
          display: false,
        },
        legend: {
          display: true,
        },
        tooltip: {
          enabled: false,
        },
        scales: {
          xAxes: [
            {
              display: true,
            },
          ],
          yAxes: [
            {
              display: true,
              ticks: {
                min: 0,                
              },
            },
          ],
        },
      },
    };
    Chart.Bar(ctx, options);
  }, [chartData]);

  useEffect(() => {
    if (currentUserState.render) {
      setChartData(currentUserState.barGraphData);
      setCurrentUserState((state) => ({
        ...state,
        render: false,
      }));
    }
  }, [currentUserState, setCurrentUserState]);

  return (
    <section>
      <div className="canvas">
        <canvas ref={canvasRef} width="350" height="250"></canvas>
      </div>
    </section>
  );
};

export default BarGraph;
