using AdopetAPI.Data;
using AdopetAPI.Data.Dtos.Responsavel;
using AdopetAPI.Data.Dtos.Tutores;
using AdopetAPI.Models;
using AutoMapper;
using FluentResults;

namespace AdopetAPI.Services
{

    public class ResponsavelService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ResponsavelService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadResponsavelDto AdicionarResponsavel(CreateResponsavelDto responsavelDto)
        {
            Responsavel responsavel = _mapper.Map<Responsavel>(responsavelDto);
            _context.Responsaveis.Add(responsavel);
            _context.SaveChanges();
            return _mapper.Map<ReadResponsavelDto>(responsavel);
        }

        public List<ReadResponsavelDto> RetornarResponsavels(string nomeDoResponsavel)
        {
            List<Responsavel> Responsavels = _context.Responsaveis.ToList();
            if (Responsavels == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(nomeDoResponsavel))
            {
                IEnumerable<Responsavel> query = from Responsavel in Responsavels
                                                 where Responsavel.Resp_Nome == nomeDoResponsavel
                                                 select Responsavel;
                Responsavels = query.ToList();
            }
            return _mapper.Map<List<ReadResponsavelDto>>(Responsavels);

        }

        public ReadResponsavelDto RecuperarResponsavelsPorId(int id)
        {
            Responsavel responsavel = _context.Responsaveis.FirstOrDefault(responsavel => responsavel.Resp_Id == id);
            if (responsavel != null)
            {
                return _mapper.Map<ReadResponsavelDto>(responsavel);
            }
            return null;
        }

        public Result AtualizarResponsavel(int id, UpdateResponsavelDto ResponsavelDto)
        {
            Responsavel responsavel = _context.Responsaveis.FirstOrDefault(responsavel => responsavel.Resp_Id == id);
            if (responsavel == null)
            {
                return Result.Fail("Responsavel não Encontrado!");
            }
            _mapper.Map(ResponsavelDto, responsavel);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarResponsavel(int id)
        {
            Responsavel responsavel = _context.Responsaveis.FirstOrDefault(responsavel => responsavel.Resp_Id == id);
            if (responsavel == null)
            {
                return Result.Fail("Responsavel não Encontrado!");
            }
            _context.Remove(responsavel);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
