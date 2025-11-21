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
