using Back.Dto;
using Back.MediatR.Commands;
using Back.MediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

[ApiController]
[Route("api/diseases")]
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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDiseaseInfo([FromRoute] int id, UpdateDiseaseDto dto)
    {
        var command = new UpdateDiseaseInfoCommand
        {
            DiseaseId = id,
            Name = dto.Name,
            Description = dto.Description,
        };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}