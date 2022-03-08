using PJENL.Shared.Kernel.DomainUtils.DDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Usuario : IEntity<int>
    {
        public Usuario(string nombre, string apellido, IEnumerable<Tarea> tareas)
        {
            Nombre = nombre;
            Apellido = apellido;
            Tareas = tareas;
        }
        protected Usuario()
        {

        }

        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public virtual IEnumerable<Tarea> Tareas { get; set; } = new List<Tarea>();
    }
}
