using AutoMapper;
using Back.Dto;
using Back.Interfaces;
using Back.MediatR.Commands;
using Back.Models;
using MediatR;

namespace Back.MediatR.Handlers;

public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, ReturnPatientDto>
{
    private readonly IPatientRepository _repo;
    private readonly IMapper _mapper;
    
    public CreatePatientCommandHandler(IPatientRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    
    public async Task<ReturnPatientDto> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _repo.CreatePatient(request);
        var patientForReturn = _mapper.Map<ReturnPatientDto>(patient);
        return patientForReturn;
    }
}