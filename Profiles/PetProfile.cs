using AdopetAPI.Data.Dtos.Pet;
using AdopetAPI.Models;
using AutoMapper;

namespace AdopetAPI.Profiles
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<CreatePetDto, Pet>();
            CreateMap<Pet, ReadPetDto>();
            CreateMap<UpdatePetDto, Pet>();
        }
    }
}
