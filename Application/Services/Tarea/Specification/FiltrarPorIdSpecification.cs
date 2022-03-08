using PJENL.Shared.Kernel.DomainUtils.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Tarea.Specification
{
    public class FiltrarPorIdSpecification : BaseSpecification<Domain.Models.Tarea>
    {
        public FiltrarPorIdSpecification(Expression<Func<Domain.Models.Tarea, bool>> criteria) : base(criteria)
        {
        }
    }
}
