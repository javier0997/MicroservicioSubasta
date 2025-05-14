using AutoMapper;
using MediatR;
using MongoDB.Driver;
using ProductoService.Application.DTOs;
using ProductoService.Application.Queries;
using ProductoService.Infrastructure.Data.MongoDb;

namespace ProductoService.Application.Handlers;

public class GetProductoByIdQueryHandler : IRequestHandler<GetProductoByIdQuery, ProductoDto?>
{
    private readonly ProductoReadDbContext _readContext;
    private readonly IMapper _mapper;

    public GetProductoByIdQueryHandler(ProductoReadDbContext readContext, IMapper mapper)
    {
        _readContext = readContext;
        _mapper = mapper;
    }

    public async Task<ProductoDto?> Handle(GetProductoByIdQuery request, CancellationToken cancellationToken)
    {
        var producto = await _readContext.Productos
            .Find(p => p.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        return producto != null ? _mapper.Map<ProductoDto>(producto) : null;
    }
} 