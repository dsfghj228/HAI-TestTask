using AutoMapper;
using Back.Dto;
using Back.Interfaces;
using Back.MediatR.Commands;
using MediatR;

namespace Back.MediatR.Handlers;

public class UpdateDiseaseInfoCommandHandler : IRequestHandler<UpdateDiseaseInfoCommand, ReturnDiseaseDto>
{
    private readonly IDiseaseRepository _repo;
    private readonly IMapper _mapper;
    
    public UpdateDiseaseInfoCommandHandler(IDiseaseRepository  repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    
    public async Task<ReturnDiseaseDto> Handle(UpdateDiseaseInfoCommand request, CancellationToken cancellationToken)
    {
        var disease = await _repo.UpdateDisease(request);
        var diseaseForReturn = _mapper.Map<ReturnDiseaseDto>(disease);
        return diseaseForReturn;
    }
}