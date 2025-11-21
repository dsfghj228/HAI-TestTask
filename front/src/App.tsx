import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import AddDoctor from "./Components/AddDoctor";
import DiseasesList from "./Components/DiseasesList";
import DoctorList from "./Components/DoctorList";
import NavBar from "./Components/NavBar";

function App() {
  return (
    <div>
      <BrowserRouter>
        <NavBar />
        <Routes>
          <Route path="/" element={<DoctorList />} />
          <Route path="/add-doctor" element={<AddDoctor />} />
          <Route path="/diseases" element={<DiseasesList />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
