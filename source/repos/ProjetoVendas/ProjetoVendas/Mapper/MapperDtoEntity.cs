using AutoMapper;
using ProjetoVendas.Dto;
using ProjetoVendas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Mapper
{
    public class MapperDtoEntity : Profile
    {
        public MapperDtoEntity()
        {
            CreateMap<PessoaDto, Pessoa>()
                .ForMember(dest => dest.Nome, map => map.MapFrom(src => $"{src.Nome}"))
                .ReverseMap();
            CreateMap<Pessoa, PessoaEnderecoDto>()
                .ForMember(dest => dest.Cep, map => map.MapFrom(src => src.Cep))
                .ForMember(dest => dest.Cidade, map => map.MapFrom(src => src.Endereco.Cidade));
            CreateMap<Pessoa, PessoaDto>()
                .ForMember(dest => dest.Nome, src => src.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Cep , src => src.MapFrom(src => src.Cep));
        }
    }
}
