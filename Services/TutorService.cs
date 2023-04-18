using AdopetAPI.Data;
using AdopetAPI.Data.Dtos.Tutores;
using AdopetAPI.Models;
using AutoMapper;
using FluentResults;

namespace AdopetAPI.Services
{

    public class TutorService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public TutorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadTutorDto AdicionarTutor(CreateTutorDto tutorDto)
        {
            Tutor tutor = _mapper.Map<Tutor>(tutorDto);
            _context.Tutores.Add(tutor);
            _context.SaveChanges();
            return _mapper.Map<ReadTutorDto>(tutor);
        }

        public List<ReadTutorDto> RetornarTutor(string nomeDoTutor)
        {
            List<Tutor> Tutores = _context.Tutores.ToList();
            if (Tutores == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(nomeDoTutor))
            {
                IEnumerable<Tutor> query = from Tutor in Tutores
                                           where Tutor.Tutor_Nome.Contains(nomeDoTutor)
                                           select Tutor;
                Tutores = query.ToList();
            }
            else
                Tutores = Tutores.OrderBy(order => order.Tutor_Nome).ToList();

            return _mapper.Map<List<ReadTutorDto>>(Tutores);

        }

        public ReadTutorDto RecuperarTutorPorId(int id)
        {
            Tutor tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Tutor_Id == id);
            if (tutor != null)
            {
                return _mapper.Map<ReadTutorDto>(tutor);
            }
            return null;
        }

        public Result AtualizarTutor(int id, UpdateTutorDto TutorDto)
        {
            Tutor tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Tutor_Id == id);
            if (tutor == null)
            {
                return Result.Fail("Tutor não Encontrado!");
            }
            _mapper.Map(TutorDto, tutor);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarTutor(int id)
        {
            Tutor tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Tutor_Id == id);
            if (tutor == null)
            {
                return Result.Fail("Tutor não Encontrado!");
            }
            _context.Remove(tutor);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
