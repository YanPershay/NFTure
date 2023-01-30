import { BrowserRouter } from "react-router-dom";
import "./App.css";
import AppRouter from "./AppRouter";
import Navbar from "./components/navbar/Navbar";

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Navbar />
        <section className="page-content">
          <AppRouter />
        </section>
      </BrowserRouter>
    </div>
  );
}

export default App;
