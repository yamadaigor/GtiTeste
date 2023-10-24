using AutoMapper;
using GtiTeste.API.Models;
using GtiTeste.Business.Entidades;
using System;
using System.Linq;
using System.Reflection;

namespace GtiTeste.API.Utils
{
    public class AutoMapperHelper
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            var profiles = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(Profile).IsAssignableFrom(x));

            return new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteModel>().ReverseMap();
            CreateMap<Endereco, EnderecoModel>().ReverseMap();
            CreateMap<Estado, EstadoModel>().ReverseMap();
        }
    }
}