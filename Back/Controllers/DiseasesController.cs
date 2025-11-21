using Back.Dto;
using Back.MediatR.Commands;
using Back.MediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

/// <summary>
/// Контроллер болезней
/// </summary>
[ApiController]
[Route("api/diseases")]
public class DiseasesController : Controller
{
    private readonly IMediator _mediator;
    
    public DiseasesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Получение всех болезней
    /// </summary>
    /// <response code="200">Успешное получение всех болезней</response>
    [HttpGet]
    public async Task<IActionResult> GetAllDiseases()
    {
        var query = new GetAllDiseasesQuery();
        
        var diseases = await _mediator.Send(query);
        return Ok(diseases);
    }
    
    /// <summary>
    /// Обновление информации о болезни
    /// </summary>
    /// <response code="200">Успешное обновление данных</response>
    /// <response code="404">Болезнь не найден</response>
    /// <response code="400">
    /// Возможные ошибки:
    /// - Некорректные данные запроса
    /// </response>
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