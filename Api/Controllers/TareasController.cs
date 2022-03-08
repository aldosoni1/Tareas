using Application.Services.Tarea;
using Domain.Models;
using Infraestructura;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly ITareaService _tareaService;
        private readonly TareaContext _tareaContext;
        public TareasController(ITareaService tareaService, TareaContext tareaContext)
        {
            this._tareaService = tareaService;
            this._tareaContext = tareaContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int skip = 0, int take = 10)
        {
            return Ok(await _tareaService.GetAll(skip, take));
        }
        [HttpGet("ComboSpecification")]
        public async Task<IActionResult> GetAllSpecification(string? searchValue, int skip = 0, int take = 10, bool des = false, bool includeUsuarios = false)
        {
            return Ok(await _tareaService.GetByContains(searchValue, skip, take, des, includeUsuarios));
        }
        [HttpGet("Registros")]
        public async Task<IActionResult> Registrar()
        {
            List<Usuario> usuarios = new List<Usuario>
            {
                new Usuario("Aldo", "Teoba", new List<Tarea>{ new Tarea("Dar platica sobre patron specification")}),
                new Usuario("Ignacio", "Sanchez", new List<Tarea>{ new Tarea("Implementar identity server 4")})
            };
            await _tareaContext.Set<Usuario>().AddRangeAsync(usuarios);
            await _tareaContext.SaveChangesAsync();
            return Ok();
        }
    }
}
