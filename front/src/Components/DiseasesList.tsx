import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getAllDiseases } from "../Api/api";
import { ReturnDisease } from "../Api/api.interfaces";

export default function DiseasesList() {
  const [diseases, setDiseases] = useState<ReturnDisease[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    const fetchDiseases = async () => {
      try {
        const data = await getAllDiseases();
        if (data) {
          setDiseases(Array.isArray(data) ? data : [data]);
        } else {
          setError("Не удалось загрузить болезни");
        }
      } catch (err) {
        setError("Ошибка при загрузке данных");
      } finally {
        setLoading(false);
      }
    };

    fetchDiseases();
  }, []);

  if (loading) {
    return <p className="text-center mt-10">Загрузка...</p>;
  }

  if (error) {
    return <p className="text-red-500 text-center mt-10">{error}</p>;
  }

  return (
    <div className="max-w-6xl mx-auto p-4">
      <h1 className="text-3xl font-bold text-center mb-8">Список болезней</h1>
      <div className="grid gap-6 sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3">
        {diseases.map((disease) => (
          <div
            key={disease.diseaseId}
            className="bg-white rounded-lg shadow-md p-6 flex flex-col justify-between hover:shadow-lg transition-shadow"
          >
            <div>
              <h2 className="text-xl font-semibold mb-2">{disease.name}</h2>
              <p className="text-gray-600">{disease.description}</p>
            </div>
            <button
              onClick={() => navigate(`/update-disease/${disease.diseaseId}`)}
              className="mt-4 py-2 px-4 bg-yellow-600 text-white rounded-lg hover:bg-yellow-700 font-medium"
            >
              Изменить болезнь
            </button>
          </div>
        ))}
      </div>
    </div>
  );
}
