using Back.Data;
using Back.Interfaces;
using Back.MediatR.Commands;
using Back.Models;

namespace Back.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly ApplicationDbContext _context;
    
    public DoctorRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Doctor> CreateDoctor(CreateDoctorCommand doctor)
    {
        var newDoctor = new Doctor
        {
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Specialization = doctor.Specialization,
            Phone = doctor.Phone,
            Email = doctor.Email,
            ExperienceYears = doctor.ExperienceYears,
            Patients = new List<Patient>()
        };
        
        await _context.Doctors.AddAsync(newDoctor);
        await _context.SaveChangesAsync();
        
        return newDoctor;
    }
}