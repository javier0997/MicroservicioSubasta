using AutoMapper;
using ProductoService.Application.DTOs;
using ProductoService.Domain.Entities;

namespace ProductoService.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Producto, ProductoDto>();
        base.CreateMap<CreateProductoDto, Producto>();
        base.CreateMap<UpdateProductoDto, Producto>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Subasta, SubastaDto>();
        CreateMap<CreateSubastaDto, Subasta>();
        CreateMap<UpdateSubastaDto, Subasta>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
} 