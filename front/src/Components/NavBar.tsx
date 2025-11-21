import { useState } from "react";
import { Link } from "react-router-dom";

export default function NavBar() {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <nav className="bg-blue-600 text-white">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex justify-between h-16 items-center">
          <div className="text-lg font-bold">Медицинский портал</div>

          <div className="sm:hidden">
            <button
              onClick={() => setIsOpen(!isOpen)}
              className="focus:outline-none focus:ring-2 focus:ring-white"
            >
              <svg
                className="h-6 w-6"
                fill="none"
                stroke="currentColor"
                viewBox="0 0 24 24"
                xmlns="http://www.w3.org/2000/svg"
              >
                {isOpen ? (
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth="2"
                    d="M6 18L18 6M6 6l12 12"
                  />
                ) : (
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth="2"
                    d="M4 6h16M4 12h16M4 18h16"
                  />
                )}
              </svg>
            </button>
          </div>

          <div className="hidden sm:flex space-x-8">
            <Link to="/patients" className="hover:text-gray-200">
              Пациенты
            </Link>
            <Link to="/" className="hover:text-gray-200">
              Доктора
            </Link>
            <Link to="/diseases" className="hover:text-gray-200">
              Болезни
            </Link>
          </div>
        </div>
      </div>

      {isOpen && (
        <div className="sm:hidden px-2 pt-2 pb-3 space-y-1">
          <Link
            to="/patients"
            className="block px-3 py-2 rounded-md hover:bg-blue-500"
          >
            Пациенты
          </Link>
          <Link to="/" className="block px-3 py-2 rounded-md hover:bg-blue-500">
            Доктора
          </Link>
          <Link
            to="/diseases"
            className="block px-3 py-2 rounded-md hover:bg-blue-500"
          >
            Болезни
          </Link>
        </div>
      )}
    </nav>
  );
}
