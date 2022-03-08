using Application.Services.Tarea.OutputModels;
using Application.Services.Tarea.Specification;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using PJENL.Shared.Kernel.DomainUtils.DDD;
using PJENL.Shared.Kernel.DomainUtils.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Tarea
{
    public class TareaService : ITareaService
    {
        private readonly IMapper _mapper;
        private readonly ITareaRepository _repository;
        public TareaService(ITareaRepository tareaRepository, IMapper mapper)
        {
            _repository = tareaRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TareaOutputModel>> GetAll(int skip, int take)
        {
            var data = _repository.GetAllQueryableRepository();
            return await data.Skip(skip).Take(take)
                .Select(x => new TareaOutputModel(x.Descripcion, x.Id, new UsuarioOutputModel(x.Usuario.Nombre, x.Usuario.Id)))
                .ToListAsync();
        }

        public async Task<IEnumerable<Domain.Models.Tarea>> GetByContains(string nombre, int skip, int take, bool des, bool includeUsuarios)
        {
            return await _repository
                .GetAll(new PaginationSpecification<Domain.Models.Tarea>(x => true, skip, take))
                .ToListAsync();
        }
    }
}
