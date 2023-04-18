using AdopetAPI.Models;
using AdopetAPI.Data.Dtos.Responsavel;
using AutoMapper;
using AdopetAPI.Data.Dtos.Tutores;

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
