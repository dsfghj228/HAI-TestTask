using Back.Dto;
using Back.MediatR.Commands;
using Back.MediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

[ApiController]
[Route("api/patient")]
public class PatientController : Controller
{
    private readonly IMediator _mediator;
    
    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePatient([FromBody] CreatePatientDto dto)
    {
        var command = new CreatePatientCommand
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            Address = dto.Address,
            BirthDate = dto.BirthDate,
            Gender = dto.Gender,
            DoctorId = dto.DoctorId
        };
        
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPatients()
    {
        var query = new GetAllPatientsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientById(int id)
    {
        var query = new GetPatientByIdQuery
        {
            Id = id
        };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("{patientId}/disease/{diseaseId}")]
    public async Task<IActionResult> AddDisease([FromRoute] int patientId, [FromRoute] int diseaseId)
    {
        var command = new AddDiseaseToPatientCommand
        {
            PatientId = patientId,
            DiseaseId = diseaseId
        };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}