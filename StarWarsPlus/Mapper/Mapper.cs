using AutoMapper;
using Core.DTO;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsPlus.Mapper
{
    public class Mapper
    {
        private static MapperConfiguration mapperConfig = new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<UserRequestDTO, Core.Entities.User>()
                    .ForMember(dest => dest.Homeworld, m => m.MapFrom(s => new Homeworld { Name = s.Homeworld }))
                    .ForMember(dest => dest.Specie, m => m.MapFrom(s => new Specie { Name = s.Specie }))
                    .ForMember(dest => dest.Gender, m => m.MapFrom(s => s.Gender == GenderType.MaleString ? GenderType.Male : GenderType.Female));
                
                conf.CreateMap<UserUpdateRequestDTO, Core.Entities.User>()
                    .ForMember(dest => dest.Homeworld, m => m.MapFrom(s => new Homeworld { Name = s.Homeworld }))
                    .ForMember(dest => dest.Specie, m => m.MapFrom(s => new Specie { Name = s.Specie }))
                    .ForMember(dest => dest.Gender, m => m.MapFrom(s => s.Gender == GenderType.MaleString ? GenderType.Male : GenderType.Female));


                conf.CreateMap<Core.Entities.User, UserResponseDTO>()
                    .ForMember(dest => dest.Homeworld, m => m.MapFrom(s => s.Homeworld.Name))
                    .ForMember(dest => dest.Specie, m => m.MapFrom(s => s.Specie.Name))
                    .ForMember(dest => dest.Gender, m => m.MapFrom(s => s.Gender == GenderType.Male ? GenderType.MaleString : GenderType.FemaleString));

                conf.CreateMap<Core.Entities.Connections, ConnectionsDTO>();

            }
       );

        private static AutoMapper.IMapper mapper = new AutoMapper.Mapper(mapperConfig);

        public static T Map<T>(object item)
        {
            return mapper.Map<T>(item);
        }
    }
}
