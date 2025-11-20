using Back.Interfaces;
using Back.MediatR.Queries;
using Back.Models;
using MediatR;

namespace Back.MediatR.Handlers;

public class GetAllDiseasesQueryHandler : IRequestHandler<GetAllDiseasesQuery, List<Disease>>
{
    private readonly IDiseaseRepository _repo;
    
    public GetAllDiseasesQueryHandler(IDiseaseRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<List<Disease>> Handle(GetAllDiseasesQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetAllDiseases();
    }
}