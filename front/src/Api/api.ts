import axios from "axios";
import {
  CreateDoctor,
  Doctor,
  ReturnDisease,
  ReturnPatient,
  UpdateDisease,
} from "./api.interfaces";

const API = "https://localhost:7160";

export const getAllDoctorsBySpecialization = async (
  specialization: string
): Promise<Doctor[] | null> => {
  try {
    var response = await axios.get<Doctor[]>(
      `${API}/api/doctor/${specialization}`
    );
    console.log("Успешное получение докторов:", response.data);

    return response.data;
  } catch (err) {
    console.error(err);
    return null;
  }
};

export const createDoctor = async (
  doctor: CreateDoctor
): Promise<Doctor | null> => {
  try {
    var response = await axios.post(`${API}/create`, doctor);
    console.log("Успешное создание доктора: ", response.data);

    return response.data;
  } catch (err) {
    console.error(err);
    return null;
  }
};

export const getAllDiseases = async (): Promise<ReturnDisease[] | null> => {
  try {
    var response = await axios.get(`${API}/api/diseases`);
    console.log(response.data);
    return response.data;
  } catch (err) {
    console.error(err);
    return null;
  }
};

export const updateDisease = async (
  id: number,
  updateDisease: UpdateDisease
): Promise<ReturnDisease | null> => {
  try {
    var response = await axios.put(`${API}/api/diseases/${id}`, updateDisease);
    console.log(response);
    return response.data;
  } catch (err) {
    console.error(err);
    return null;
  }
};

export const getAllPatients = async (): Promise<ReturnPatient[] | null> => {
  try {
    var response = await axios.get(`${API}/api/patient`);
    console.log(response.data);
    return response.data;
  } catch (err) {
    console.log(err);
    return null;
  }
};

export const getPatientById = async (
  id: number
): Promise<ReturnPatient | null> => {
  try {
    var response = await axios.get(`${API}/api/patient/${id}`);
    console.log(response.data);
    return response.data;
  } catch (err) {
    console.error(err);
    return null;
  }
};

export const createPatient = async (
  newPatient: ReturnPatient
): Promise<ReturnPatient | null> => {
  try {
    var response = await axios.post(`${API}/api/patient`, newPatient);
    console.log(response.data);
    return response.data;
  } catch (err) {
    console.error(err);
    return null;
  }
};

export const addDiseaseToPatient = async (
  patientId: number,
  diseaseId: number
): Promise<ReturnPatient | null> => {
  try {
    var response = await axios.post(`${API}/api/patient`, {
      patientId: patientId,
      diseaseId: diseaseId,
    });
    console.log(response.data);
    return response.data;
  } catch (err) {
    console.error(err);
    return null;
  }
};
