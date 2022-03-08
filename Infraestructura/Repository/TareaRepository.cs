using Domain.Models;
using Domain.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using PJENL.Shared.Kernel.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repository
{
    public class TareaRepository : Repository<Tarea, Guid>, ITareaRepository
    {
        public TareaRepository(TareaContext context) : base(context)
        {
        }
    }
}
