import { useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { updateDisease } from "../Api/api";

interface UpdateDiseaseForm {
  name: string;
  description: string;
}

export default function UpdateDisease() {
  const { diseaseId } = useParams<{ diseaseId: string }>();
  const navigate = useNavigate();

  const [form, setForm] = useState<UpdateDiseaseForm>({
    name: "",
    description: "",
  });
  const [submitting, setSubmitting] = useState(false);
  const [error, setError] = useState("");

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = e.target;
    setForm((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!diseaseId) return;

    setSubmitting(true);
    setError("");

    const result = await updateDisease(Number(diseaseId), form);
    if (result) {
      navigate("/diseases");
    } else {
      setError("Ошибка при обновлении болезни");
    }

    setSubmitting(false);
  };

  return (
    <div className="max-w-md mx-auto mt-10 p-6 bg-white rounded-lg shadow-md">
      <h1 className="text-2xl font-bold mb-6 text-center">Обновить болезнь</h1>

      {error && <p className="text-red-500 mb-4">{error}</p>}

      <form className="space-y-4" onSubmit={handleSubmit}>
        <div>
          <label className="block mb-1 font-medium">Название болезни</label>
          <input
            type="text"
            name="name"
            value={form.name}
            onChange={handleChange}
            required
            className="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
        </div>

        <div>
          <label className="block mb-1 font-medium">Описание</label>
          <textarea
            name="description"
            value={form.description}
            onChange={handleChange}
            required
            rows={5}
            className="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
        </div>

        <button
          type="submit"
          disabled={submitting}
          className={`w-full py-2 px-4 rounded-lg text-white font-semibold ${
            submitting
              ? "bg-blue-300 cursor-not-allowed"
              : "bg-blue-600 hover:bg-blue-700"
          }`}
        >
          {submitting ? "Сохраняем..." : "Обновить"}
        </button>
      </form>
    </div>
  );
}
