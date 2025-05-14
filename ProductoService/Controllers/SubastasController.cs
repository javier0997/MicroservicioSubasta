using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductoService.Application.Commands;
using ProductoService.Application.DTOs;
using ProductoService.Application.Queries;
using ProductoService.Application.Services;

namespace ProductoService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubastasController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubastasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubastaDto>>> GetAll()
    {
        var subastas = await _mediator.Send(new GetAllSubastasQuery());
        return Ok(subastas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SubastaDto>> GetById(int id)
    {
        var subasta = await _mediator.Send(new GetSubastaByIdQuery(id));
        if (subasta == null)
            return NotFound();
        return Ok(subasta);
    }

    [HttpGet("subastador/{subastadorId}")]
    public async Task<ActionResult<IEnumerable<SubastaDto>>> GetBySubastadorId(int subastadorId)
    {
        var subastas = await _mediator.Send(new GetSubastasBySubastadorQuery(subastadorId));
        return Ok(subastas);
    }

    [HttpGet("estado/{estado}")]
    public async Task<ActionResult<IEnumerable<SubastaDto>>> GetByEstado(string estado)
    {
        var subastas = await _mediator.Send(new GetSubastasByEstadoQuery(estado));
        return Ok(subastas);
    }

    [HttpPost]
    public async Task<ActionResult<SubastaDto>> Create(CreateSubastaDto dto)
    {
        var subasta = await _mediator.Send(new CreateSubastaCommand(dto));
        return CreatedAtAction(nameof(GetById), new { id = subasta.Id }, subasta);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<SubastaDto>> Update(int id, UpdateSubastaDto dto)
    {
        try
        {
            var subasta = await _mediator.Send(new UpdateSubastaCommand(id, dto));
            return Ok(subasta);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteSubastaCommand(id));
        return NoContent();
    }
} 