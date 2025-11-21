using Back.MediatR.Commands;
using Back.Models;

namespace Back.Interfaces;

public interface IDiseaseRepository
{
    Task<List<Disease>> GetAllDiseases();
    Task<Disease> UpdateDisease(UpdateDiseaseInfoCommand command);
}