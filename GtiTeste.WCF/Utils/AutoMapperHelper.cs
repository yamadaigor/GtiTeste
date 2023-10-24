using AutoMapper;
using GtiTeste.Business.Entidades;
using GtiTeste.WCF.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace GtiTeste.WCF.Utils
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
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<Cliente, ClienteContract>().ReverseMap();
                CreateMap<Endereco, EnderecoContract>().ReverseMap();
                CreateMap<Estado, EstadoContract>().ReverseMap();
            }
        }
    }
}