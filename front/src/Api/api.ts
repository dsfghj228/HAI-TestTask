import axios from "axios";
import { CreateDoctor, Doctor } from "./api.interfaces";

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
