import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getAllPatients } from "../Api/api";
import { ReturnPatient } from "../Api/api.interfaces";

export default function PatientsList() {
  const [patients, setPatients] = useState<ReturnPatient[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  useEffect(() => {
    const fetchPatients = async () => {
      const data = await getAllPatients();

      if (data) {
        setPatients(data);
      } else {
        setError("Не удалось загрузить список пациентов");
      }

      setLoading(false);
    };

    fetchPatients();
  }, []);

  return (
    <div className="max-w-5xl mx-auto p-4 mt-6">
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl sm:text-3xl font-bold">Список пациентов</h1>

        <Link
          to="/add-patient"
          className="bg-green-600 text-white px-4 py-2 rounded-lg shadow hover:bg-green-700 transition"
        >
          Добавить пациента
        </Link>
      </div>

      {loading && <p className="text-gray-600">Загрузка...</p>}
      {error && <p className="text-red-500">{error}</p>}

      {!loading && patients.length === 0 && (
        <p className="text-gray-500 mt-4">Пациенты не найдены.</p>
      )}

      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-5">
        {patients.map((p) => (
          <div
            key={p.patientId}
            className="bg-white shadow rounded-xl p-5 border border-gray-200 hover:shadow-lg transition"
          >
            <h2 className="text-xl font-semibold mb-2">
              {p.lastName} {p.firstName}
            </h2>

            <p className="text-gray-700">
              <span className="font-medium">Дата Рождения:</span> {p.birthDate}
            </p>

            <p className="text-gray-700 mb-4">
              <span className="font-medium">Пол:</span> {p.gender}
            </p>

            <Link
              to={`/patients/${p.patientId}`}
              className="block bg-blue-600 text-white text-center py-2 mt-2 rounded-lg hover:bg-blue-700 transition"
            >
              Подробнее
            </Link>
          </div>
        ))}
      </div>
    </div>
  );
}
