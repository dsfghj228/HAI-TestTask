using AutoMapper;
using Back.Dto;
using Back.Interfaces;
using Back.MediatR.Queries;
using Back.Models;
using MediatR;

namespace Back.MediatR.Handlers;

public class GetAllDiseasesQueryHandler : IRequestHandler<GetAllDiseasesQuery, List<ReturnDiseaseDto>>
{
    private readonly IDiseaseRepository _repo;
    private readonly IMapper _mapper;
    
    public GetAllDiseasesQueryHandler(IDiseaseRepository repo,  IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    
    public async Task<List<ReturnDiseaseDto>> Handle(GetAllDiseasesQuery request, CancellationToken cancellationToken)
    {
        var diseases = await _repo.GetAllDiseases();
        var diseasesForReturn = _mapper.Map<List<ReturnDiseaseDto>>(diseases);

        return diseasesForReturn;
    }
}