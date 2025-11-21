import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { addDiseaseToPatient, getPatientById } from "../Api/api";

export interface Patient {
  firstName: string;
  lastName: string;
  birthDate: string;
  gender: string;
  phone: string;
  email: string;
  address: string;
}

export interface ReturnPatient extends Patient {
  patientId: number;
}

export default function GetPatient() {
  const { patientId } = useParams<{ patientId: string }>();

  const [patient, setPatient] = useState<ReturnPatient | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  const [diseaseId, setDiseaseId] = useState("");
  const [addStatus, setAddStatus] = useState("");

  useEffect(() => {
    const loadData = async () => {
      if (!patientId) return;

      const data = await getPatientById(Number(patientId));

      if (!data) {
        setError("Не удалось загрузить данные пациента");
      } else {
        setPatient(data);
      }

      setLoading(false);
    };

    loadData();
  }, [patientId]);

  const handleAddDisease = async () => {
    if (!diseaseId.trim()) {
      setAddStatus("Введите ID болезни");
      return;
    }

    const result = await addDiseaseToPatient(
      Number(patientId),
      Number(diseaseId)
    );

    if (result) {
      setAddStatus("Болезнь успешно добавлена");
    } else {
      setAddStatus("Ошибка при добавлении болезни");
    }
  };

  if (loading) return <p className="text-center mt-10">Загрузка...</p>;
  if (error) return <p className="text-red-500 text-center mt-10">{error}</p>;

  return (
    <div className="max-w-3xl mx-auto p-6 mt-10 bg-white shadow rounded-lg">
      <h1 className="text-3xl font-bold mb-6 text-center">
        Информация о пациенте
      </h1>

      {patient && (
        <div className="space-y-3">
          <p>
            <span className="font-semibold">Имя:</span> {patient.firstName}
          </p>
          <p>
            <span className="font-semibold">Фамилия:</span> {patient.lastName}
          </p>
          <p>
            <span className="font-semibold">Дата рождения:</span>{" "}
            {patient.birthDate}
          </p>
          <p>
            <span className="font-semibold">Пол:</span> {patient.gender}
          </p>
          <p>
            <span className="font-semibold">Телефон:</span> {patient.phone}
          </p>
          <p>
            <span className="font-semibold">Email:</span> {patient.email}
          </p>
          <p>
            <span className="font-semibold">Адрес:</span> {patient.address}
          </p>
        </div>
      )}

      {/* Форма добавления болезни */}
      <div className="mt-8 p-4 border rounded-lg bg-gray-50">
        <h2 className="text-xl font-semibold mb-4">Добавить болезнь</h2>

        <div className="flex flex-col sm:flex-row gap-3">
          <input
            type="number"
            placeholder="ID болезни"
            value={diseaseId}
            onChange={(e) => setDiseaseId(e.target.value)}
            className="border border-gray-300 rounded-lg px-3 py-2 w-full focus:ring-2 focus:ring-blue-500"
          />

          <button
            onClick={handleAddDisease}
            className="bg-blue-600 hover:bg-blue-700 text-white px-4 py-2 rounded-lg transition"
          >
            Добавить
          </button>
        </div>

        {addStatus && (
          <p
            className={`mt-3 font-medium ${
              addStatus.includes("успеш") ? "text-green-600" : "text-red-500"
            }`}
          >
            {addStatus}
          </p>
        )}
      </div>
    </div>
  );
}
