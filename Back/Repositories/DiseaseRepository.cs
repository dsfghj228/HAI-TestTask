using Back.Data;
using Back.Exceptions;
using Back.Interfaces;
using Back.MediatR.Commands;
using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Repositories;

public class DiseaseRepository : IDiseaseRepository
{
    private readonly ApplicationDbContext _context;
    
    public DiseaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Disease>> GetAllDiseases()
    {
        return await _context.Diseases.ToListAsync();
    }

    public async Task<Disease> UpdateDisease(UpdateDiseaseInfoCommand command)
    {
        var disease = await _context.Diseases.FirstOrDefaultAsync(d => d.DiseaseId == command.DiseaseId);

        if (disease == null)
        {
            throw new CustomExceptions.DiseaseNotFoundException(command.DiseaseId);
        }
        
        disease.Name = command.Name;
        disease.Description = command.Description;
        
        await _context.SaveChangesAsync();

        return disease;
    }
}