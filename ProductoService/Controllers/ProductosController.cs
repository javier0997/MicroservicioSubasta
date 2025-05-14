using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductoService.Application.Commands;
using ProductoService.Application.DTOs;
using ProductoService.Application.Queries;

namespace ProductoService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoDto>>> GetAll()
    {
        var query = new GetAllProductosQuery();
        var productos = await _mediator.Send(query);
        return Ok(productos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoDto>> GetById(int id)
    {
        var query = new GetProductoByIdQuery(id);
        var producto = await _mediator.Send(query);
        if (producto == null)
            return NotFound();
        return Ok(producto);
    }

    [HttpGet("subastador/{subastadorId}")]
    public async Task<ActionResult<IEnumerable<ProductoDto>>> GetBySubastadorId(int subastadorId)
    {
        var query = new GetProductosBySubastadorQuery(subastadorId);
        var productos = await _mediator.Send(query);
        return Ok(productos);
    }

    [HttpGet("categoria/{categoria}")]
    public async Task<ActionResult<IEnumerable<ProductoDto>>> GetByCategoria(string categoria)
    {
        var query = new GetProductosByCategoriaQuery(categoria);
        var productos = await _mediator.Send(query);
        return Ok(productos);
    }

    [HttpPost]
    public async Task<ActionResult<ProductoDto>> Create(CreateProductoCommand command)
    {
        var producto = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductoDto>> Update(int id, UpdateProductoDto productoDto)
    {
        try
        {
            var command = new UpdateProductoCommand(id, productoDto);
            var producto = await _mediator.Send(command);
            return Ok(producto);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProductoCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
} 