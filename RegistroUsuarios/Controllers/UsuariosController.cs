using MediatR;
using Microsoft.AspNetCore.Mvc;
using RegistroUsuarios.Aplicacion;
using RegistroUsuarios.Modelo;

namespace RegistroUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuarios>>> GetUsuarios()
        {
            return await _mediator.Send(new Consulta.ListaUsuarios());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuariosId(string id)
        {
            return await _mediator.Send(new ConsultaFiltro.UsuarioId { UsuarioPorId = id });
        }
    }
}
