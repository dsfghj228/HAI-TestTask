using AutoMapper;
using Back.Dto;
using Back.Interfaces;
using Back.MediatR.Queries;
using MediatR;

namespace Back.MediatR.Handlers;

public class GetDoctorsBySpecialization : IRequestHandler<GetDoctorsBySpecializationQuery, List<ReturnDoctorDto>>
{
    private readonly IDoctorRepository _repo;
    private readonly IMapper _mapper;
    
    public GetDoctorsBySpecialization(IDoctorRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    
    public async Task<List<ReturnDoctorDto>> Handle(GetDoctorsBySpecializationQuery request, CancellationToken cancellationToken)
    {
        var doctor = await _repo.GetDoctorsBySpecialization(request.Specialization);
        var doctorForReturn = _mapper.Map<List<ReturnDoctorDto>>(doctor);
        return doctorForReturn;
    }
}