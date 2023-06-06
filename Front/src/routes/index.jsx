import { BrowserRouter, Route, Switch } from "react-router-dom";

import Home from "../pages/Home/index.jsx";

function Routes() {
  return (
    <BrowserRouter>
      <Switch>
        <Route name="Home" exact component={Home} />
      </Switch>
    </BrowserRouter>
  );
}

export default Routes;
