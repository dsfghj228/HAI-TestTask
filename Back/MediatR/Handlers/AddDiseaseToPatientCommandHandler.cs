using AutoMapper;
using Back.Dto;
using Back.Interfaces;
using Back.MediatR.Commands;
using Back.Models;
using MediatR;

namespace Back.MediatR.Handlers;

public class AddDiseaseToPatientCommandHandler : IRequestHandler<AddDiseaseToPatientCommand, ReturnPatientDto>
{
    private readonly IPatientRepository _repo;
    private readonly IMapper _mapper;
    
    public AddDiseaseToPatientCommandHandler(IPatientRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    
    public async Task<ReturnPatientDto> Handle(AddDiseaseToPatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _repo.AddDiseaseToPatient(request.PatientId, request.DiseaseId);
        var returnPatientDto = _mapper.Map<ReturnPatientDto>(patient);
        return returnPatientDto;
    }
}