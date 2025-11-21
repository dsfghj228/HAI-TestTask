import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import DoctorList from "./Components/DoctorList";
import NavBar from "./Components/NavBar";

function App() {
  return (
    <div>
      <BrowserRouter>
        <NavBar />
        <Routes>
          <Route path="/" element={<DoctorList />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
