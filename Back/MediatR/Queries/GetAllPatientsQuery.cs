using Back.Dto;
using MediatR;

namespace Back.MediatR.Queries;

public class GetAllPatientsQuery : IRequest<List<ReturnPatientDto>>
{
    
}