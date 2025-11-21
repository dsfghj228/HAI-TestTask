import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import AddDoctor from "./Components/AddDoctor";
import AddPatient from "./Components/AddPatient";
import DiseasesList from "./Components/DiseasesList";
import DoctorList from "./Components/DoctorList";
import NavBar from "./Components/NavBar";
import PatientsList from "./Components/PatiensList";
import UpdateDisease from "./Components/UpdateDisease";

function App() {
  return (
    <div>
      <BrowserRouter>
        <NavBar />
        <Routes>
          <Route path="/" element={<DoctorList />} />
          <Route path="/add-doctor" element={<AddDoctor />} />
          <Route path="/diseases" element={<DiseasesList />} />
          <Route
            path="/update-disease/:diseaseId"
            element={<UpdateDisease />}
          />
          <Route path="/patients" element={<PatientsList />} />
          <Route path="/patients/:patientId" element={<AddPatient />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
