using Back.Models;

namespace Back.Interfaces;

public interface IDiseaseRepository
{
    Task<List<Disease>> GetAllDiseases();
}