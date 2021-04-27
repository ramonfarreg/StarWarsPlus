using AutoMapper;
using Infrastructure.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DAL.Mapper
{
    public class Mapper
    {
        private static MapperConfiguration mapperConfig = new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<User, Core.Entities.User>().ReverseMap();
                conf.CreateMap<Homeworld, Core.Entities.Homeworld>().ReverseMap();
                conf.CreateMap<Specie, Core.Entities.Specie>().ReverseMap();
            }

       );
        private static AutoMapper.IMapper mapper = new AutoMapper.Mapper(mapperConfig);

        public static T Map<T>(object item)
        {
            return mapper.Map<T>(item);
        }
    }
}
