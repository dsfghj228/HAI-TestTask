using Back.Models;
using MediatR;

namespace Back.MediatR.Queries;

public class GetAllDiseasesQuery : IRequest<List<Disease>>
{
    
}