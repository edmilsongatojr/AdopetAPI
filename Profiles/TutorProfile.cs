using AdopetAPI.Models;
using AdopetAPI.Data.Dtos.Responsavel;
using AutoMapper;
using AdopetAPI.Data.Dtos.Tutores;

namespace AdopetAPI.Profiles
{
    public class TutorProfile : Profile
    {
        public TutorProfile()
        {
            CreateMap<CreateTutorDto, Tutor>();
            CreateMap<Tutor, ReadTutorDto>();
            CreateMap<UpdateTutorDto, Tutor>();
            CreateMap<UpdateTutorDto, ReadTutorDto>();
            CreateMap<ReadTutorDto, UpdateTutorDto>();
        }
    }
}
