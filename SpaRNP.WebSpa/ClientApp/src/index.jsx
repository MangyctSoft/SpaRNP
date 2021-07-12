import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import App from "./App";
import { CurrentUserProvider } from './components/UserContext'

const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const rootElement = document.getElementById("root");

ReactDOM.render(
  <CurrentUserProvider>
  <BrowserRouter basename={baseUrl}>
    <App />
  </BrowserRouter>
  </CurrentUserProvider>,
  rootElement
);
