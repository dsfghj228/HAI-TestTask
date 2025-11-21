using Back.Data;
using Back.Exceptions;
using Back.Interfaces;
using Back.MediatR.Commands;
using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _context;
    
    public PatientRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Patient> CreatePatient(CreatePatientCommand command)
    {
        var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.DoctorId == command.DoctorId);
        if (doctor == null)
        {
            throw new CustomExceptions.DoctorNotFoundException(command.DoctorId);
        }

        var patient = new Patient
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Address = command.Address,
            BirthDate = command.BirthDate,
            Gender = command.Gender,
            Phone = command.Phone,
            Email = command.Email,
            DoctorId = command.DoctorId,
            Doctor = doctor,
            Diseases = new List<Disease>()
        };
        
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
        return patient;
    }

    public async Task<List<Patient>> GetAllPatients()
    {
        return await _context.Patients.ToListAsync();
    }

    public async Task<Patient> GetPatientById(int id)
    {
        var patient = await _context.Patients.FirstOrDefaultAsync(p => p.PatientId == id);

        if (patient == null)
        {
            throw new CustomExceptions.PatientNotFoundException(id);
        }
        
        return patient;
    }
}