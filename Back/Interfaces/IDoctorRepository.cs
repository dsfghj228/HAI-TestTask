using Back.MediatR.Commands;
using Back.Models;

namespace Back.Interfaces;

public interface IDoctorRepository
{
    Task<Doctor> CreateDoctor(CreateDoctorCommand doctor);
    Task<List<Doctor>> GetDoctorsBySpecialization(string specialization);
}