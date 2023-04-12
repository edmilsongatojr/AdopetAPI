using AdopetAPI.Models;
using AdopetAPI.Data.Dtos.Responsavel;
using AutoMapper;

namespace AdopetAPI.Profiles
{
    public class ResponsavelProfile : Profile
    {
        public ResponsavelProfile()
        {
            CreateMap<CreateResponsavelDto, Responsavel>();
            CreateMap<Responsavel, ReadResponsavelDto>();
            CreateMap<UpdateResponsavelDto, Responsavel>();
        }
    }
}
