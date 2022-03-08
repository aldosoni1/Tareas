using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Tarea.OutputModels
{
    public class UsuarioOutputModel 
    {
        public UsuarioOutputModel(string nombre, int id)
        {
            Nombre = nombre;
            Id = id;
        }

        public string Nombre { get; private set; }
        public int Id { get; private set; }

    }
}
