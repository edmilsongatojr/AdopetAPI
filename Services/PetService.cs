using AdopetAPI.Data;
using AdopetAPI.Data.Dtos.Pet;
using AdopetAPI.Models;
using AutoMapper;
using FluentResults;

namespace AdopetAPI.Services
{
    public class PetService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public PetService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadPetDto AdicionarPet(CreatePetDto petDto)
        {
            Pet pet = _mapper.Map<Pet>(petDto);
            Responsavel responsavel = _mapper.Map<Responsavel>(petDto.Responsavel);
            _context.Responsaveis.Add(responsavel);
            _context.SaveChanges();
            _context.Pets.Add(pet);
            _context.SaveChanges();
            return _mapper.Map<ReadPetDto>(pet);
        }

        public List<ReadPetDto> RetornarPets(string nomeDoPet)
        {
            List<Pet> Pets = _context.Pets.ToList();
            if (Pets == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(nomeDoPet))
            {
                IEnumerable<Pet> query = from Pet in Pets
                                            where Pet.Pet_Nome == nomeDoPet
                                            select Pet;
                Pets = query.ToList();
            }
            return _mapper.Map<List<ReadPetDto>>(Pets);

        }

        public ReadPetDto RecuperarPetsPorId(int id)
        {
            Pet pet = _context.Pets.FirstOrDefault(pet => pet.Pet_Id == id);
            if (pet != null)
            {
                return _mapper.Map<ReadPetDto>(pet);
            }
            return null;
        }

        public Result AtualizarPet(int id, UpdatePetDto PetDto)
        {
            Pet pet = _context.Pets.FirstOrDefault(pet => pet.Pet_Id == id);
            if (pet == null)
            {
                return Result.Fail("Pet não Encontrado!");
            }
            _mapper.Map(PetDto, pet);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarPet(int id)
        {
            Pet pet = _context.Pets.FirstOrDefault(pet => pet.Pet_Id == id);
            if (pet == null)
            {
                return Result.Fail("Pet não Encontrado!");
            }
            _context.Remove(pet);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
