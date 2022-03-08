using PJENL.Shared.Kernel.DomainUtils.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Tarea.Specification
{
    public class ComboSpecification : BaseSpecification<Domain.Models.Tarea>
    {
        public ComboSpecification(string searchValue, int skip, int take, bool desc, bool includeUsuarios) :
            base(x => string.IsNullOrEmpty(searchValue) ? true : x.Descripcion.Contains(searchValue))
        {
            ApplyPaging(skip, take);
            if (desc) ApplyOrderByDescending(x => x.Id);
            if (includeUsuarios) AddInclude(x => x.Usuario);
        }
    }
}
