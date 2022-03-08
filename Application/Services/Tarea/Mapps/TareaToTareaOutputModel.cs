using Application.Services.Tarea.OutputModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Tarea.Mapps
{
    public class TareaToTareaOutputModel : Profile
    {
        public TareaToTareaOutputModel()
        {
            CreateMap<Domain.Models.Tarea, TareaOutputModel>();
        }
    }
}
