using AulaProjetoFinal.API.DTOs;
using AulaProjetoFinal.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AulaProjetoFinal.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Carro, CarroDTO>().ReverseMap();
            CreateMap<Marca, MarcaDTO>().ReverseMap();
            CreateMap<Modelo, ModeloDTO>().ReverseMap();
            CreateMap<Veiculo, VeiculoDTO>().ReverseMap();
            CreateMap<Versao, VersaoDTO>().ReverseMap();
        }
    }
}
