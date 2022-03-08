using Application.Services.Tarea.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Tarea
{
    public interface ITareaService
    {
        public Task<IEnumerable<TareaOutputModel>> GetAll(int skip, int take);

        public Task<IEnumerable<Domain.Models.Tarea>> GetByContains(string nombre, int skip, int take, bool des, bool includeUsuarios);
    }
}
