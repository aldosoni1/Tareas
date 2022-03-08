using PJENL.Shared.Kernel.DomainUtils.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Interfaces
{
    public interface ITareaRepository : IRepository<Tarea, Guid>
    {
    }
}
