using Back.Dto;
using MediatR;

namespace Back.MediatR.Commands;

public class UpdateDiseaseInfoCommand : IRequest<ReturnDiseaseDto>
{
    public int DiseaseId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}