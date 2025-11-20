using Back.MediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class DiseasesController : Controller
{
    private readonly IMediator _mediator;
    
    public DiseasesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDiseases()
    {
        var query = new GetAllDiseasesQuery();
        
        var diseases = await _mediator.Send(query);
        return Ok(diseases);
    }
}