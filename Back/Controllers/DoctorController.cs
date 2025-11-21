using Back.Dto;
using Back.MediatR.Commands;
using Back.MediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

[ApiController]
[Route("api/doctor")]
public class DoctorController : Controller
{
    private readonly IMediator _mediator;
    
    public DoctorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/create")]
    public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorDto dto)
    {
        var command = new CreateDoctorCommand
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Specialization = dto.Specialization,
            Phone = dto.Phone,
            Email = dto.Email,
            ExperienceYears = dto.ExperienceYears
        };
        
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("{specialization}")]
    public async Task<IActionResult> GetDoctorsBySpecialization([FromRoute] string specialization)
    {
        var query = new GetDoctorsBySpecializationQuery
        {
            Specialization = specialization
        };
        
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}