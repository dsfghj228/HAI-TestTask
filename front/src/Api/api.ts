import axios from "axios";
import { Doctor } from "./api.interfaces";

const API = "https://localhost:7160/api";

export const getAllDoctorsBySpecialization = async (
  specialization: string
): Promise<Doctor[] | null> => {
  try {
    var response = await axios.get<Doctor[]>(`${API}/doctor/${specialization}`);
    console.log("Успешное получение докторов:", response.data);

    return response.data;
  } catch (err) {
    console.error(err);
    return null;
  }
};
