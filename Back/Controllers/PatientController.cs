using Back.Dto;
using Back.MediatR.Commands;
using Back.MediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;


/// <summary>
/// Контроллер пациентов
/// </summary>
[ApiController]
[Route("api/patient")]
public class PatientController : Controller
{
    private readonly IMediator _mediator;
    
    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Создание нового пациента
    /// </summary>
    /// <response code="200">Пациент успешно создан</response>
    /// <response code="400">
    /// Возможные ошибки:
    /// - Некорректные данные запроса
    /// </response>
    /// <response code="404">Доктор не найден</response>
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
    
    /// <summary>
    /// Получение всех пациентов
    /// </summary>
    /// <response code="200">Успешное получение данных</response>
    [HttpGet]
    public async Task<IActionResult> GetAllPatients()
    {
        var query = new GetAllPatientsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    
    /// <summary>
    /// Получение пациента по Id
    /// </summary>
    /// <response code="200">Успешное получение данных</response>
    /// <response code="400">
    /// Возможные ошибки:
    /// - Некорректные данные запроса
    /// </response>
    /// <response code="404">Пациент не найден</response>
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
    
    /// <summary>
    /// Добавление болезни к пациенту
    /// </summary>
    /// <response code="200">Успешное обновление данных</response>
    /// <response code="400">
    /// Возможные ошибки:
    /// - Некорректные данные запроса
    /// </response>
    /// <response code="404">
    /// Возможные ошибки:
    /// - Пациент не найден
    /// - Болезнь не найдена
    /// </response>
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