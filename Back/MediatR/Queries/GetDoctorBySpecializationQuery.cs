using Back.Dto;
using MediatR;

namespace Back.MediatR.Queries;

public class GetDoctorsBySpecializationQuery : IRequest<List<ReturnDoctorDto>>
{
    public string Specialization { get; set; }
}