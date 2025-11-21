using Back.Dto;
using MediatR;

namespace Back.MediatR.Commands;

public class AddDiseaseToPatientCommand : IRequest<ReturnPatientDto>
{
    public int PatientId { get; set; }
    public int DiseaseId { get; set; }
}