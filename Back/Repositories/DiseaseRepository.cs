using Back.Data;
using Back.Interfaces;
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
}