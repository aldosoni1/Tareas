using PJENL.Shared.Kernel.DomainUtils.DDD;
using PJENL.Shared.Kernel.DomainUtils.Logs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Tarea : IBitacora, IEstaEliminado, ICatalogo<Guid>, ITrack
    {
        protected Tarea()
        {

        }
        public Tarea(string descripcion)
        {
            this.Descripcion = descripcion;
        }
        public void Editar(string des)
        {
            this.Descripcion = des;
        }
        public bool Eliminado { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public Guid? UsuarioElimino { get; set; }
        public Guid UsuarioRegistro { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid? UsuarioModifico { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public Guid Id { get; private set; }
        public Guid IdTrack { get; set; }
        public string Descripcion { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public int IdUsuario { get; set; }
    }
}
