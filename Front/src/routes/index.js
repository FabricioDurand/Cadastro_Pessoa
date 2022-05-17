import { BrowserRouter, Route, Switch } from "react-router-dom";

import Home from "../pages/Home";

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
