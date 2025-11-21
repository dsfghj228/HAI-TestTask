export interface Doctor {
  doctorId: number;
  firstName: string;
  lastName: string;
  specialization: string;
  phone: string;
  email: string;
  experienceYears: number;
}

export interface CreateDoctor {
  firstName: string;
  lastName: string;
  specialization: string;
  phone: string;
  email: string;
  experienceYears: number;
}

export interface ReturnDisease {
  diseaseId: number;
  name: string;
  description: string;
}

export interface UpdateDisease {
  name: string;
  description: string;
}

export interface ReturnPatient {
  patientId: number;
  firstName: string;
  lastName: string;
  birthDate: string;
  gender: string;
  phone: string;
  email: string;
  address: string;
  doctorId: number;
}

export interface Patient {
  firstName: string;
  lastName: string;
  birthDate: string;
  gender: string;
  phone: string;
  email: string;
  address: string;
  doctorId: number;
}
