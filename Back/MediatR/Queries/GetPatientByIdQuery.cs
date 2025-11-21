using Back.Dto;
using MediatR;

namespace Back.MediatR.Queries;

public class GetPatientByIdQuery : IRequest<ReturnPatientDto>
{
    public int Id { get; set; }
}