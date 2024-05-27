using DesafioStefanini.Server.Context;
using DesafioStefanini.Server.Interface;
using DesafioStefanini.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioStefanini.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StefController : ControllerBase
    {
        private readonly StefDbContext _context;
        private readonly IStefService _service;

        public StefController(StefDbContext context, IStefService stefService)
        {
            _context = context;
            _service = stefService;
        }

        [HttpGet("GetPedidos")]
        public IEnumerable<Pedido> GetPedidos()
        {
            return _service.GetPedidos();
        }

        [HttpGet("GetPedidoPorId/{id}")]
        public IActionResult GetPedidoPorId(int id)
        {
            var pedido = _service.GetPedidoPorId(id);

            if(pedido is null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        [HttpPost("CriarPedido")]
        public IActionResult CriarPedido(Pedido pedido)
        {
            if(pedido is null)
            {
                return BadRequest();
            }

            _service.CriarPedido(pedido);

            return Ok(pedido);
        }

        [HttpPut("AtualizarPedido")]
        public IActionResult AtualizarPedido(Pedido pedido)
        {
            if(pedido is null)
            {
                return BadRequest();
            }

            _service.AtualizarPedido(pedido);

            return Ok(pedido);
        }

        [HttpDelete("DeletarPedido")]
        public ActionResult<int> DeletarPedido(int id)
        {
            return _service.DeletePedido(id);
        }
    }
}
