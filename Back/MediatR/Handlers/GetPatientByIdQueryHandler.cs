using AutoMapper;
using Back.Dto;
using Back.Interfaces;
using Back.MediatR.Queries;
using Back.Models;
using MediatR;

namespace Back.MediatR.Handlers;

public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, ReturnPatientDto>
{
    private readonly IPatientRepository _repo;
    private readonly IMapper _mapper;

    public GetPatientByIdQueryHandler(IPatientRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    
    public async Task<ReturnPatientDto> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
    {
        var patient = await _repo.GetPatientById(request.Id);
        
        var patientToReturn = _mapper.Map<ReturnPatientDto>(patient);
        return patientToReturn;
    }
}