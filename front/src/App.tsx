import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import DoctorList from "./Components/DoctorList";

function App() {
  return (
    <div>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<DoctorList />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
