import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { createDoctor } from "../Api/api";
import { CreateDoctor } from "../Api/api.interfaces";

export default function AddDoctor() {
  const [doctor, setDoctor] = useState<CreateDoctor>({
    firstName: "",
    lastName: "",
    specialization: "",
    phone: "",
    email: "",
    experienceYears: 0,
  });
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");

  const navigate = useNavigate();

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setDoctor((prev) => ({
      ...prev,
      [name]: name === "experienceYears" ? Number(value) : value,
    }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    setError("");

    const result = await createDoctor(doctor);

    if (result) {
      navigate("/");
    } else {
      setError("Ошибка при создании врача");
    }

    setLoading(false);
  };

  return (
    <div className="max-w-md mx-auto mt-10 p-6 bg-white rounded-lg shadow-md">
      <h1 className="text-2xl font-bold mb-6 text-center">Добавить врача</h1>

      {error && <p className="text-red-500 mb-4">{error}</p>}

      <form className="space-y-4" onSubmit={handleSubmit}>
        <input
          type="text"
          name="firstName"
          value={doctor.firstName}
          onChange={handleChange}
          placeholder="Имя"
          required
          className="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
        <input
          type="text"
          name="lastName"
          value={doctor.lastName}
          onChange={handleChange}
          placeholder="Фамилия"
          required
          className="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
        <input
          type="text"
          name="specialization"
          value={doctor.specialization}
          onChange={handleChange}
          placeholder="Специализация"
          required
          className="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
        <input
          type="text"
          name="phone"
          value={doctor.phone}
          onChange={handleChange}
          placeholder="Телефон"
          required
          className="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
        <input
          type="email"
          name="email"
          value={doctor.email}
          onChange={handleChange}
          placeholder="Email"
          required
          className="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
        <input
          type="number"
          name="experienceYears"
          value={doctor.experienceYears}
          onChange={handleChange}
          placeholder="Опыт работы (лет)"
          min={0}
          required
          className="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
        />

        <button
          type="submit"
          disabled={loading}
          className={`w-full py-2 px-4 rounded-lg text-white font-semibold ${
            loading
              ? "bg-blue-300 cursor-not-allowed"
              : "bg-blue-600 hover:bg-blue-700"
          }`}
        >
          {loading ? "Сохраняем..." : "Добавить врача"}
        </button>
      </form>
    </div>
  );
}
