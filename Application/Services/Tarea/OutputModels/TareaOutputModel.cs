using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Tarea.OutputModels
{
    public class TareaOutputModel
    {
        public string Descripcion { get; private set; }
        public Guid Id { get; set; }
        public UsuarioOutputModel Usuario { get; set; }
        public TareaOutputModel(string descripcion, Guid id, UsuarioOutputModel usuario)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Usuario = usuario;
        }
    }
}
