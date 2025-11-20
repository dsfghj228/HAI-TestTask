using Back.MediatR.Commands;
using Back.Models;

namespace Back.Interfaces;

public interface IPatientRepository
{
    Task<Patient> CreatePatient(CreatePatientCommand command);
}