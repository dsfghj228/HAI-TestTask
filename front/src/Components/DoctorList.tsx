import { useState } from "react";
import { Link } from "react-router-dom";
import { getAllDoctorsBySpecialization } from "../Api/api";
import { Doctor } from "../Api/api.interfaces";

export default function DoctorList() {
  const [specialization, setSpecialization] = useState<string>("");
  const [doctors, setDoctors] = useState<Doctor[]>([]);
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState<boolean>(false);

  const handleSearch = async () => {
    setLoading(true);
    setError(null);
    setDoctors([]);

    try {
      const data = await getAllDoctorsBySpecialization(specialization);

      if (!data || data.length === 0) {
        setError("Врачи не найдены");
        return;
      }

      setDoctors(data);
    } catch (err: any) {
      setError(err.message || "Произошла неизвестная ошибка");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="max-w-4xl mx-auto p-4">
      <h1 className="text-3xl font-bold text-center mb-6">
        Список всех врачей
      </h1>

      <div className="flex place-content-center">
        <Link to="/add-doctor">
          <button
            className={`px-4 py-2 rounded-lg text-white font-semibold w-25 h-10 ${
              loading
                ? "bg-green-300 cursor-not-allowed"
                : "bg-green-600 hover:bg-green-700"
            }`}
          >
            Добавить врача в базу данных
          </button>
        </Link>
      </div>

      <div className="bg-white shadow-md rounded-lg p-6 mb-6">
        <h2 className="text-xl font-semibold mb-4">
          Введите нужную специализацию
        </h2>
        <div className="flex flex-col sm:flex-row gap-4">
          <input
            type="text"
            value={specialization}
            onChange={(e) => setSpecialization(e.target.value)}
            placeholder="Например, кардиолог"
            className="border border-gray-300 rounded-lg px-4 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500 flex-1"
          />
          <button
            onClick={handleSearch}
            disabled={loading}
            className={`px-4 py-2 rounded-lg text-white font-semibold ${
              loading
                ? "bg-blue-300 cursor-not-allowed"
                : "bg-blue-600 hover:bg-blue-700"
            }`}
          >
            {loading ? "Поиск..." : "Найти"}
          </button>
        </div>
        {error && <p className="text-red-500 mt-2">{error}</p>}
      </div>

      {doctors.length > 0 && (
        <ul className="space-y-4">
          {doctors.map((doctor) => (
            <li
              key={doctor.doctorId}
              className="border border-gray-200 rounded-lg p-4 shadow-sm hover:shadow-md transition-shadow"
            >
              <p className="font-medium">
                {doctor.lastName} {doctor.firstName}
              </p>
              <p className="text-gray-600">{doctor.specialization}</p>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}
