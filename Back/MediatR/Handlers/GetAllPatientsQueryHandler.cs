using AutoMapper;
using Back.Dto;
using Back.Interfaces;
using Back.MediatR.Queries;
using MediatR;

namespace Back.MediatR.Handlers;

public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, List<ReturnPatientDto>>
{
    private readonly IPatientRepository _repo;
    private readonly IMapper _mapper;
    
    public GetAllPatientsQueryHandler(IPatientRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    
    public async Task<List<ReturnPatientDto>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
    {
        var patients = await _repo.GetAllPatients();
        var patientForReturn = _mapper.Map<List<ReturnPatientDto>>(patients);
        return patientForReturn;
    }
}