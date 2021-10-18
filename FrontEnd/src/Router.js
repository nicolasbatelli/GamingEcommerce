import { BrowserRouter, Switch, Route } from "react-router-dom";
import LandingPage from "./Components/LandingPage/LandingPage";


function Router() {
  return (
    <div>
      <BrowserRouter>
        <Switch>
            <Route path="/" exact component={LandingPage}/>
        </Switch>
      </BrowserRouter>
  </div>
  );
}

export default Router;
